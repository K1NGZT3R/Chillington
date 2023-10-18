using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class WaveCycleManager : MonoBehaviour
{
    public WaveSpawner spawner;
    public GameObject spawnerObj;

    [Header("-SET THESE-")]
    public int waveIncrease =1;
    public int durationIncrease = 30;
    public float timeSpeedSlowdown = 5f;
    //without slowdown is 1 ingame hour per irl second

    [Header("-DEBUG-")]
    public int cycleCount = 0;

    [Header("-LIGHTING-")]
    [Range(0, 24)] public float timeOfDay;
    public Light directionalLight;
    public LightingPreset preset;
    

    private void Update()
    {
        if (preset == null)
            return;

        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime / timeSpeedSlowdown;
            timeOfDay %= 24f;
            UpdateLighting(timeOfDay / 24f);
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
        }

        //spawnerconfig
        if(spawnerObj.activeSelf == false && timeOfDay >= 18f)
        {
            Debug.Log("now night");
            cycleCount++;
            spawner.currWave = spawner.currWave + waveIncrease;
            spawner.waveDuration = spawner.waveDuration + durationIncrease;
            spawnerObj.SetActive(true);
        }
        else if(spawnerObj.activeSelf == true && timeOfDay <7f && timeOfDay >= 5.5f)
        {
            Debug.Log("now day");
            spawnerObj.SetActive(false);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0f));
        }
    }

    //find directional light if you forgot to set it
    private void OnValidate()
    {
        if(directionalLight != null)
            return;
        if(RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }    
        }
    }
}


using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static InteractableComp;
using static UnityEngine.GraphicsBuffer;
using static WaveSpawner;

public class GenEnemyAI : MonoBehaviour
{
    public List<TeleLocations> teleLocations = new();

    public NavMeshAgent agent;

    public GameObject zombs;

    public Transform generator;
    public Transform balls;

    public LayerMask whatIsGround, whatIsGenerator;

    public int health = 10;

    [Header("References")]
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public bool deadMan;

    public UnityEvent OnCaughtPlayer;

    //States
    public float sightRange = 214748364;
    public float attackRange = 0.25f;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject shootScript;
    private Shoot shoot;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        shoot = shootScript.GetComponent<Shoot>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsGenerator);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsGenerator);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnCaughtPlayer?.Invoke();
        }



    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
        //Debug.Log("Patrolling");
    }


    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    public void ChasePlayer()
    {
        agent.SetDestination(generator.position);
        Debug.Log("Enemy: Chasing");
    }


    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(generator);

        if (!alreadyAttacked)
        {
            ///Attack code here
            deadMan = true;
            OnCaughtPlayer?.Invoke();
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        Debug.Log("Enemy: Attacking");
        balls = teleLocations[Random.Range(0, teleLocations.Count)].TeleTransform;
        zombs.transform.position = balls.position;

    }
    private void ResetAttack()
    {
        deadMan = false;
    }

    public void TakeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {
            shoot.hitMarker.SetActive(false);
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }
    public void DestroyEnemy()
    {
        shoot.killScreen = 2.5f;
        shoot.hitMarker.SetActive(false);
        Destroy(gameObject);
    }


    [System.Serializable]
    public class TeleLocations
    {
        public Transform TeleTransform;
    }
}
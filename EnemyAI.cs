using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    // 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    
    // attack
    public float timeBetweenAttack;
    public bool alreadyAttack;

    // States
    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInsightRange && !playerInAttackRange){
            // patrol
            patrol();
        }
        if (playerInsightRange && !playerInAttackRange){
            //  chase
            chase();
        }
        if(playerInsightRange && playerInAttackRange){
            // attack
            attack();
        }
    }

    private void patrol(){
        if(!walkPointSet){
            searchWalkPoint();
        }

        if(walkPointSet){
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }   
    
    private void searchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, - transform.up, 2f, whatIsGround)){
            walkPointSet = true;
        }
    }

    private void chase(){
        agent.SetDestination(player.position);
    }
    private void attack(){
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if(!alreadyAttack){
            // script attack

            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack(){
        alreadyAttack = false;
    }
}

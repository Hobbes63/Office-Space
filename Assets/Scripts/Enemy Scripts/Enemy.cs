using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.IO;

public class Enemy : MonoBehaviour
{
    [Header("< - - - - For Patrol Behavior - - - >")]
    public Transform[] Waypoints;
    public int curWaypoint = 0;
    bool ReversePath = false;
    bool RestartPath = false;
    public NavMeshAgent navAgent;
    Vector3 Destination;

    [Header("< - - - - For 'Usual' Enemy Behavior - - - >")]
    public Transform playerPos;
    public Transform playerCorePos;
    public Transform nearbyTowerPos;
    public Transform currentTarget;
    float distance;

    
    [Header("< - - - - - Attributes - - - - - >")]
    [SerializeField] float health;
    float maxHealth;
    [SerializeField] float baseSpeed;
    float speedModifier;

    [SerializeField] GameObject enemyHealthBar;

    public enum Behaviors { Seek, Attack, Stunned, Flee };
    public Behaviors enemyAiBehaviors = Behaviors.Seek;

    bool withinRange = false;

    //AudioManager audioManager;
    //Add Audio Manager Script to proj (10/1)

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        playerPos = GameObject.Find("Player").transform;
        playerCorePos = GameObject.Find("CubicleCore").transform;

        speedModifier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunBehaviors()
    {
        switch (enemyAiBehaviors)
        {
            case Behaviors.Seek:
                Seek();
                break;

            case Behaviors.Attack:
                Attack();
                break;

            case Behaviors.Stunned:
                Stunned();
                break;

            case Behaviors.Flee:
                Flee();
                break;
        }
    }
    void ChangeBehavior(Behaviors newBehavior)
    {
        enemyAiBehaviors = newBehavior;

        RunBehaviors();
    }
    void Seek()
    {
        Destination = GameObject.Find("Player").transform.position; //This should change to the "target"
        navAgent.SetDestination(Destination);
        distance = Vector3.Distance(gameObject.transform.position, Destination);
        if (distance <= 10)
        {
            ChangeBehavior(Behaviors.Attack);
            navAgent.speed = baseSpeed * speedModifier;
        }
    }
    void Attack()
    {
        if (withinRange)
        {
            enemyAttack();
        }
    }
    void Stunned()
    {
        
    }
    void Flee()
    {
        
    }

    void enemyAttack()
    {
        
    }
}

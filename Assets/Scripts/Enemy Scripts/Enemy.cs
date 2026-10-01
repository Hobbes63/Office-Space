using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public Transform[] Waypoints;
    public int curWaypoint = 0;
    bool ReversePath = false;
    bool RestartPath = false;
    public NavMeshAgent navAgent;
    Vector3 Destination;
    public Transform playerPos;
    public Transform playerCorePos;
    public Transform nearbyTowerPos;
    float distance;

    [SerializeField] float health;
    float maxHealth;

    [SerializeField] GameObject enemyHealthBar;

    public enum Behaviors { Seek, Attack, Stunned, Flee };

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ZombieAI.StateMachine;

public class ZombieAI : MonoBehaviour
{
    [Header("AI Parameters")]
    [Tooltip("Distance to see the player")]
    public float rangeDetection = 10.0f;
   
    [Header("FSM Patrol Wander")]
    [Tooltip("Distance to the wander point on the nav mesh")]
    public float wanderRadius = 60.0f;
    [Tooltip("Time between change of wander point")]
    public float wanderTimer = 1.0f;
    // Start is called before the first frame update

    //Declare which states we'd like use
    public enum States
    {
        Spawning,
        Idle,
        Chase,
        Patrol,
        EndGame,
        Blank
    }

    private Animator anim;
    private StateMachine<States> fsm;
    private States lastState;
    private Rigidbody rig;
    private Transform target;
    private NavMeshAgent agent;

    private EndTriggerZone endZone;

    private GameObject player;
    private PlayerHealth playerHealth;

    private float timer;
    private float idleTimer;

    private float baseDissolveValue;
    private float dissolveValue;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        GetComponentInChildren<EnemyAttack>().setDeg(damage);
        GetComponent<EnemyHealth>().setHealth(health);
        endZone = GameObject.FindGameObjectWithTag("TriggerZone/EndZone").GetComponent<EndTriggerZone>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        fsm = StateMachine<States>.Initialize(this, States.Spawning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/

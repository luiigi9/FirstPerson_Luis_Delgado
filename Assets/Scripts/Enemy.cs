using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nma;
    private Player player;
    private Animator anmtr;
    private bool window = false;
    [SerializeField] Transform hand;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask impact;
    [SerializeField] private float damage;
    private bool damaged = false;
    [SerializeField] float life;
    private Rigidbody[] bones;

    public float Life { get => life; set => life = value; }

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<Player>();
        anmtr = GetComponent<Animator>();
        bones = GetComponentsInChildren<Rigidbody>();
        
        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].isKinematic = true;
        }

        ChangeBoneState(true);
    }

    // Update is called once per frame
    void Update()
    {
        Chasing();
        if (window && damaged == false)
        {
            DetectPlayer();
        }
        
    }
    private void DetectPlayer()
    {
        Collider[] detection = Physics.OverlapSphere(hand.position, radius, impact);
        if (detection.Length > 0)
        {
            for (int i = 0; i < detection.Length; i++)
            {
                Debug.Log(detection[i].name);
                detection[i].GetComponent<Player>().Damage(damage);
            }
            damaged = true;
        }
    }

    private void Chasing()
    {
        nma.SetDestination(player.transform.position);
        if (!nma.pathPending && nma.remainingDistance <= nma.stoppingDistance)
        {
            nma.isStopped = true;
            anmtr.SetBool("Attack", true);
        }
        LookAtPlayer();
    }
    public void Death()
    {
        nma.enabled = false;
        anmtr.enabled = false;
        ChangeBoneState(false);
        Destroy(gameObject, 10);
    }

    private void ChangeBoneState(bool state)
    {
        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].isKinematic = state;
        }
    }

    private void EndAttack()
    {
        nma.isStopped = false;
        damaged = false;
        anmtr.SetBool("Attack", false);
    }
    private void WindowAttackOn()
    {
        window = true;
    }
    private void WindowAttackOff()
    {
        window = false;
    }
    private void LookAtPlayer()
    {
        Vector3 playerDirection = player.transform.position - transform.position.normalized;
        playerDirection.y = 0;
        transform.rotation = Quaternion.LookRotation(playerDirection);
    }


}

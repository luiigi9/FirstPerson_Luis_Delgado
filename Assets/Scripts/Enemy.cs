using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

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
    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<Player>();
        anmtr = GetComponent<Animator>();
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
        if (nma.remainingDistance <= nma.stoppingDistance)
        {
            nma.isStopped = true;
            anmtr.SetBool("Attack", true);
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
    public void DamageRecieved(float damage)
    {
        life -= damage;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

}

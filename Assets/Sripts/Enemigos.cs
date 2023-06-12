using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    public Transform PlayerTarget;
    public Jugador player;
    public NavMeshAgent agent;
    private bool run, idle, punch, die;
    [SerializeField] private Animator AnimatorController;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        idle = true;
        run = false;
        punch = false;
        die = false;
        AnimatorController.SetBool("Idle", idle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !die)
        {
            agent.isStopped = false;
            run = true;
            idle = false;
            punch = false;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !die)
        {
            agent.isStopped = true;
            run = false;
            idle = true;
            punch = false;

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {

            agent.isStopped = true;
            run = false;
            idle = false;
            punch = false;
            die = true;

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            agent.isStopped = true;
            run = false;
            idle = false;
            punch = true;
            die = false;
            player.setDeath();
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.isStopped = false;
            run = true;
            idle = false;
            punch = false;
            die = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (run && !die)
        {
            
            agent.destination = PlayerTarget.position;
        }
       

        AnimatorController.SetBool("Idle", idle);
        AnimatorController.SetBool("Run", run);
        AnimatorController.SetBool("Golpe", punch);
        AnimatorController.SetBool("Die", die);
    }
}

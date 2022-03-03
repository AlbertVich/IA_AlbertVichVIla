using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{

    Transform player;
    NavMeshAgent agent;

    public Transform[] waypoints;
    private int waipointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        waipointIndex = 0;
        UpdateDestionation();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            UpdateDestionation();
            IncraseIndex();
        }

        

        if (Vector3.Distance(transform.position, player.transform.position) < 7f)
        {
            agent.destination = player.transform.position;
            transform.LookAt(player.position);

        }
    }


    void UpdateDestionation()
    {
        target = waypoints[waipointIndex].position;
        agent.SetDestination(target);
    }

    void IncraseIndex()
    {
        waipointIndex++;
        if(waipointIndex == waypoints.Length)
        {
            waipointIndex = 0;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Hit");
        }
    }
}

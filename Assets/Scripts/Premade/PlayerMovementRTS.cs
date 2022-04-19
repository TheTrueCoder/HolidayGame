using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerClickMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera camera;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove() {
        
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {                
                    agent.SetDestination(hit.point);
            }
        }
    }
}


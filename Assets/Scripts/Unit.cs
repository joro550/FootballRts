using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public GameObject selectedVisual;

    private NavMeshAgent _navMeshAgent;

    public void Awake()
    {
        // Get Components
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetSelected(bool selected) 
        => selectedVisual.SetActive(selected);

    public void MoveTo(Vector3 position) 
        => _navMeshAgent.SetDestination(position);
}

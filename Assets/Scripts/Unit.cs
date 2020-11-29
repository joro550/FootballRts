using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public GameObject selectedVisual;
    private NavMeshAgent _navMeshAgent;
    private UnitBallPosition _unitBallPosition;

    private Vector3? _previousPosition;

    public void Awake()
    {
        // Get Components
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _unitBallPosition = GetComponentInChildren<UnitBallPosition>();
    }

    public void SetSelected(bool selected) 
        => selectedVisual.SetActive(selected);

    public void MoveTo(Vector3 position)
    {
        _previousPosition = transform.position;
        _navMeshAgent.SetDestination(position);
    }

    public void MoveToPreviousPosition()
    {
        if (_previousPosition != null)
            _navMeshAgent.SetDestination(_previousPosition.Value);
    }

    public UnitBallPosition GetBallPosition() 
        => _unitBallPosition;
}

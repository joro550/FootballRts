using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BallEntity : MonoBehaviour
{
    public Unit possessor;
    public UnitBallPosition unitBallPosition;

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void Update()
    {
        if (unitBallPosition == null)
            return;

        var scale = transform.localScale / 2;
        transform.position = unitBallPosition.transform.position + scale;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var unit = other.GetComponent<Unit>();

        if (unit == null) 
            return;

        if (possessor != null) 
            unit = DeterminePossessor(unit);

        possessor = unit;
        unitBallPosition = unit.GetBallPosition();
    }

    private Unit DeterminePossessor(Unit newPossessor)
    {
        var randomNumber = Random.Range(1, 12);

        if (randomNumber > 7)
        {
            possessor.MoveToPreviousPosition();
            return newPossessor;
        }
        
        newPossessor.MoveToPreviousPosition();
        return possessor;
    }

    public void MoveTo(Vector3 position) 
        => _navMeshAgent.SetDestination(position);
}

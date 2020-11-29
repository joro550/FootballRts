using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitSelector))]
public class UnitCommander : MonoBehaviour
{
    public LayerMask groundLayerMask;
    public FieldManager _fieldManager;
    public BallEntity _ballEntity;
    
    private Camera _camera;
    private UnitSelector _unitSelector;

    public void Awake()
    {
        // Get components 
        _camera = Camera.main;
        _unitSelector = GetComponent<UnitSelector>();
    }

    public void Update()
    {
        var passMode = GameManager.Instance.GetPassMode();
        if (!Input.GetMouseButtonDown(1)) 
            return;

        if (passMode)
        {
            MoveBall();
        }
        else
        {
            MoveUnit();
        }
    }

    private void MoveBall()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var rayCastHit, 100, groundLayerMask.value))
        {
            var hex = _fieldManager.GetClosestHex(rayCastHit.point);
            _ballEntity.MoveTo(hex.GetCenterPosition());
        }
    }

    private void MoveUnit()
    {
        var units = _unitSelector.GetSelectedUnits();
        foreach (var unit in units)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var rayCastHit, 100, groundLayerMask.value))
            {
                var hex = _fieldManager.GetClosestHex(rayCastHit.point);
                unit.MoveTo(hex.GetCenterPosition());
            }
        }
    }
}

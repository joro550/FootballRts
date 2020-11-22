using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public FieldManager _fieldManager;
    public LayerMask groundLayerMask;
    
    private Camera _camera;

    public void Awake()
    {
        _camera = Camera.main;
    }

    public void Update()
    {
        foreach (var hex in _fieldManager._hexManagers) 
            hex.IsBeingHovered(false);

        HighlightCurrentHex();
    }

    private void HighlightCurrentHex()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var rayCastHit, 100, groundLayerMask.value))
        {
            var hex = _fieldManager.GetClosestHex(rayCastHit.point);
            hex.IsBeingHovered(true);
        }
    }
}

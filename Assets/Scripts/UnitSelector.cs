using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class UnitSelector : MonoBehaviour
{
    public LayerMask unitLayerMask;
    public RectTransform selectionBox;
    public List<Unit> _selectedUnits = new List<Unit>();

    private Camera _camera;
    private Player _player;
    private Vector2 _selectionStartPosition;

    public Unit[] GetSelectedUnits() 
        => _selectedUnits.ToArray();

    public void Awake()
    {
        _camera = Camera.main;
        _player = GetComponent<Player>();
    }

    public void Update()
    {
        // If left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //start selectionBox
            var mousePosition = Input.mousePosition;
            
            _selectionStartPosition = mousePosition;
            
            // deselect all current selected units
            ToggleSelectedUnits();
            _selectedUnits.Clear();

            TrySelect(mousePosition);
        }

        // If we have released the left mouse button
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseSelectionBox();
        }
        
        // If the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            UpdateSelectionBox(Input.mousePosition);
        }
    }

    private void TrySelect(Vector2 mousePosition)
    {
        var ray = _camera.ScreenPointToRay(mousePosition);
        
        // Have we clicked on a unit?
        if (!Physics.Raycast(ray, out var rayCastHit, 100, unitLayerMask))
            return;

        // "Select" that uni
        var unit = rayCastHit.collider.GetComponent<Unit>();
        
        // Is this "my" unit
        if (!_player.IsMyUnit(unit))
            return;

        SelectUnit(unit);
    }
    
    // called when we are creating a selection box
    private void UpdateSelectionBox (Vector2 curMousePos)
    {
        if(!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);

        var width = curMousePos.x - _selectionStartPosition.x;
        var height = curMousePos.y - _selectionStartPosition.y;

        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = _selectionStartPosition + new Vector2(width / 2, height / 2);
    }
    
    // called when we release the selection box
    private void ReleaseSelectionBox ()
    {
        selectionBox.gameObject.SetActive(false);

        var min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        var max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        foreach (var unit in from unit in _player.Units 
            let screenPos = _camera.WorldToScreenPoint(unit.transform.position) 
            where screenPos.x > min.x && screenPos.x < max.x 
                                      && screenPos.y > min.y && screenPos.y < max.y 
            select unit)
        {
            SelectUnit(unit);
        }
    }

    private void SelectUnit(Unit unit)
    {
        _selectedUnits.Add(unit);
        unit.SetSelected(true);
    }

    private void ToggleSelectedUnits()
    {
        foreach (var unit in _selectedUnits)
        {
            unit.SetSelected(false);
        }
    }
}

using UnityEngine;

public class HexManager : MonoBehaviour
{
    private MeshRenderer _renderer;
    private HexSelector _hexSelector;

    public void Awake()
    {
        _renderer = GetComponentInChildren<MeshRenderer>();
        _hexSelector = GetComponentInChildren<HexSelector>(true);
    }

    public Vector3 GetCenterPosition() 
        => _renderer.bounds.center;

    public void IsBeingHovered(bool isBeingHovered)
    {
        _hexSelector.SetActive(isBeingHovered);
    }
}

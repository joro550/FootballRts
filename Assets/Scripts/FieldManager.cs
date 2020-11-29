using System.Linq;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public HexManager[] _hexManagers;

    public void Awake()
    {
        // Get Components
        _hexManagers = GetComponentsInChildren<HexManager>();
    }

    public HexManager GetClosestHex(Vector3 clickPosition)
    {
        var hexManager = _hexManagers.FirstOrDefault();

        foreach (var manager in _hexManagers)
        {
            var curDistance = Vector3.Distance(hexManager.transform.position, clickPosition);
            var newDistance = Vector3.Distance(manager.transform.position, clickPosition);

            if (newDistance < curDistance)
            {
                hexManager = manager;
            }
        }

        return hexManager;
    }    
}

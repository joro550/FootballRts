using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Unit> Units = new List<Unit>();

    public bool IsMyUnit(Unit unit) 
        => Units.Contains(unit);
}

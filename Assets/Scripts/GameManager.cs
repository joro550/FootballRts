using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _passMode;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null) 
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool GetPassMode() 
        => _passMode;

    public void InvertPassMode() 
        => _passMode = !_passMode;
}

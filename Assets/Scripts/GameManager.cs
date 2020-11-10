using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject red_square;
    public List<GameObject> snake = new List<GameObject>();
    public Vector2 direction = new Vector2(0.0f, 1.0f);
    public GameObject apple_prefab;
    public GameObject apple;
    
    private void Awake()
    {
        apple = Instantiate(apple_prefab);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

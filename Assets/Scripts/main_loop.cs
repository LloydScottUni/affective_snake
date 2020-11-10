using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class main_loop : MonoBehaviour
{

    
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1 / speed;
        GameManager.Instance.snake.Add(Instantiate(GameManager.Instance.red_square));
        GameManager.Instance.apple.transform.position = new Vector3(Random.Range(0, 19) + 0.5f, Random.Range(0, 19) + 0.5f, 0.0f);
        GameManager.Instance.snake[0].transform.position = new Vector3(0.5f,0.5f,0.0f);
        GameManager.Instance.snake[0].tag = "SnakeHead";

        InvokeRepeating("MoveSnake", speed, speed);
    }
    void MoveSnake()
    {
        Vector3 prevPos = GameManager.Instance.snake[0].transform.position;
        for (int i = 0; i < GameManager.Instance.snake.Count; i++)
        {
            if (i == 0)
            {
                GameManager.Instance.snake[i].transform.position = new Vector3(GameManager.Instance.snake[i].transform.position.x + GameManager.Instance.direction.x,
                    GameManager.Instance.snake[i].transform.position.y + GameManager.Instance.direction.y, GameManager.Instance.snake[i].transform.position.z);
            }
            else
            {
                Vector3 tempPos = GameManager.Instance.snake[i].transform.position;
                GameManager.Instance.snake[i].transform.position = prevPos;
                prevPos = tempPos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.snake.Add(Instantiate(GameManager.Instance.red_square, GameManager.Instance.snake[GameManager.Instance.snake.Count - 1].transform.position - new Vector3(GameManager.Instance.direction.x * -1, GameManager.Instance.direction.y * -1, 0.0f), GameManager.Instance.red_square.transform.rotation));
        }
        
        if (GameManager.Instance.direction.x != 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                GameManager.Instance.direction.y = 1;
                GameManager.Instance.direction.x = 0;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                GameManager.Instance.direction.y = -1;
                GameManager.Instance.direction.x = 0;
            }
        }
        else if (GameManager.Instance.direction.x == 0) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameManager.Instance.direction.x = -1;
                GameManager.Instance.direction.y = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                GameManager.Instance.direction.x = 1;
                GameManager.Instance.direction.y = 0;
            }
        }
        
        
    }
}

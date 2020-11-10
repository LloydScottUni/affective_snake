using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class HeadCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("SnakeHead") && other.gameObject.CompareTag("Apple"))
        { 
            GameManager.Instance.snake.Add(Instantiate(GameManager.Instance.red_square, GameManager.Instance.snake[GameManager.Instance.snake.Count - 1].transform.position - new Vector3(GameManager.Instance.direction.x * -1, GameManager.Instance.direction.y * -1, 0.0f), GameManager.Instance.red_square.transform.rotation));
            GameManager.Instance.apple.transform.position = new Vector3(Random.Range(0, 19) + 0.5f, Random.Range(0, 19) + 0.5f, 0.0f);

        }
    }
}

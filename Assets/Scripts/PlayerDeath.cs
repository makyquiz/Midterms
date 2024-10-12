using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }
}
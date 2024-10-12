using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Color bulletColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            Color enemyColor = other.GetComponent<Renderer>().material.color;

            if (enemyColor == bulletColor)
            {
                Destroy(other.gameObject);
                Debug.Log("Enemy Destroyed!"); 
            }

            Destroy(gameObject);
        }
    }
}
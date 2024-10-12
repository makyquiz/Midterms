using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangePlayer : MonoBehaviour
{
    private Renderer playerRenderer;
    private Color[] colors = { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 0;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        ChangeColor();  
    }

    void OnMouseDown()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        ChangeColor();
    }

    void ChangeColor()
    {
        if (playerRenderer != null)
        {
            playerRenderer.material.color = colors[currentColorIndex]; 
        }
        else
        {
            Debug.LogError("Player renderer is not assigned or found.");
        }
    }

    public Color GetCurrentColor()
    {
        return colors[currentColorIndex]; 
    }
}
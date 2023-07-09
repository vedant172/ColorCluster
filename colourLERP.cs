using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colourLERP : MonoBehaviour
{
    public Text nameText;
    public float speed = 1.0f;
    public Color Start_colour;
    public Color endcolour;
    public bool repeatable = true;
    float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (!repeatable)
        {
            float t = (Time.time - startTime) * speed;
            nameText.color = Color.Lerp(Start_colour, endcolour, t);
        }

        else
        {
            float t = (Time.time - startTime) * speed;
            nameText.color = Color.Lerp(Start_colour, endcolour, t);
        }

    }

}


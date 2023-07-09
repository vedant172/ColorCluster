using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random_text : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public float timer = 0f;
    public float speed = 4f;
    public int SpeedIndexCounter = 0;
    public float time_index = 0f;
    public int key = 0;
    public int PreKey = 0;
    public int KeyColor = 0;
    public int PreKeyColor = 0;
    public Button[] button;
    public int TextColourKey = 0;
    //public int PressKey = 0;

    void Start()
    {
       PickRandomList();
    }
    
    public void  RandomColor()
    {
        //key = Mathf.FloorToInt(Random.value * 6);
        key = Random.Range(0, 5);
        if(PreKey==key)
        {
            RandomColor();
        }
        switch (key)
        {
            case 0:
                text.color = Color.red;
                break;
            case 1:
                text.color = Color.blue;
                break;
            case 2:
                text.color = Color.green;
                break;
            case 3:
                text.color = new Color(1.0f, 0.5f, 0.0f);//orange
                break;
            case 4:
                text.color = Color.yellow;
                break;
            case 5:
                text.color = new Color(0.8f, 0.0f, 0.8f);//purple
                break;
        }
        PreKey = key;
    }

    public void PickRandomList()
    {
        TextColourKey = -1;
        string[] colour = new string[] { "RED", "BLUE", "PINK", "YELLOW", "GREEN", "VIOLATE", "ORANGE" ,"BLACK" };
        KeyColor = Random.Range(0, colour.Length);

        if(PreKeyColor==KeyColor)
        {
            PickRandomList();
        }
        SpeedIndexCounter++;
        CheckSpeed();
        //Debug.Log("Colour" + " " + colour[KeyColor] +" IND :" + KeyColor);
        string colourName = colour[KeyColor];
        PreKeyColor = KeyColor;

        text.text = colourName;
        RandomColor();
        //text.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        
    }

    //public void Press()
    //{
    //    PressKey = 1;
    //}

    public void RED()
    {
        TextColourKey = 0;
    }

    public void BLUE()
    {
        TextColourKey = 1;
    }

    public void PINK()
    {
        TextColourKey = 2;
    }

    public void YELLOW()
    {
        TextColourKey = 3;
    }

    public void GREEN()
    {
        TextColourKey = 4;
    }

    public void VIOLATE()
    {
        TextColourKey = 5;
    }

    public void ORANGE()
    {
        TextColourKey = 6;
    }

    public void BLACK()
    {
        TextColourKey = 7;
    }
    public void ChecKey()
    {
       // Debug.Log(TextColourKey);
        //Debug.Log(KeyColor);

        if(KeyColor!= TextColourKey)
        {
            if(TextColourKey == -1)
            {
                Debug.Log("MISS");
            }
            
            else
            {
               
                Debug.Log("WRONG");
                PickRandomList();
            }
        }

        else
        {
            Debug.Log("HIT");
            time_index = timer;
            PickRandomList();
        }
    }

    public void CheckSpeed()
    {
        if (SpeedIndexCounter == 2 && speed - 0.1f > 0.5f)
        {
            speed = speed - 0.1f;
            SpeedIndexCounter = 0;
            Debug.Log("Spedd: " + speed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if( timer - time_index >= speed && timer - time_index < speed+1 )
        {
            time_index = timer;
            PickRandomList();
           
            if(TextColourKey == -1)
            {
                ChecKey();
            }
            //PressKey = 0;
        }
      
       
    }
}



//function RandomColor()
//{

//    var col;
//    c = Mathf.FloorToInt(Random.value * 6);
//    switch (c)
//    {
//        case 0:
//            col = Color.red;
//            break;
//        case 1:
//            col = Color.blue;
//            break;
//        case 2:
//            col = Color.green;
//            break;
//        case 3:
//            col = Color(1.0, 0.5, 0.0);//orange
//            break;
//        case 4:
//            col = Color.yellow;
//            break;
//        case 5:
//            col = Color(0.8, 0.0, 0.8);//purple
//            break;
//    }
//    return col;
//}


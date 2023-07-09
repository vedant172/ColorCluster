using UnityEngine;
using UnityEngine.UI;

public class Colour_lerp: MonoBehaviour
{
    private Color[] arrColor1 = {Color.red , Color.blue ,Color.green, new Color(0.0801f, 1, 0.96357f, 1), new Color32(254, 0, 129, 255),
    new Color(0.8f, 0.0f, 0.8f), new Color(1.0f, 0.5f, 0.0f),Color.white  , Color.white ,Color.white ,Color.white, Color.white};

    private Color[] arrColor = {Color.red , new Color(0.0801f, 1, 0.96357f, 1)  ,Color.blue ,new Color(0.0801f, 1, 0.96357f, 1) , Color.green,new Color(0.0801f, 1, 0.96357f, 1) , Color.yellow
            ,new Color(0.0801f, 1, 0.96357f, 1) , new Color32(254, 0, 129, 255),new Color(0.0801f, 1, 0.96357f, 1),
    new Color(0.8f, 0.0f, 0.8f),new Color(0.0801f, 1, 0.96357f, 1) };

    public Text C,O1,L,O2,R,C2,L2,U,S,T,E,R2;
    private int Key; 
    private float timer = 0f;
    private float speed = 1f;
    private float time_index = 0f;
    private float r = 0.2f, g = 0.3f, b = 0.7f, a = 0.6f;

    private void Start()
    {
        /*
        arrColor[0] = Color.red;      
        arrColor[1] = Color.blue;
        arrColor[2] = Color.yellow;
        arrColor[3] = Color.green;
        arrColor[4] = new Color(0.0801f, 1, 0.96357f, 1);
        */

        Key = Random.Range(0, 5);

        R2.color = arrColor[Key];
        E.color = arrColor[(Key + 1) % 12];
        T.color = arrColor[(Key + 2) % 12];
        S.color = arrColor[(Key + 3) % 12];
        U.color = arrColor[(Key + 4) % 12];
        L2.color = arrColor[(Key + 5) % 12];
        C2.color = arrColor[(Key + 6) % 12];
        R.color = arrColor[(Key + 7) % 12];
        O2.color = arrColor[(Key + 8) % 12];
        L.color = arrColor[(Key + 9) % 12];
        O1.color = arrColor[(Key + 10) % 12];
        C.color = arrColor[(Key + 11) % 12];
    }

    /*
    private void selectRGBA(int Key)
    {
        switch (Key)
        {
            case 0:
                r = 1;
                g = 0;
                b = 0;
                a = 1;
                break;

            case 1:
                r = 0;
                g = 1;
                b = 0;
                a = 1;
                break;

            case 2:
                r = 1;
                g = 0.92f;
                b = 0.016f;
                a = 1;
                break;

            case 3:
                r = 0.2f;
                g = 0.3f;
                b = 0.4f;
                a = 1;
                break;

            case 4:
                r = 0.0801f;
                g = 1;
                b = 0.96357f;
                a = 1;
                break;
      
        };
    }
    */
    private void Update()
    {
        timer = timer + Time.deltaTime;

        if(timer - time_index >=speed)
        {
            time_index = timer;
            Key++;
            R2.color = arrColor[Key%12];
            E.color = arrColor[(Key + 1) % 12];
            T.color = arrColor[(Key + 2) % 12];
            S.color = arrColor[(Key + 3) % 12];
            U.color = arrColor[(Key + 4) % 12];
            L2.color = arrColor[(Key + 5) % 12];
            C2.color = arrColor[(Key + 6) % 12];
            R.color = arrColor[(Key + 7) % 12];
            O2.color = arrColor[(Key + 8) % 12];
            L.color = arrColor[(Key + 9) % 12];
            O1.color = arrColor[(Key + 10) % 12];
            C.color = arrColor[(Key + 11) % 12];
        }

    }

}

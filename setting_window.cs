using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting_window : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    public void open()
    {
        transform.localScale = Vector2.zero;
        transform.LeanScale(Vector2.one, 0.8f);
    }

    public void close()
    {
       
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager2 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Audio2;
    public AudioClip Click2;
    public static SFXmanager2 sfxInstance2;
    public bool musicToggle2 = true; 
    private void Awake()
    {
        if (sfxInstance2 != null && sfxInstance2 != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance2 = this;
        DontDestroyOnLoad(this);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Audio;
    public AudioClip Click;
    public static SFXmanager sfxInstance;
    public bool musicToggle = true; 
    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);

    }

}

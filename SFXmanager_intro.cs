using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager_intro : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Audio_intro;
    public AudioClip Click_intro;
    public static SFXmanager_intro sfxInstance_intro;
    public bool musicToggle_intro = true; 
    private void Awake()
    {
        if (sfxInstance_intro != null && sfxInstance_intro != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance_intro = this;
        DontDestroyOnLoad(this);

    }

}

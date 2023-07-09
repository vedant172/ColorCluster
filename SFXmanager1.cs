using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Audio1;
    public AudioClip Click1;
    public static SFXmanager1 sfxInstance1;
    public bool musicToggle1 = true; 
    private void Awake()
    {
        if (sfxInstance1 != null && sfxInstance1 != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance1 = this;
        DontDestroyOnLoad(this);

    }

}

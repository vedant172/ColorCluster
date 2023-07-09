using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_music_script : MonoBehaviour
{
    public static back_music_script BgInstance;
    // Start is called before the first frame update
    public AudioSource Audio;
    private void Awake()
    {
        if(BgInstance!=null && BgInstance!=this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this );
        
        
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>(); 
    }

}

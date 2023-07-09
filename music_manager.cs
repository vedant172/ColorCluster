using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music_manager : MonoBehaviour
{
   // private Intro intro_scene;
    public Button music_mute_button;
    public Sprite music_mute_img;
    public Sprite music_unmute_img;

    public Button SFX_mute_button;
    public Sprite SFX_mute_img;
    public Sprite SFX_unmute_img;
   

    private void Start()
    {
        
       // if (back_music_script.BgInstance.Audio.isPlaying)
        //{        
        //    music_mute_button.image.sprite = music_unmute_img;
        //}

        //else
        //{
         //   music_mute_button.image.sprite = music_mute_img;
       // }

     //   if(SFXmanager.sfxInstance.musicToggle==true)
      //  {
       //     SFX_mute_button.image.sprite = SFX_unmute_img;
       // }

       // else
       // {
      //      SFX_mute_button.image.sprite = SFX_mute_img;
      //  }

        //music
        if(!PlayerPrefs.HasKey("MusicKey"))
        {
            PlayerPrefs.SetInt("MusicKey", 1);
        }

        if(!PlayerPrefs.HasKey("SFXKey"))
        {
            PlayerPrefs.SetInt("SFXKey", 1);
        }

        if (!PlayerPrefs.HasKey("SFXKey1"))
        {
            PlayerPrefs.SetInt("SFXKey1", 1);
        }

        if (!PlayerPrefs.HasKey("SFXKey2"))
        {
            PlayerPrefs.SetInt("SFXKey2", 1);
        }



        if (PlayerPrefs.GetInt("MusicKey")==1)
        {
            music_mute_button.image.sprite = music_unmute_img;
            back_music_script.BgInstance.Audio.Play();
        }

        else
        {
            back_music_script.BgInstance.Audio.Pause();
            music_mute_button.image.sprite = music_mute_img;
        }

        //SFX
        if (PlayerPrefs.GetInt("SFXKey")==1)
        {
            SFXmanager.sfxInstance.musicToggle = true;
            SFX_mute_button.image.sprite = SFX_unmute_img;
        }

        else
        {
            SFXmanager.sfxInstance.musicToggle = false;
            SFX_mute_button.image.sprite = SFX_mute_img;
        }

        //SFX1
        if (PlayerPrefs.GetInt("SFXKey1") == 1)
        {
            SFXmanager1.sfxInstance1.musicToggle1 = true;        
        }

        else
        {
            SFXmanager1.sfxInstance1.musicToggle1 = false;         
        }

        //SFX2
        
        if (PlayerPrefs.GetInt("SFXKey2") == 1)
        {
            SFXmanager2.sfxInstance2.musicToggle2 = true;
        }

        else
        {
            SFXmanager2.sfxInstance2.musicToggle2 = false;
        }

       
       
    }

    public void SFXToggle()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);

        if (SFXmanager.sfxInstance.musicToggle == true)
        {
            SFXmanager1.sfxInstance1.musicToggle1 = false;
            PlayerPrefs.SetInt("SFXKey1", 0);

            SFXmanager2.sfxInstance2.musicToggle2 = false;
            PlayerPrefs.SetInt("SFXKey2", 0);

            SFXmanager.sfxInstance.musicToggle = false;
            SFX_mute_button.image.sprite = SFX_mute_img;
            PlayerPrefs.SetInt("SFXKey", 0);
        }

        else
        {        
            SFXmanager2.sfxInstance2.musicToggle2 = true;
            PlayerPrefs.SetInt("SFXKey2", 1);

            SFXmanager1.sfxInstance1.musicToggle1 = true;
            PlayerPrefs.SetInt("SFXKey1", 1);

            SFXmanager.sfxInstance.musicToggle = true;
            SFX_mute_button.image.sprite = SFX_unmute_img;
            PlayerPrefs.SetInt("SFXKey", 1);
        }

        //sfx 1
       /*
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
        {
            SFXmanager1.sfxInstance1.musicToggle1 = false;         
            PlayerPrefs.SetInt("SFXKey1", 0);
        }

        else
        {
            SFXmanager1.sfxInstance1.musicToggle1 = true;          
            PlayerPrefs.SetInt("SFXKey1", 1);
        }
       */

    }
    public void MusicToggle()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        if (back_music_script.BgInstance.Audio.isPlaying)
        {
            back_music_script.BgInstance.Audio.Pause();
            music_mute_button.image.sprite = music_mute_img;
            PlayerPrefs.SetInt("MusicKey", 0);
        }

        else
        {
            music_mute_button.image.sprite = music_unmute_img;
            back_music_script.BgInstance.Audio.Play();
            PlayerPrefs.SetInt("MusicKey", 1);
        }

    }

}

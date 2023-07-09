using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class start_scene_manager : MonoBehaviour
{
    public static start_scene_manager instance;
    private int BackButtonKey = 0;
    public Text name_text;
    public GameObject QuitPanel;
    public GameObject MainStartButton;
    public GameObject SettingButtons;
    public Text resolutionn_text;
    // Start is called before the first frame update
    public GameObject CreditPanel;
    private int CreditBackKey=0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        // name_text.text = "<color=blue>COLOUR</color>" + "<color=red> CLUSTER</color>";
        resolutionn_text.text = Screen.currentResolution.ToString();


    }
   
    public void shop_close()
    {
        CreditPanel.SetActive(false);
        MainStartButton.SetActive(true);
        SettingButtons.SetActive(true);
        CreditBackKey = 0;
    }
    public void shop_close_button()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        CreditPanel.SetActive(false);
        MainStartButton.SetActive(true);
        SettingButtons.SetActive(true);
        CreditBackKey = 0;
    }
    public void shop_open()
    {
        CreditBackKey = 1;
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        CreditPanel.SetActive(true);
        MainStartButton.SetActive(false);
        SettingButtons.SetActive(false);
        
    }
    public void Back()
    {
        if (CreditBackKey == 1)
        {
            CreditPanel.SetActive(false);
            MainStartButton.SetActive(true);
            SettingButtons.SetActive(true);
            CreditBackKey = 0;
           // BackButtonKey = 0;
        }

        else
        {
            QuitPanel.SetActive(true);
            MainStartButton.SetActive(false);
            SettingButtons.SetActive(false);
            BackButtonKey = 1;
        }
        
    }

    public void ExitYes()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        Application.Quit();
    }

    
    public void ExitNo()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        QuitPanel.SetActive(false);
        MainStartButton.SetActive(true);
        SettingButtons.SetActive(true);
        BackButtonKey = 0;
    }
   
    // Update is called once per frame
    public void StartButton()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Level_scene");
        
    }

    public void setting_start()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }

    /*
    public void tmepBack()
    {
        if (BackButtonKey == 0)
        {
           // Debug.Log("back click1");
            BackButtonKey = 1;
            Back();
        }

        else if(CreditBackKey==1)
        {
           // Debug.Log("back click2");
            CreditPanel.SetActive(false);
            MainStartButton.SetActive(true);
            SettingButtons.SetActive(true);
            CreditBackKey = 0;
            BackButtonKey = 0;
        }

        else
        {
            //Debug.Log("back click3");
            BackButtonKey = 0;
            QuitPanel.SetActive(false);
            MainStartButton.SetActive(true);
            SettingButtons.SetActive(true);        
        }
    }
    */

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (BackButtonKey == 0)
            {
                // Debug.Log("back click1");
                BackButtonKey = 1;
                Back();
            }

            else if (CreditBackKey == 1)
            {
                // Debug.Log("back click2");
                CreditPanel.SetActive(false);
                MainStartButton.SetActive(true);
                SettingButtons.SetActive(true);
                CreditBackKey = 0;
                BackButtonKey = 0;
            }

            else
            {
                //Debug.Log("back click3");
                BackButtonKey = 0;
                QuitPanel.SetActive(false);
                MainStartButton.SetActive(true);
                SettingButtons.SetActive(true);
            }

        }
    }

}

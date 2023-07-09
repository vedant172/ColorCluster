using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class LM : MonoBehaviour
{
    public GameObject AllImg;
    public Button back_buttonForImg;
    public Image L1_img;
    public Image L2_img;
    public Image L3_img;
    public Image L4_img;
    public Image L5_img;
    public Image L6_img;
    public Image L7_img;
    public Image L8_img;
    public Image L9_img;
    public Image L10_img;
    public Image L11_img;
    public Image L12_img;
    public Image L13_img;
    public Image L14_img;
    public Image L15_img;
    public Image L16_img;
    public Image L17_img;
    public Image L18_img;
    public Image L19_img;
    public Image L20_img;
    public setting_window BackButtonScript;
    public Button[] level_button;
    public Button back_button;
    int HS1,HS2,HS3,HS4,HS5, HS6, HS7, HS8, HS9, HS10, HS11, HS12, HS13, HS14, HS15, HS16, HS17, HS18, HS19, HS20;
    
    public GameObject LevelPanel1;
    public GameObject LevelPanel2;
    public GameObject LevelPanel3;
    public GameObject LevelPanel4;
    public GameObject LevelPanel5;
    public GameObject LevelPanel6;
    public GameObject LevelPanel7;
    public GameObject LevelPanel8;
    public GameObject LevelPanel9;
    public GameObject LevelPanel10;
    public GameObject LevelPanel11;
    public GameObject LevelPanel12;
    public GameObject LevelPanel13;
    public GameObject LevelPanel14;
    public GameObject LevelPanel15;
    public GameObject LevelPanel16;
    public GameObject LevelPanel17;
    public GameObject LevelPanel18;
    public GameObject LevelPanel19;
    public GameObject LevelPanel20;
    public Text highscore1, highscore2, highscore3, highscore4, highscore5, highscore6, highscore7, highscore8;
    public Text highscore9, highscore10, highscore11, highscore12, highscore13, highscore14, highscore15, highscore16;
    public Text highscore17, highscore18, highscore19, highscore20;
    public Text level_text;
    public int BackButtonKey = 0; 


    // Start is called before the first frame update
    void Start()
    {
        back_buttonForImg.gameObject.SetActive(false);
        LevelPanel1.SetActive(false);
        LevelPanel2.SetActive(false);
        LevelPanel3.SetActive(false);
        LevelPanel4.SetActive(false);
        LevelPanel5.SetActive(false);
        LevelPanel6.SetActive(false);
        LevelPanel7.SetActive(false);
        LevelPanel8.SetActive(false);
        LevelPanel9.SetActive(false);
        LevelPanel10.SetActive(false);
        LevelPanel11.SetActive(false);
        LevelPanel12.SetActive(false);
        LevelPanel13.SetActive(false);
        LevelPanel14.SetActive(false);
        LevelPanel15.SetActive(false);
        LevelPanel16.SetActive(false);
        LevelPanel17.SetActive(false);
        LevelPanel18.SetActive(false);
        LevelPanel19.SetActive(false);
        LevelPanel20.SetActive(false);
        level_text.gameObject.SetActive(true);
        for (int i = 0; i < level_button.Length; i++)
        {
            back_button.gameObject.SetActive(true);
            level_button[i].gameObject.SetActive(true);
            level_button[i].interactable =false;
        }
        
        level_button[0].interactable = true;
        HS1 = PlayerPrefs.GetInt("highscore1");
        if (HS1 >=50)level_button[1].interactable = true;

        HS2 = PlayerPrefs.GetInt("highscore1_text_color");
        if (HS2 >= 60) level_button[2].interactable = true;

        HS3 = PlayerPrefs.GetInt("highscore2");
        if (HS3 >= 60) level_button[3].interactable = true;

        HS4 = PlayerPrefs.GetInt("highscore2_text_color");
        if (HS4 >= 70) level_button[4].interactable = true;

        HS5 = PlayerPrefs.GetInt("highscore3");
        if (HS5 >= 70) level_button[5].interactable = true;

        HS6 = PlayerPrefs.GetInt("highscore3_text_color");
        if (HS6 >= 80) level_button[6].interactable = true;

        HS7 = PlayerPrefs.GetInt("highscore4");
        if (HS7 >= 80) level_button[7].interactable = true;

        HS8 = PlayerPrefs.GetInt("highscore4_extra_color");
        if (HS8 >= 90) level_button[8].interactable = true;

        HS9 = PlayerPrefs.GetInt("highscore5");
        if (HS9 >= 90) level_button[9].interactable = true;

        HS10 = PlayerPrefs.GetInt("highscore5_text_color");
        if (HS10 >= 100) level_button[10].interactable = true;

        HS11 = PlayerPrefs.GetInt("highscore6");
        if (HS11 >= 100) level_button[11].interactable = true;

        HS12 = PlayerPrefs.GetInt("highscore6_text_color");
        if (HS12 >= 100) level_button[12].interactable = true;

        HS13 = PlayerPrefs.GetInt("highscore7");
        if (HS13 >= 100) level_button[13].interactable = true;

        HS14 = PlayerPrefs.GetInt("highscore7_text_color");
        if (HS14 >= 100) level_button[14].interactable = true;

        HS15 = PlayerPrefs.GetInt("highscore8");
        if (HS15 >= 100) level_button[15].interactable = true;

        HS16 = PlayerPrefs.GetInt("highscore8_text_color");
        if (HS16 >= 100) level_button[16].interactable = true;

        HS17 = PlayerPrefs.GetInt("highscore9");
        if (HS17 >= 100) level_button[17].interactable = true;

        HS18 = PlayerPrefs.GetInt("highscore9_text_color");
        if (HS18 >= 100) level_button[18].interactable = true;

        HS19 = PlayerPrefs.GetInt("highscore10");
        if (HS19 >= 100) level_button[19].interactable = true;

        HS20 = PlayerPrefs.GetInt("highscore10_text_color");
       // if (HS4 >= 100) level_button[20].interactable = true;

        /*
        ///if(PlayerPrefs.GetInt("IAP_key")==1)
       // {
            level_button[1].interactable = true;
            level_button[2].interactable = true;
            level_button[3].interactable = true;
            level_button[4].interactable = true;
            level_button[5].interactable = true;
            level_button[6].interactable = true;
            level_button[7].interactable = true;
            level_button[8].interactable = true;
            level_button[9].interactable = true;
            level_button[10].interactable = true;
            level_button[11].interactable = true;
            level_button[12].interactable = true;
            level_button[13].interactable = true;
            level_button[14].interactable = true;
            level_button[15].interactable = true;
            level_button[16].interactable = true;
            level_button[17].interactable = true;
            level_button[18].interactable = true;
            level_button[19].interactable = true;
        //}
        */
        
    }
    //public void Back()
    //{
    //    back_button.gameObject.SetActive(true);
    //    level_text.gameObject.SetActive(true);
    //    for (int i = 0; i < level_button.Length; i++)
    //    {
    //        level_button[i].gameObject.SetActive(true);
    //    }

    //     SceneManager.LoadScene("Level_scene");
    //}

    public void start_scene()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        if (BackButtonKey==1)
        {
            SceneManager.LoadScene("Level_scene");
        }

        else SceneManager.LoadScene("start_scene");
        BackButtonKey = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            start_scene();
        }
    }

    public void BackButtonImage()
    {
        AllImg.gameObject.SetActive(false);
        back_buttonForImg.gameObject.SetActive(false);
        
    }

    public void level_panel1()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i=0; i<level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }       
        highscore1.text = "High Score:" + PlayerPrefs.GetInt("highscore1");
        LevelPanel1.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle==true)
        SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel2()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore2.text = "High Score:" + PlayerPrefs.GetInt("highscore1_text_color");
        LevelPanel2.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel3()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore3.text = "High Score:" + PlayerPrefs.GetInt("highscore2");
        LevelPanel3.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel4()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore4.text = "High Score:" + PlayerPrefs.GetInt("highscore2_text_color");
        LevelPanel4.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel5()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore5.text = "High Score:" + PlayerPrefs.GetInt("highscore3");
        LevelPanel5.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel6()
    {
        BackButtonKey = 1;
        //back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore6.text = "High Score:" + PlayerPrefs.GetInt("highscore3_text_color");
        LevelPanel6.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel7()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore7.text = "High Score:" + PlayerPrefs.GetInt("highscore4");
        LevelPanel7.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel8()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore8.text = "High Score:" + PlayerPrefs.GetInt("highscore4_text_color");
        LevelPanel8.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel9()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore9.text = "High Score:" + PlayerPrefs.GetInt("highscore5");
        LevelPanel9.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel10()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore10.text = "High Score:" + PlayerPrefs.GetInt("highscore5_text_color");
        LevelPanel10.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel11()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore11.text = "High Score:" + PlayerPrefs.GetInt("highscore6");
        LevelPanel11.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel12()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore12.text = "High Score:" + PlayerPrefs.GetInt("highscore6_text_color");
        LevelPanel12.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel13()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore13.text = "High Score:" + PlayerPrefs.GetInt("highscore7");
        LevelPanel13.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel14()
    {
        BackButtonKey = 1;
        //back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore14.text = "High Score:" + PlayerPrefs.GetInt("highscore7_text_color");
        LevelPanel14.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel15()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore15.text = "High Score:" + PlayerPrefs.GetInt("highscore8");
        LevelPanel15.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel16()
    {
        BackButtonKey = 1;
        //back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore16.text = "High Score:" + PlayerPrefs.GetInt("highscore8_text_color");
        LevelPanel16.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel17()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore17.text = "High Score:" + PlayerPrefs.GetInt("highscore9");
        LevelPanel17.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel18()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore18.text = "High Score:" + PlayerPrefs.GetInt("highscore9_text_color");
        LevelPanel18.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel19()
    {
        BackButtonKey = 1;
        // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore19.text = "High Score:" + PlayerPrefs.GetInt("highscore10");
        LevelPanel19.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }
    public void level_panel20()
    {
        BackButtonKey = 1;
       // back_button.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
        for (int i = 0; i < level_button.Length; i++)
        {
            level_button[i].gameObject.SetActive(false);
        }
        highscore20.text = "High Score:" + PlayerPrefs.GetInt("highscore10_text_color");
        LevelPanel20.SetActive(true);
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
    }

    public void Level_1()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part1");
    }
    public void Level_2()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part1_text_color");
    }
    public void Level_3()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part2");
    }
    public void Level_4()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part2_text_color");
    }
    public void Level_5()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part3");
    }
    public void Level_6()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part3_text_color");
    }
    public void Level_7()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part4");
    }
    public void Level_8()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part4_extra_color");
    }
    public void Level_9()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part5");
    }
    public void Level_10()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part5_text_color");
    }
    public void Level_11()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part6");
    }
    public void Level_12()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part6_text_color");
    }
    public void Level_13()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part7");
    }
    public void Level_14()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part7_text_color");
    }
    public void Level_15()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part8");
    }
    public void Level_16()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part8_text_color");
    }
    public void Level_17()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part9");
    }
    public void Level_18()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part9_text_color");
    }
    public void Level_19()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part10");
    }
    public void Level_20()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part10_text_color");
    }
    // Update is called once per frame
    public void demo1()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L1_img.gameObject.SetActive(true);
    }

    public void demo2()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L2_img.gameObject.SetActive(true);
    }

    public void demo3()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L3_img.gameObject.SetActive(true);      
    }

    public void demo4()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L4_img.gameObject.SetActive(true);
      
    }

    public void demo5()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L5_img.gameObject.SetActive(true);
        
    }

    public void demo6()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L6_img.gameObject.SetActive(true);
    }

    public void demo7()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L7_img.gameObject.SetActive(true);     
    }

    public void demo8()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L8_img.gameObject.SetActive(true);       
    }
    public void demo9()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L9_img.gameObject.SetActive(true);       
    }
    public void demo10()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L10_img.gameObject.SetActive(true);       
    }

    public void demo11()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L11_img.gameObject.SetActive(true);       
    }

    public void demo12()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L12_img.gameObject.SetActive(true);      
    }

    public void demo13()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L13_img.gameObject.SetActive(true);      
    }

    public void demo14()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L14_img.gameObject.SetActive(true);      
    }

    public void demo15()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L15_img.gameObject.SetActive(true);
        
    }
    public void demo16()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L16_img.gameObject.SetActive(true);
        
    }
    public void demo17()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L17_img.gameObject.SetActive(true);    
    }
    public void demo18()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L18_img.gameObject.SetActive(true);    
    }
    public void demo19()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L19_img.gameObject.SetActive(true);      
    }
    public void demo20()
    {
        AllImg.gameObject.SetActive(true);
        back_buttonForImg.gameObject.SetActive(true);
        L20_img.gameObject.SetActive(true);     
    }


}

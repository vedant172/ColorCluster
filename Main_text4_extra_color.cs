using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Main_text4_extra_color : MonoBehaviour
{
    public GameObject AdButton;
    int Adcount = 0;
    public Text CN1;  //ch
    public Text CN2;
    int HSNext;             //ch
    public Text Next_text;
    public GameObject ContinuePanel;    //Ch
    public static Main_text4_extra_color instance;
    public Text TutorialText;
    private int PusePanelKey = 0;
    public GameObject Arrows;       //ch
    public GameObject Arrow_r1;
    public GameObject Arrow_b1;
    public GameObject Arrow_y1;
    public GameObject Arrow_g1;
    public GameObject Arrow_o1;
    public GameObject Arrow_p1;
    public GameObject Arrow_v1;
    public GameObject Arrow_r2;
    public GameObject Arrow_b2;
    public GameObject Arrow_y2;
    public GameObject Arrow_g2;
    public GameObject Arrow_o2;
    public GameObject Arrow_p2;
    public GameObject Arrow_v2;

    private int arrowKey = 0;

    public setting_window panel_script;
    public GameObject PausePanel;
    public Button PauseButton;
    public Text text;
    public Text HighScoreText; 
    public Text PresentText;
    public Text Last_score;
    public Text Miss_text;
    public GameObject GameOverPanel;
    public int Score = 0;
    public int MissCount = 0;
    public int HighScore = 0;
    public float timer = 0f;
    public float speed = 4f;
    public int SpeedIndexCounter = 0;
    public float time_index = 0f;
    public int key = 0;
    public int PreKey = 0;
    public int KeyColor = 0;
    public int PreKeyColor = 0;
    public Button[] button;
    public int TextColourKey = 0;
    public int GameOverKey = 0;
    [SerializeField] private Animator text_animation;
    public int Random_num_text_number = 0;
    public int text_color_key = 0; // for color of text

    void Start()
    {

        PausePanel.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        Miss_text.text = "";
        PresentText.text = "";
        GameOverPanel.SetActive(false);
        PickRandomList();

        Arrows.SetActive(true);         //ch
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        Next_text.enabled = false;      //ch
    }

    public void Next() //ch
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        HSNext = PlayerPrefs.GetInt("highscore4_extra_color");
        if (HSNext >= 90)
        {
            SceneManager.LoadScene("Part5");
        }

        else
        {
            Next_text.enabled = true;
            StartCoroutine(Next_Text_manage());
        }

    }
    private IEnumerator Next_Text_manage()   //ch
    {
        yield return new WaitForSeconds(3);
        Next_text.enabled = false;
    }
    private void Awake()    //Ch
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
    public void Reward()   //Ch
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        Adcount++;
        if (Score <= 3)         //ch
        {
            Arrows.SetActive(true);
        }
        ContinuePanel.SetActive(false);
        GameOverPanel.SetActive(false);
       
        text.enabled = true;
        Miss_text.enabled = true;        //ch
        PresentText.enabled = true;
        CN1.enabled = true;
        CN2.enabled = true;

        if (Score <= 3)
        {
            TutorialText.enabled = true;
        }
        button[0].enabled = true;
        button[1].enabled = true;
        button[2].enabled = true;
        button[3].enabled = true;
        button[4].enabled = true;
        button[5].enabled = true;
        button[6].enabled = true;
        button[7].enabled = true;
        button[8].enabled = true;
        button[9].enabled = true;
        button[10].enabled = true;
        button[11].enabled = true;
        button[12].enabled = true;
        button[13].enabled = true;
        PauseButton.gameObject.SetActive(true);
        GameOverKey = 0;
        PresentText.text = "";
        Miss_text.enabled = true;
        MissCount = 0;
    }

    public void Restart()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part4_extra_color");
    }
    public void Back()    //Ch
    {
        if (GameOverKey == 1)
        {
            SceneManager.LoadScene("Level_scene");
        }

        else if (PusePanelKey == 1)
        {
            if (Score <= 3)
            {
                Arrows.SetActive(true);
            }
            text.enabled = true;
            button[0].enabled = true;
            button[1].enabled = true;
            button[2].enabled = true;
            button[3].enabled = true;
            button[4].enabled = true;
            button[5].enabled = true;
            button[6].enabled = true;
            button[7].enabled = true;
            button[8].enabled = true;
            button[9].enabled = true;
            button[10].enabled = true;
            button[11].enabled = true;
            button[12].enabled = true;
            button[13].enabled = true;

            PauseButton.gameObject.SetActive(true);
            PausePanel.SetActive(false);
            PusePanelKey = 0;
            Time.timeScale = 1f;
        }
        else
        {
            Arrows.SetActive(false);
            text.enabled = false;
            button[0].enabled = false;
            button[1].enabled = false;
            button[2].enabled = false;
            button[3].enabled = false;
            button[4].enabled = false;
            button[5].enabled = false;
            button[6].enabled = false;
            button[7].enabled = false;
            button[8].enabled = false;
            button[9].enabled = false;
            button[10].enabled = false;
            button[11].enabled = false;
            button[12].enabled = false;
            button[13].enabled = false;

            PauseButton.gameObject.SetActive(false);
            PausePanel.SetActive(true);
            PusePanelKey = 1;
            Time.timeScale = 0f;
            //SceneManager.LoadScene("Level_scene");
        }
    }

    public void BackButton()        //ch
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Level_scene");
    }

    public void  RandomColor()
    {
        key = Random.Range(0, 7);
        if(PreKey==key)
        {
            RandomColor();
        }
        text_color_key = key;
        arrowKey = text_color_key;
        if (Random_num_text_number == 2)
        {
            arrowKey = arrowKey + 7;
        }
        switch (key)
        {
            case 0:
                text.color = Color.red;
                break;
            case 1:
                text.color = Color.blue;
                break;
            case 2:
                text.color = Color.yellow;
                break;
            case 3:
                text.color = Color.green;
                break;
            case 4:
                text.color = new Color32(254, 0, 129, 255);//pink
                break;
            case 5:
                text.color = new Color(0.8f, 0.0f, 0.8f);//purple
                break;
            case 6:
                text.color = new Color(1.0f, 0.5f, 0.0f);//orange
                break;
        }
        PreKey = key;
    }

    public void PickRandomList()
    {
        TextColourKey = -1;
        //string[] colour = new string[] { "RED", "BLUE",  "YELLOW", "GREEN", "PINK", "VIOLATE", "ORANGE" };
        //KeyColor = Random.Range(0, colour.Length);
        Random_num_text_number = Random.Range(1, 3);
        //if(PreKeyColor==KeyColor)
        //{
        //    PickRandomList();
        //}

        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);

        SpeedIndexCounter++;
        CheckSpeed();
        
       // string colourName = colour[KeyColor];
        //PreKeyColor = KeyColor;

        text.text = Random_num_text_number.ToString();
        RandomColor();        
    }
    public void RED_1()
    {
        TextColourKey = 0;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void BLUE_1()
    {
        TextColourKey = 1;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void YELLOW_1()
    {
        TextColourKey = 2;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void GREEN_1()
    {
        TextColourKey = 3;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void PINK_1()
    {
        TextColourKey = 4;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void VIOLATE_1()
    {
        TextColourKey = 5;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void ORANGE_1()
    {
        TextColourKey = 6;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void RED_2()
    {
        TextColourKey = 7;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void BLUE_2()
    {
        TextColourKey = 8;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void YELLOW_2()
    {
        TextColourKey = 9;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void GREEN_2()
    {
        TextColourKey = 10;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void PINK_2()
    {
        TextColourKey = 11;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void VIOLATE_2()
    {
        TextColourKey = 12;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void ORANGE_2()
    {
        TextColourKey = 13;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_o1.SetActive(false);
        Arrow_p1.SetActive(false);
        Arrow_v1.SetActive(false);

        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Arrow_o2.SetActive(false);
        Arrow_p2.SetActive(false);
        Arrow_v2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }
    public void GameOver()
    {
        if (SFXmanager2.sfxInstance2.musicToggle2 == true)                         //ch
            SFXmanager2.sfxInstance2.Audio2.PlayOneShot(SFXmanager2.sfxInstance2.Click2);
        Arrows.SetActive(false);          //ch
        PauseButton.gameObject.SetActive(false);
      
        GameOverKey = 1;
        Last_score.text = "SCORE: " + Score;
        if (PlayerPrefs.GetInt("highscore4_extra_color") < Score)
        {
            PlayerPrefs.SetInt("highscore4_extra_color", Score);
        }
        HighScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highscore4_extra_color");
       
        GameOverPanel.SetActive(true);
        panel_script.open();
       
        text.enabled = false;
        Miss_text.enabled = false;       //ch
        PresentText.enabled = false;
        TutorialText.enabled = false;
        CN1.enabled = false;
        CN2.enabled = false;
        button[0].enabled = false;
        button[1].enabled = false;
        button[2].enabled = false;
        button[3].enabled = false;
        button[4].enabled = false;
        button[5].enabled = false;
        button[6].enabled = false;
        button[7].enabled = false;
        button[8].enabled = false;
        button[9].enabled = false;
        button[10].enabled = false;
        button[11].enabled = false;
        button[12].enabled = false;
        button[13].enabled = false;
       
    }

    public void ChecKey()
    {
        PresentText.text = "";
        if (Random_num_text_number == 2)
        {
            text_color_key = text_color_key + 7;
        }

        if (text_color_key != TextColourKey)
        {
            if(TextColourKey == -1)
            {
                text_animation.SetBool("zadu", true);
                MissCount++;
                Miss_text.text = "MISS: " + MissCount;             
                if(MissCount>=5)
                {                  
                    GameOver();
                }
            }
            
            else
            {
                PresentText.text = "WRONG";
                Miss_text.enabled = false;              
                GameOver();
                PickRandomList();
            }
        }

        else
        {
            Score++;
            PresentText.text = "HIT: " + Score;
            time_index = timer;
            PickRandomList();
        }
       
    }

    public void CheckSpeed()
    {
        if (SpeedIndexCounter == 2 && speed - 0.1f > 1.5f)  //ch
        {
            speed = speed - 0.1f;
            SpeedIndexCounter = 0;
        }
    }
    public void Resume()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        if (Score <= 3)         //ch
        {
            Arrows.SetActive(true);
        }

        text.enabled = true;
        button[0].enabled = true;
        button[1].enabled = true;
        button[2].enabled = true;
        button[3].enabled = true;
        button[4].enabled = true;
        button[5].enabled = true;
        button[6].enabled = true;
        button[7].enabled = true;
        button[8].enabled = true;
        button[9].enabled = true;
        button[10].enabled = true;
        button[11].enabled = true;
        button[12].enabled = true;
        button[13].enabled = true;

        PauseButton.gameObject.SetActive(true);
        PausePanel.SetActive(false);
        PusePanelKey = 0;           //ch
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        Arrows.SetActive(false);     //ch
        text.enabled = false;
        button[0].enabled = false;
        button[1].enabled = false;
        button[2].enabled = false;
        button[3].enabled = false;
        button[4].enabled = false;
        button[5].enabled = false;
        button[6].enabled = false;
        button[7].enabled = false;
        button[8].enabled = false;
        button[9].enabled = false;
        button[10].enabled = false;
        button[11].enabled = false;
        button[12].enabled = false;
        button[13].enabled = false;

        PauseButton.gameObject.SetActive(false);
        PausePanel.SetActive(true);
        PusePanelKey = 1;             //ch
        Time.timeScale = 0f;
    }

    public void Home()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        Time.timeScale = 1f;
        SceneManager.LoadScene("start_scene");
    }
    // Update is called once per frame
    void Update()
    {
        if (Adcount >= 2)
        {
            AdButton.SetActive(false);
        }
        if (Score <= 3)                                 //ch
        {
            if (arrowKey == 0) Arrow_r1.SetActive(true);
            if (arrowKey == 1) Arrow_b1.SetActive(true);
            if (arrowKey == 2) Arrow_y1.SetActive(true);
            if (arrowKey == 3) Arrow_g1.SetActive(true);
            if (arrowKey == 6) Arrow_o1.SetActive(true);
            if (arrowKey == 4) Arrow_p1.SetActive(true);
            if (arrowKey == 5) Arrow_v1.SetActive(true);

            if (arrowKey == 7) Arrow_r2.SetActive(true);
            if (arrowKey == 8) Arrow_b2.SetActive(true);
            if (arrowKey == 9) Arrow_y2.SetActive(true);
            if (arrowKey == 10) Arrow_g2.SetActive(true);
            if (arrowKey == 13) Arrow_o2.SetActive(true);
            if (arrowKey == 11) Arrow_p2.SetActive(true);
            if (arrowKey == 12) Arrow_v2.SetActive(true);


        }

        if (Score >= 3)                             //ch
        {
            TutorialText.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))       //ch
        {
            Back();
        }
        // Score_text.text = "SCORE : " + Score;
        timer = timer + Time.deltaTime;
        if(GameOverKey==0)
        {
            if (timer - time_index >= speed && timer - time_index < speed + 1)
            {
                time_index = timer;
                PickRandomList();

                if (TextColourKey == -1)
                {
                    ChecKey();
                }

            }
        }
       
    }
}






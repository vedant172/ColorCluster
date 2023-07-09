using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Main_text1 : MonoBehaviour
{
    //setting_window Adset;
    public GameObject AdButton;
    int Adcount = 0;
    int HSNext;             
    public Text Next_text;  

    public setting_window panel_script;
    public Text text;
    public Text HighScoreText; 
    public Text PresentText;
    public Text Last_score;
    public Text Miss_text;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public Button PauseButton;
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
    public GameObject ContinuePanel;
    public static Main_text1 instance;
    public Text TutorialText;
    private int PusePanelKey = 0;
    public GameObject Arrows;      
    public GameObject Arrow_r;
    public GameObject Arrow_b;
    public GameObject Arrow_y;
    public GameObject Arrow_g;
    void Start()
    {
        PausePanel.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        Miss_text.text = "";
        PresentText.text = "";
        PickRandomList();

        Arrows.SetActive(true);       
        Arrow_r.SetActive(false);
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);

        Next_text.enabled = false;      

    }
  
    public void Next() //ch
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        HSNext = PlayerPrefs.GetInt("highscore1");
        if (HSNext >= 50)    
        {
            SceneManager.LoadScene("Part1_text_color");
        }

        else  
        {
            Next_text.enabled = true;       
            StartCoroutine(Next_Text_manage());
        }

    }
    private IEnumerator Next_Text_manage()   
    {     
        yield return new WaitForSeconds(3); 
        Next_text.enabled = false;
    }

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
    public void Reward()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        Adcount++;
        if (Score <= 3)        
        {
            Arrows.SetActive(true);
        }

        ContinuePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        text.enabled = true;

        Miss_text.enabled = true;        
        PresentText.enabled = true;
        if (Score <= 3)
        {
            TutorialText.enabled = true;
        }

        button[0].enabled = true;
        button[1].enabled = true;
        button[2].enabled = true;
        button[3].enabled = true;

        PauseButton.gameObject.SetActive(true);
        GameOverKey = 0;
        PresentText.text = "";
        MissCount = 0;
    }
    public void Restart()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part1");
    }

    public void Back()
    {
        if(GameOverKey==1)
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

            PauseButton.gameObject.SetActive(false);
            PausePanel.SetActive(true);
            PusePanelKey = 1;
            Time.timeScale = 0f;     
        }     
    }

    public void BackButton()        
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Level_scene");
    }

    public void  RandomColor()
    {
        key = Random.Range(0, 4);
        if(PreKey==key)
        {
            RandomColor();
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
        }
        PreKey = key;
    }

    public void PickRandomList()
    {
        TextColourKey = -1;
        string[] colour = new string[] { "RED", "BLUE",  "YELLOW", "GREEN" };
        KeyColor = Random.Range(0, colour.Length);

        Arrow_r.SetActive(false);
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);

        if (PreKeyColor==KeyColor)
        {
            PickRandomList();
        }

        SpeedIndexCounter++;
        CheckSpeed();
       
        string colourName = colour[KeyColor];
        PreKeyColor = KeyColor;
       
        text.text = colourName;
        RandomColor();        
    }
    public void RED()
    {
        TextColourKey = 0;
        Arrow_r.SetActive(false);
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void BLUE()
    {
        TextColourKey = 1;
        Arrow_r.SetActive(false);
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void YELLOW()
    {
        TextColourKey = 2;
        Arrow_r.SetActive(false);
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void GREEN()
    {
        TextColourKey = 3;
        Arrow_r.SetActive(false);
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void GameOver()
    {
       
        if (SFXmanager2.sfxInstance2.musicToggle2 == true)                         //ch
            SFXmanager2.sfxInstance2.Audio2.PlayOneShot(SFXmanager2.sfxInstance2.Click2);
        Arrows.SetActive(false);        
        PauseButton.gameObject.SetActive(false);
        GameOverKey = 1;
        Last_score.text = "SCORE: " + Score;
        if (PlayerPrefs.GetInt("highscore1") < Score)
        {
            PlayerPrefs.SetInt("highscore1", Score);
        }
        HighScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highscore1");
        GameOverPanel.SetActive(true);
        panel_script.open();
     
        text.enabled = false;

        Miss_text.enabled = false;       
        PresentText.enabled = false;
        TutorialText.enabled = false;

        button[0].enabled = false;
        button[1].enabled = false;
        button[2].enabled = false;
        button[3].enabled = false;
     
    }

    public void ChecKey()
    {
        PresentText.text = "";
        if (KeyColor!= TextColourKey)
        {
            if(TextColourKey == -1)
            {
                Debug.Log("arrow false");
                
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
        if (SpeedIndexCounter == 2 && speed - 0.1f > 1.5f)
        {
            speed = speed - 0.1f;
            SpeedIndexCounter = 0;
        }
    }

    public void Resume()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        if (Score <= 3)        
        {
            Arrows.SetActive(true);
        }

        text.enabled = true;
        button[0].enabled = true;
        button[1].enabled = true;
        button[2].enabled = true;
        button[3].enabled = true;

        PauseButton.gameObject.SetActive(true);
        PausePanel.SetActive(false);
        PusePanelKey = 0;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        Arrows.SetActive(false);     
        text.enabled = false;
        button[0].enabled = false;
        button[1].enabled = false;
        button[2].enabled = false;
        button[3].enabled = false;

        PauseButton.gameObject.SetActive(false);
        PausePanel.SetActive(true);
        PusePanelKey = 1;
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
        if(Adcount>=2)
        {
            AdButton.SetActive(false);
        }

        if(Score<=3)
        {
            if (KeyColor == 0) Arrow_r.SetActive(true);
            if (KeyColor == 1) Arrow_b.SetActive(true);
            if (KeyColor == 2) Arrow_y.SetActive(true);
            if (KeyColor == 3) Arrow_g.SetActive(true);
        }
       
        timer = timer + Time.deltaTime;

        if(Score>=3)
        {
            TutorialText.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }

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

    //public void tmep_back()
    //{
   //     Back();
   // }

 
}






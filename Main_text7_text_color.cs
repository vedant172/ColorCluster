using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Main_text7_text_color : MonoBehaviour
{
    public GameObject AdButton;
    int Adcount = 0;
    int HSNext;             //ch
    public Text Next_text;
    public GameObject ContinuePanel;    //Ch
    public static Main_text7_text_color instance;
    public Text TutorialText;
    private int PusePanelKey = 0;
    public GameObject Arrows;       //ch
    public GameObject Arrow_r;
    public GameObject Arrow_b;
    public GameObject Arrow_y;
    public GameObject Arrow_g;
    private int arrowKey = 0;

    public setting_window panel_script;
    public GameObject PausePanel;
    public Button PauseButton;
    public Text text1;
    public Text text2;
    public Text text3;
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
    public int KeyColorCheck = 0;
    public int PreKeyColor = 0;
    public Button[] button;
    public int TextColourKey = 0;
    public int GameOverKey = 0;
    [SerializeField] private Animator text_animation;
    private int[] numbers = new int[4];
    string[] colourX = new string[] { "RED", "BLUE", "YELLOW", "GREEN" };
    public int text_color_key = 0; // for color of text


    void Start()
    {
        PausePanel.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        Miss_text.text = "";
        PresentText.text = "";
        GameOverPanel.SetActive(false);

        Arrows.SetActive(true);         //ch
        Arrow_r.SetActive(false);  //Ch
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        Next_text.enabled = false;      //ch
        PickRandomList();
        
    }

    public void Next() //ch
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        HSNext = PlayerPrefs.GetInt("highscore7_text_color");
        if (HSNext >= 100)
        {
            SceneManager.LoadScene("Part8");
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
        
        text1.enabled = true;
        text2.enabled = true;
        text3.enabled = true;
        Miss_text.enabled = true;        //ch
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
        Miss_text.enabled = true;
        MissCount = 0;
    }

    public void Restart()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        SceneManager.LoadScene("Part7_text_color");
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
            text1.enabled = true;
            text2.enabled = true;
            text3.enabled = true;
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
            text1.enabled = false;
            text2.enabled = false;
            text3.enabled = false;
            button[0].enabled = false;
            button[1].enabled = false;
            button[2].enabled = false;
            button[3].enabled = false;

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

    public void RandomColor1()
    {
        text1.color = Color.red;
        text2.color = Color.blue;
        text3.color = Color.yellow;
        text_color_key = 3;

    }

    public void RandomColor2()
    {
        text1.color = Color.red;
        text2.color = Color.blue;
        text3.color = Color.green;
        text_color_key = 2;
    }

    public void RandomColor3()
    {
        text1.color = Color.red;
        text2.color = Color.yellow;
        text3.color = Color.blue;
        text_color_key = 3;
    }

     public void RandomColor4()
    {
        text1.color = Color.red;
        text2.color = Color.yellow;
        text3.color = Color.green;
        text_color_key = 1;
    }

    public void RandomColor5()
    {
        text1.color = Color.red;
        text2.color = Color.green;
        text3.color = Color.blue;
        text_color_key = 2;
    }

    public void RandomColor6()
    {
        text1.color = Color.red;
        text2.color = Color.green;
        text3.color = Color.yellow;
        text_color_key = 1;
    }

    public void RandomColor11()
    {
        text1.color = Color.blue;
        text2.color = Color.red;
        text3.color = Color.yellow;
        text_color_key = 3;
    }

    public void RandomColor12()
    {
        text1.color = Color.blue;
        text2.color = Color.red;
        text3.color = Color.green;
        text_color_key = 2;
    }

    public void RandomColor13()
    {
        text1.color = Color.blue;
        text2.color = Color.yellow;
        text3.color = Color.green;
        text_color_key = 0;
    }

    public void RandomColor14()
    {
        text1.color = Color.blue;
        text2.color = Color.yellow;
        text3.color = Color.red;
        text_color_key = 3;
    }
    public void RandomColor15()
    {
        text1.color = Color.blue;
        text2.color = Color.green;
        text3.color = Color.red;
        text_color_key = 2;
    }

    public void RandomColor16()
    {
        text1.color = Color.blue;
        text2.color = Color.green;
        text3.color = Color.yellow;
        text_color_key = 0;
    }
    public void RandomColor21()
    {
        text1.color = Color.yellow;
        text2.color = Color.red;
        text3.color = Color.blue;
        text_color_key = 3;
    }
    public void RandomColor22()
    {
        text1.color = Color.yellow;
        text2.color = Color.red;
        text3.color = Color.green;
        text_color_key = 1;
    }
    public void RandomColor23()
    {
        text1.color = Color.yellow;
        text2.color = Color.blue;
        text3.color = Color.red;
        text_color_key = 3;
    }
    public void RandomColor24()
    {
        text1.color = Color.yellow;
        text2.color = Color.blue;
        text3.color = Color.green;
        text_color_key = 0;
    }

    public void RandomColor25()
    {
        text1.color = Color.yellow;
        text2.color = Color.green;
        text3.color = Color.red;
        text_color_key = 1;
    }

    public void RandomColor26()
    {
        text1.color = Color.yellow;
        text2.color = Color.green;
        text3.color = Color.blue;
        text_color_key = 0;
    }
    public void RandomColor31()
    {
        text1.color = Color.green;
        text2.color = Color.red;
        text3.color = Color.yellow;
        text_color_key = 1;
    }

    public void RandomColor32()
    {
        text1.color = Color.green;
        text2.color = Color.red;
        text3.color = Color.blue;
        text_color_key = 2;
    }

    public void RandomColor33()
    {
        text1.color = Color.green;
        text2.color = Color.blue;
        text3.color = Color.red;
        text_color_key = 2;
    }

    public void RandomColor34()
    {
        text1.color = Color.green;
        text2.color = Color.yellow;
        text3.color = Color.red;
        text_color_key = 1;
    }
    public void RandomColor35()
    {
        text1.color = Color.green;
        text2.color = Color.blue;
        text3.color = Color.yellow;
        text_color_key = 0;
    }

    public void RandomColor36()
    {
        text1.color = Color.green;
        text2.color = Color.yellow;
        text3.color = Color.blue;
        text_color_key = 0;
    }

    public void PickSet(int keyX)
    {
        switch (keyX)
        {
            case 0:
                RandomColor1();
                break;
            case 1:
                RandomColor2();
                break;
            case 2:
                RandomColor3();
                break;
            case 3:
                RandomColor4();
                break;
            case 4:
                RandomColor5();
                break;
            case 5:
                RandomColor6();
                break;

            case 6:
                RandomColor11();
                break;
            case 7:
                RandomColor12();
                break;
            case 8:
                RandomColor13();
                break;
            case 9:
                RandomColor14();
                break;
            case 10:
                RandomColor15();
                break;
            case 11:
                RandomColor16();
                break;

            case 12:
                RandomColor21();
                break;
            case 13:
                RandomColor22();
                break;
            case 14:
                RandomColor23();
                break;
            case 15:
                RandomColor24();
                break;
            case 16:
                RandomColor25();
                break;
            case 17:
                RandomColor26();
                break;

            case 18:
                RandomColor31();
                break;
            case 19:
                RandomColor32();
                break;
            case 20:
                RandomColor33();
                break;
            case 21:
                RandomColor34();
                break;
            case 22:
                RandomColor35();
                break;
            case 23:
                RandomColor36();
                break;
        }
        arrowKey = text_color_key;
    }

    public void PickRandomList()
    {
        TextColourKey = -1;
        string[] colour = new string[] { "RED", "BLUE",  "YELLOW", "GREEN" };      
        KeyColor = Random.Range(0, colour.Length);

        Arrow_r.SetActive(false);   //Ch
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
        text1.text = colour[KeyColor];

        KeyColor = Random.Range(0, colour.Length);
        text2.text = colour[KeyColor];

        KeyColor = Random.Range(0, colour.Length);
        text3.text = colour[KeyColor];

        PickSet(Random.Range(0, 24));
    }

    public void GenerateRandomList()
    {
        numbers[0] = Random.Range(0, 4);
        for (int i = 1; i < 4; i++)
        {
            numbers[i] = (numbers[0] + i) % 4;
        }
    }
    public void RED()
    {
        TextColourKey = 0;
        Arrow_r.SetActive(false); //Ch
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void BLUE()
    {
        TextColourKey = 1;
        Arrow_r.SetActive(false); //Ch
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void YELLOW()
    {
        TextColourKey = 2;
        Arrow_r.SetActive(false); //Ch
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void GREEN()
    {
        TextColourKey = 3;
        Arrow_r.SetActive(false); //Ch
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
        Arrows.SetActive(false);          //ch
        PauseButton.gameObject.SetActive(false);        //Ch
     
        GameOverKey = 1;
        Last_score.text = "SCORE: " + Score;
        if (PlayerPrefs.GetInt("highscore7_text_color") < Score)
        {
            PlayerPrefs.SetInt("highscore7_text_color", Score);
        }

        HighScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highscore7_text_color");
        GameOverPanel.SetActive(true);
        panel_script.open();
      
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        Miss_text.enabled = false;       //ch
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
        if (text_color_key!= TextColourKey)
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
        if (SpeedIndexCounter == 2 && speed - 0.1f > 1.5f) //ch
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
        text1.enabled = true;
        text2.enabled = true;
        text3.enabled = true;
        button[0].enabled = true;
        button[1].enabled = true;
        button[2].enabled = true;
        button[3].enabled = true;

        PauseButton.gameObject.SetActive(true);
        PausePanel.SetActive(false);
        PusePanelKey = 0;       //ch
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        Arrows.SetActive(false);     //ch
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        button[0].enabled = false;
        button[1].enabled = false;
        button[2].enabled = false;
        button[3].enabled = false;

        PauseButton.gameObject.SetActive(false);
        PausePanel.SetActive(true);
        PusePanelKey = 1;           //ch
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
        if (Score <= 3)                     //ch
        {
            if (arrowKey == 0) Arrow_r.SetActive(true);
            if (arrowKey == 1) Arrow_b.SetActive(true);
            if (arrowKey == 2) Arrow_y.SetActive(true);
            if (arrowKey == 3) Arrow_g.SetActive(true);
        }

        if (Score >= 3)
        {
            TutorialText.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }

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






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Main_text9_text_color : MonoBehaviour
{
    public GameObject AdButton;
    int Adcount = 0;
    public Text CN1;  //ch
    public Text CN2;
    int HSNext;             //ch
    public Text Next_text;

    public GameObject ContinuePanel;    //Ch
    public static Main_text9_text_color instance;
    public Text TutorialText;
    private int PusePanelKey = 0;
    public GameObject Arrows;       //ch
    public GameObject Arrow_r1;
    public GameObject Arrow_b1;
    public GameObject Arrow_y1;
    public GameObject Arrow_g1;
    public GameObject Arrow_r2;
    public GameObject Arrow_b2;
    public GameObject Arrow_y2;
    public GameObject Arrow_g2;
    public GameObject[] Arrow1;
    private int arrowKey = 0;

    public setting_window panel_script;
    public GameObject PausePanel;
    public Button PauseButton;
    public Text text;
    public Text HighScoreText; 
    public Text PresentText;
    public Text Last_score;
    public Text Miss_text;
    public Text Random_num_text;
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
    public int Random_num_text_number_prev = 0;
    Vector3 pos0;
    Vector3 pos1;
    Vector3 pos2;
    Vector3 pos3;
    Vector3 pos10;
    Vector3 pos11;
    Vector3 pos12;
    Vector3 pos13;

    Vector3 posr1;
    Vector3 posb1;
    Vector3 posg1;
    Vector3 posy1;
    Vector3 posr2;
    Vector3 posb2;
    Vector3 posg2;
    Vector3 posy2;
    private int[] numbers = new int[4];
    private int[] numbers1 = new int[4];
    public int text_color_key = 0; // for color of text


    void Start()
    {
        PausePanel.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        Miss_text.text = "";
        PresentText.text = "";
        GameOverPanel.SetActive(false);
        PickRandomList();

        pos0 = button[0].transform.position;
        pos1 = button[1].transform.position;
        pos2 = button[2].transform.position;
        pos3 = button[3].transform.position;

        pos10 = button[4].transform.position;
        pos11 = button[5].transform.position;
        pos12 = button[6].transform.position;
        pos13 = button[7].transform.position;

        posr1 = Arrow1[0].transform.position;
        posb1 = Arrow1[1].transform.position;
        posy1 = Arrow1[2].transform.position;
        posg1 = Arrow1[3].transform.position;

        posr2 = Arrow1[4].transform.position;
        posb2 = Arrow1[5].transform.position;
        posy2 = Arrow1[6].transform.position;
        posg2 = Arrow1[7].transform.position;

        Arrows.SetActive(true);         //ch
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_r2.SetActive(false);  //Ch
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        Next_text.enabled = false;      //ch
    }

    public void Next() //ch
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        HSNext = PlayerPrefs.GetInt("highscore9_text_color");
        if (HSNext >= 100)
        {
            SceneManager.LoadScene("Part10");
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
        Random_num_text.enabled = true;     //ch
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
        SceneManager.LoadScene("Part9_text_color");
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
        key = Random.Range(0, 4);
        if(PreKey==key)
        {
            RandomColor();
        }
        text_color_key = key;
        arrowKey = text_color_key;
        if (Random_num_text_number == 2)
        {
            arrowKey = arrowKey + 4;
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
        Random_num_text_number = Random.Range(1, 3);

        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        if (PreKeyColor==KeyColor && Random_num_text_number_prev == Random_num_text_number)
        {
            PickRandomList();
        }
        SpeedIndexCounter++;
        CheckSpeed();
        GenerateRandomList();
        change_button_pos();
        change_button_pos1();
        string colourName = colour[KeyColor];
        PreKeyColor = KeyColor;
        text.text = colourName;

        Random_num_text_number_prev = Random_num_text_number;
        Random_num_text.text = Random_num_text_number.ToString();

        RandomColor();        
    }

    public void change_button_pos()
    {
        pos0 = button[0].transform.position;
        pos1 = button[1].transform.position;
        pos2 = button[2].transform.position;
        pos3 = button[3].transform.position;

        posr1 = Arrow1[0].transform.position;
        posb1 = Arrow1[1].transform.position;
        posy1 = Arrow1[2].transform.position;
        posg1 = Arrow1[3].transform.position;

        button[numbers[0]].transform.position = pos3;
        button[numbers[1]].transform.position = pos1;
        button[numbers[2]].transform.position = pos2;
        button[numbers[3]].transform.position = pos0;

        Arrow1[numbers[0]].transform.position = posg1;
        Arrow1[numbers[1]].transform.position = posb1;
        Arrow1[numbers[2]].transform.position = posy1;
        Arrow1[numbers[3]].transform.position = posr1;

    }

    public void change_button_pos1()
    {
        pos10 = button[4].transform.position;
        pos11 = button[5].transform.position;
        pos12 = button[6].transform.position;
        pos13 = button[7].transform.position;

        posr2 = Arrow1[4].transform.position;
        posb2 = Arrow1[5].transform.position;
        posy2 = Arrow1[6].transform.position;
        posg2 = Arrow1[7].transform.position;

        button[numbers1[0]].transform.position = pos13;
        button[numbers1[1]].transform.position = pos11;
        button[numbers1[2]].transform.position = pos12;
        button[numbers1[3]].transform.position = pos10;

        Arrow1[numbers1[0]].transform.position = posg2;
        Arrow1[numbers1[1]].transform.position = posb2;
        Arrow1[numbers1[2]].transform.position = posy2;
        Arrow1[numbers1[3]].transform.position = posr2;

    }

    public void GenerateRandomList()
    {
        numbers[0] = Random.Range(0, 4);
        numbers1[0] = Random.Range(4, 8);

        for (int i = 1; i < 4; i++)
        {
            numbers[i] = (numbers[0] + i) % 4;
            numbers1[i] = (numbers1[0] + i) % 8;
            if(numbers1[i]<4)
            {
                numbers1[i] = numbers1[i] + 4;
            }
        }

    }
    public void RED_1()
    {
        TextColourKey = 0;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
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
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
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
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
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
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void RED_2()
    {
        TextColourKey = 4;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void BLUE_2()
    {
        TextColourKey = 5;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void YELLOW_2()
    {
        TextColourKey = 6;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);
    }

    public void GREEN_2()
    {
        TextColourKey = 7;
        Arrow_r1.SetActive(false);  //Ch
        Arrow_b1.SetActive(false);
        Arrow_g1.SetActive(false);
        Arrow_y1.SetActive(false);
        Arrow_r2.SetActive(false);
        Arrow_b2.SetActive(false);
        Arrow_g2.SetActive(false);
        Arrow_y2.SetActive(false);
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
        if (PlayerPrefs.GetInt("highscore9_text_color") < Score)
        {
            PlayerPrefs.SetInt("highscore9_text_color", Score);
        }

        HighScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highscore9_text_color");   
        GameOverPanel.SetActive(true);
        panel_script.open();
        
        text.enabled = false;
        Random_num_text.enabled = false;    //ch
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
    }

    public void ChecKey()
    {
        PresentText.text = "";
        if(Random_num_text_number==2)
        {
            text_color_key = text_color_key + 4;
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
            if (arrowKey == 4) Arrow_r2.SetActive(true);
            if (arrowKey == 5) Arrow_b2.SetActive(true);
            if (arrowKey == 6) Arrow_y2.SetActive(true);
            if (arrowKey == 7) Arrow_g2.SetActive(true);
        }

        if (Score >= 3)                             //ch
        {
            TutorialText.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))       //ch
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






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Main_text8 : MonoBehaviour
{
    public GameObject AdButton;
    int Adcount = 0;
    private float arrowPOSdown;
    private float arrowPOSleft;
    int HSNext;             //ch
    public Text Next_text;

    public GameObject ContinuePanel;    //Ch
    public static Main_text8 instance;
    public Text TutorialText;
    private int PusePanelKey = 0;
    public GameObject Arrows;       //ch
    public GameObject Arrow_r;
    public GameObject Arrow_b;
    public GameObject Arrow_y;
    public GameObject Arrow_g;
    public GameObject[] Arrow;
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
    Vector3 pos0;
    Vector3 pos1;
    Vector3 pos2;
    Vector3 pos3;
    Vector3 posr;
    Vector3 posb;
    Vector3 posg;
    Vector3 posy;
    private int[] numbers1 = new int[4];

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

        posr = Arrow[0].transform.position;
        posb = Arrow[1].transform.position;
        posy = Arrow[2].transform.position;
        posg = Arrow[3].transform.position;
        Next_text.enabled = false;      //ch
        PickRandomList();

        // set Y pos
        if (Arrow_r.transform.position.y > Arrow_b.transform.position.y)
        {
            arrowPOSdown = Arrow_b.transform.position.y;
        }

        else if (Arrow_r.transform.position.y < Arrow_b.transform.position.y)
        {
            arrowPOSdown = Arrow_r.transform.position.y;
        }

        else
        {
            if (Arrow_r.transform.position.y < Arrow_y.transform.position.y)
            {
                arrowPOSdown = Arrow_r.transform.position.y;
            }
            else arrowPOSdown = Arrow_y.transform.position.y;
        }

        //set X pos
        if (Arrow_r.transform.position.x > Arrow_b.transform.position.x)
        {
            arrowPOSleft = Arrow_b.transform.position.x;
        }

        else if (Arrow_r.transform.position.x < Arrow_b.transform.position.x)
        {
            arrowPOSleft = Arrow_r.transform.position.x;
        }

        else
        {
            if (Arrow_r.transform.position.x < Arrow_y.transform.position.x)
            {
                arrowPOSleft = Arrow_r.transform.position.x;
            }
            else arrowPOSleft = Arrow_y.transform.position.x;
        }

    }

    public void Next() //ch
    {
        if (SFXmanager.sfxInstance.musicToggle == true)                         //ch
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        HSNext = PlayerPrefs.GetInt("highscore8");
        if (HSNext >= 100)
        {
            SceneManager.LoadScene("Part8_text_color");
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
        SceneManager.LoadScene("Part8");
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
    public void  RandomColor1()
    {
        key = Random.Range(0, 4);
        switch (key)
        {
            case 0:
                text1.color = Color.red;
                break;
            case 1:
                text1.color = Color.blue;
                break;
            case 2:
                text1.color = Color.yellow;
                break;
            case 3:
                text1.color = Color.green;
                break;
        }
    }

    public void RandomColor2()
    {
        key = Random.Range(0, 4);
        switch (key)
        {
            case 0:
                text2.color = Color.red;
                break;
            case 1:
                text2.color = Color.blue;
                break;
            case 2:
                text2.color = Color.yellow;
                break;
            case 3:
                text2.color = Color.green;
                break;
        }
    }

    public void RandomColor3()
    {
        key = Random.Range(0, 4);
        switch (key)
        {
            case 0:
                text3.color = Color.red;
                break;
            case 1:
                text3.color = Color.blue;
                break;
            case 2:
                text3.color = Color.yellow;
                break;
            case 3:
                text3.color = Color.green;
                break;
        }
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
        if (Score >= 1)
        {
            GenerateRandomList();
            change_button_pos();
        }

        //GenerateRandomList1();
       // change_button_pos();
        string colourName = colour[KeyColor];
        PreKeyColor = KeyColor;

        GenerateRandomList();
        text1.text = colourX[((numbers[0]) % 4)]; ;
        text3.text = colourX[((numbers[1]) %4)];
        text2.text = colourX[((numbers[2]) % 4)];
        KeyColorCheck = ((numbers[3]) % 4);
        string colourNameX = colourX[KeyColorCheck];
        colourX[2] = colourX[KeyColorCheck];
        colourX[3] = text3.text;
        colourX[0] = text2.text;
        colourX[1] = text1.text;
 
        for(int i=0; i<4; i++)
        {
            if(colourNameX==colour[i])
            {
                KeyColorCheck = i;
                arrowKey = KeyColorCheck;
                break;
            }
        }

        
        RandomColor1();
        RandomColor2();
        RandomColor3();
    }

    public void GenerateRandomList()
    {
        numbers[0] = Random.Range(0, 4);
        for (int i = 1; i < 4; i++)
        {
            numbers[i] = (numbers[0] + i) % 4;
        }
    }

    public void GenerateRandomList1()
    {
        numbers1[0] = Random.Range(0, 4);

        for (int i = 1; i < 4; i++)
        {
            numbers1[i] = (numbers1[0] + i) % 4;
        }

    }

    public void change_button_pos()
    {
        pos0 = button[0].transform.position;
        pos1 = button[1].transform.position;
        pos2 = button[2].transform.position;
        pos3 = button[3].transform.position;

        posr = Arrow[0].transform.position;
        posb = Arrow[1].transform.position;
        posy = Arrow[2].transform.position;
        posg = Arrow[3].transform.position;

        button[numbers1[0]].transform.position = pos3;
        button[numbers1[1]].transform.position = pos1;
        button[numbers1[2]].transform.position = pos2;
        button[numbers1[3]].transform.position = pos0;

        Arrow[numbers1[0]].transform.position = posg;
        Arrow[numbers1[1]].transform.position = posb;
        Arrow[numbers1[2]].transform.position = posy;
        Arrow[numbers1[3]].transform.position = posr;

        for (int i = 0; i < 4; i++)
        {
            if ((Arrow[i].transform.position.y - arrowPOSdown) <= 10f && (Arrow[i].transform.position.y - arrowPOSdown) >= -10f)
            {
                Debug.Log("y pos: " + Arrow[i].transform.position.x);

                if ((Arrow[i].transform.position.x - arrowPOSleft) <= 10f && (Arrow[i].transform.position.x - arrowPOSleft) >= -10f)
                {
                    Arrow[i].transform.eulerAngles = new Vector3(Arrow[i].transform.eulerAngles.x, Arrow[i].transform.eulerAngles.y,
                                                             -135.0f);
                }

                else
                {
                    Arrow[i].transform.eulerAngles = new Vector3(Arrow[i].transform.eulerAngles.x, Arrow[i].transform.eulerAngles.y,
                                                              135.0f);
                }
                    
            }

            else
            {
                Debug.Log("y pos: " + Arrow[i].transform.position.y);
                if ((Arrow[i].transform.position.x - arrowPOSleft) <= 10f && (Arrow[i].transform.position.x - arrowPOSleft) >= -10f)
                {
                    Arrow[i].transform.eulerAngles = new Vector3(Arrow[i].transform.eulerAngles.x, Arrow[i].transform.eulerAngles.y,
                                                             -45.0f);
                }

                else
                {
                    Arrow[i].transform.eulerAngles = new Vector3(Arrow[i].transform.eulerAngles.x, Arrow[i].transform.eulerAngles.y,
                                                              45.0f);
                }
            }

        }

    }
    public void RED()
    {
        TextColourKey = 0;
        Arrow_r.SetActive(false);   //Ch
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void BLUE()
    {
        TextColourKey = 1;
        Arrow_r.SetActive(false);   //Ch
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void YELLOW()
    {
        TextColourKey = 2;
        Arrow_r.SetActive(false);   //Ch
        Arrow_b.SetActive(false);
        Arrow_g.SetActive(false);
        Arrow_y.SetActive(false);
        if (SFXmanager1.sfxInstance1.musicToggle1 == true)
            SFXmanager1.sfxInstance1.Audio1.PlayOneShot(SFXmanager1.sfxInstance1.Click1);

    }

    public void GREEN()
    {
        TextColourKey = 3;
        Arrow_r.SetActive(false);   //Ch
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
        if (PlayerPrefs.GetInt("highscore8") < Score)
        {
            PlayerPrefs.SetInt("highscore8", Score);
        }
        HighScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highscore8");
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
        if (KeyColorCheck!= TextColourKey)
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






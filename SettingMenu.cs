using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingMenu : MonoBehaviour
{
     public static SettingMenu instance;
    // public Button mute_button;
    public start_scene_manager start_Scene_ManagerScript;
    //public Sprite mute_img;
   // public Sprite unmute_img;
   // public Slider vloumeSlider;
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;
    

    [Space]
    [Header("Main button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase; 
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    Button mainButton;
    SettingMenuItem[] menuItems;
    bool isExpanded = false;
    int itemsCount;
    int mute_key = 0;
    Vector2 mainButtonPosition;
    private string Hight;
    private int Hight_int;
    // Start is called before the first frame update

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
        Hight = Screen.height.ToString();
        int.TryParse(Hight, out Hight_int);

        if(Hight_int < 480)
        {
            spacing.x = 0;
            spacing.y = -50;
        }

        if ((Hight_int >= 480) && (Hight_int <= 800))
        {
            spacing.x = 0;
            spacing.y = -100;
        }

        if ( (Hight_int>800) && (Hight_int<=1280) )
        {
            spacing.x = 0;
            spacing.y = -150;
        }

        if ((Hight_int > 1280) && (Hight_int <= 1920))
        {
            spacing.x = 0;
            spacing.y = -250;
        }

        if ((Hight_int > 1920) && (Hight_int <= 2160))
        {
            spacing.x = 0;
            spacing.y = -250;
        }

        if ((Hight_int > 2160) && (Hight_int <= 2560))
        {
            spacing.x = 0;
            spacing.y = -300;
        }

        if ((Hight_int > 2560) && (Hight_int <= 2960))
        {
            spacing.x = 0;
            spacing.y = -350;
        }

        if (Hight_int > 2960)
        {
            spacing.x = 0;
            spacing.y = -400;
        }


        itemsCount = transform.childCount - 1;
        menuItems = new SettingMenuItem[itemsCount];

        for(int i=0; i<itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingMenuItem>(); 
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();
        mainButtonPosition = mainButton.transform.position;
        ResetPosition();
    }

    void ResetPosition()
    {
        for(int i=0; i<itemsCount; i++)
        {
            menuItems[i].trans.position = mainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded; 

        if(isExpanded)
        {
           // Debug.Log("open");
            //menu opened
            for(int i=0; i<itemsCount; i++)
            {
                //menuItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
                menuItems[i].trans.DOMove(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }

        else
        {
           // Debug.Log("close");
           // vloumeSlider.gameObject.SetActive(false);
            //menu closed 
            for (int i = 0; i < itemsCount; i++)
            {
                //menuItems[i].trans.position = mainButtonPosition ;
                menuItems[i].trans.DOMove(mainButtonPosition , collapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(0f, collapseFadeDuration);
            }

        }

        mainButton.transform
            .DORotate(Vector3.forward * 180f, rotationDuration)
            .From(Vector3.zero)
            .SetEase(rotationEase);
    }

    //public void music_button()
    //{
    //    vloumeSlider.gameObject.SetActive(true);
    //}
    public void OnTtemClick(int index)
    {
        switch (index)
        {
            case 0:
               // vloumeSlider.gameObject.SetActive(true);
               
                break;
            case 1:
                if(mute_key==0)
                {
                    //start_Scene_ManagerScript.SetVolume(-80f);
                   // mute_button.image.sprite = mute_img;
                    mute_key = 1;
                }
                else
                {

                   // mute_button.image.sprite = unmute_img;
                  //  start_Scene_ManagerScript.SetVolume(-40f);
                    mute_key = 0;
                }
                         
                break;
            case 2:

                break;
        }
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuItem : MonoBehaviour
{
    [HideInInspector] public Image img;
    [HideInInspector] public Transform trans;

    SettingMenu settingMenu;
    Button button;
    int index;
    // Start is called before the first frame update
    void Awake()
    {
        img = GetComponent<Image>();
        trans = transform;

        settingMenu = trans.parent.GetComponent<SettingMenu>();
        index = trans.GetSiblingIndex() - 1;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnItemClick);


    }

    void OnItemClick()
    {
        settingMenu.OnTtemClick(index);
    }

     void OnDestroy()
    {
       button.onClick.RemoveListener(OnItemClick);    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

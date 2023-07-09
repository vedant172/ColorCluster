using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        var version = PlayerPrefs.GetString("Version", string.Empty);

        if(string.IsNullOrWhiteSpace(version))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Version", Application.version);
        }

        else
        {
            if(version !=Application.version)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetString("Version", Application.version);
            }
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    public void SubmitClick()
    {
        if (PlayerPrefs.HasKey("path"))
        {
            string tag = "";
            var path = PlayerPrefs.GetInt("path");

            if (path == 0)
            {
                tag = "internet";
            }
            if (path == 1)
            {
                tag = "politic";
            }
            if (path == 2)
            {
                tag = "classic";
            }

            if (PlayerPrefs.HasKey(tag))
            {
                var val = PlayerPrefs.GetInt(tag);
                PlayerPrefs.SetInt(tag, val++);
            }
        }

        
    }
}

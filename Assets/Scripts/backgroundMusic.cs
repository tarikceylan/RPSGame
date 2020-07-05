using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundMusic : MonoBehaviour {

    static backgroundMusic instance = null;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void toggleMusic()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0) {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }
}

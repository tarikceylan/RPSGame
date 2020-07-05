using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundScript : MonoBehaviour {

    private backgroundMusic bgMusic;
    public Button toggleMusicButton;
    public Sprite musicOn;
    public Sprite musicOff;

	// Use this for initialization
	void Start () {

        bgMusic = GameObject.FindObjectOfType<backgroundMusic>();
        UpdateMusicIcon();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseMusic()
    {
        bgMusic.toggleMusic();
        UpdateMusicIcon();
    }

    public void UpdateMusicIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            toggleMusicButton.GetComponent<Image>().sprite = musicOn;
        }

        else
        {
            AudioListener.volume = 0;
            toggleMusicButton.GetComponent<Image>().sprite = musicOff;
        }
    }

    
}

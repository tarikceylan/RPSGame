using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class interstitialAd : MonoBehaviour
{
    public GameObject winnerText;
    private InterstitialAd interstitialAdObj;
  
    void Start()
    {
        MobileAds.Initialize( AdStatus => { } );
        GetNewAd(null, null);
    }
    
    public void GameOver()
    {
        if (winnerText.GetComponent<TMPro.TextMeshProUGUI>().text == "YOU WON!" || winnerText.GetComponent<TMPro.TextMeshProUGUI>().text == "COM WON!")
            StartCoroutine(ShowAd());
    }
    
    IEnumerator ShowAd()
    {
        while( !interstitialAdObj.IsLoaded() )
            yield return null;
  
        interstitialAdObj.Show();
    }

    public void GetNewAd (object sender, EventArgs args)
    {
        if (interstitialAdObj != null)
            interstitialAdObj.Destroy();
        interstitialAdObj = new InterstitialAd("ca-app-pub-3940256099942544/1033173712"); //INTERSTITIAL TEST AD KEY
        //interstitialAdObj = new InterstitialAd("ca-app-pub-7916658357044225/2564768874"); //INTERSTITIAL AD KEY
        interstitialAdObj.OnAdClosed += GetNewAd;
        AdRequest interAdRequest = new AdRequest.Builder().Build();
        interstitialAdObj.LoadAd(interAdRequest);
    }
  
    void OnDestroy()
    {
        if( interstitialAdObj != null )
            interstitialAdObj.Destroy();
    }
}

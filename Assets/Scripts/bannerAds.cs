using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class bannerAds : MonoBehaviour
{
    private BannerView bannerAdObj;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(adStatus => { });
        bannerAdObj = new BannerView("ca-app-pub-3940256099942544/6300978111", AdSize.SmartBanner, AdPosition.Top); //TEST BANNER AD KEY
        //bannerAdObj = new BannerView("ca-app-pub-7916658357044225/9321748919", AdSize.SmartBanner, AdPosition.Top); //BANNER AD KEY
        AdRequest bannerAdRequest = new AdRequest.Builder().Build();
        bannerAdObj.LoadAd(bannerAdRequest);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (bannerAdObj != null)
            bannerAdObj.Destroy();

    }
}

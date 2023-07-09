using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;


public class adManager : MonoBehaviour
{
    public static adManager instance;
    private string appID = "ca-app-pub-9330169245374647~9200290913";

    private BannerView bannerView;
    private string bannerID = "ca-app-pub-3940256099942544/6300978111";

    private RewardedAd rewarded;
    private string RewardAdId = "ca-app-pub-3940256099942544/5224354917";
    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
      //  this.rewarded = new RewardedAd(RewardAdId);
       // this.RequestRewardedAd();

        // Called when an ad request has successfully loaded.
       // this.rewarded.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
      //  this.rewarded.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
    //    this.rewarded.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
    //    this.rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
    //    this.rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
       // this.rewarded.OnAdClosed += HandleRewardedAdClosed;

    }
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }    
    }

   

    public void RequestBanner()
    {
        bannerView = new BannerView(bannerID,AdSize.Banner,AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void RequestRewardedAd()
    {
        AdRequest requestR = new AdRequest.Builder().Build();
        rewarded.LoadAd(requestR);
    }

    public void showRewardedAd()
    {
        if(rewarded.IsLoaded())
        {
            rewarded.Show();
        }

        else
        {
            Debug.Log("ad is not loaded");
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }
    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: " );
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
}






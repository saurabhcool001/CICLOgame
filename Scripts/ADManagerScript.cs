using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManagerScript : MonoBehaviour
{
	private string APP_ID = "ca-app-pub-1152051333116465~6507992433";

    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    // Start is called before the first frame update
    void Start()
    {
		//This is when you publish your app
		//MobileAds.Initialize(APP_ID);

		// Initialize the Google Mobile Ads SDK.
		//MobileAds.Initialize(initStatus => {

  //      });

        RequestInterstitial();
        //RequestRewarded();
	}

    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-1152051333116465~6507992433";
        this.interstitialAd = new InterstitialAd(interstitial_ID);

        //For real-app
        //AdRequest adRequest = new AdRequest.Builder().Build();

        //For test-app
        AdRequest adRequest = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        this.interstitialAd.LoadAd(adRequest);

        // Initialize an InterstitialAd.
        //this.interstitialAd = new InterstitialAd(interstitial_ID);
    }

    public void Display_InterstitialAD()
    {
        if (this.interstitialAd.IsLoaded())
        {
            this.interstitialAd.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        Display_InterstitialAD();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestInterstitial();
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleInterstitialADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            this.interstitialAd.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is shown.
            this.interstitialAd.OnAdOpening += HandleOnAdOpened;
            // Called when the ad is closed.
            this.interstitialAd.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.interstitialAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            this.interstitialAd.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.interstitialAd.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is shown.
            this.interstitialAd.OnAdOpening -= HandleOnAdOpened;
            // Called when the ad is closed.
            this.interstitialAd.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.interstitialAd.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
    }

    //REWARDED ADS
    public void RequestRewarded()
    {
        string rewarded_ID = "ca-app-pub-3940256099942544/5224354917";
        rewardedAd = new RewardedAd(rewarded_ID);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

    }

    public void Display_RewardedAD()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Display_RewardedAD();
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        RequestRewarded();
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
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
        RequestRewarded();
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

    void HandleAwardedAdEvents(bool subscribe)
    {
        if(subscribe)
        {
            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            this.rewardedAd.OnAdFailedToLoad -= HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening -= HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow -= HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
        }
    }



    private void OnEnable()
    {
        HandleInterstitialADEvents(true);
        HandleAwardedAdEvents(true);
    }

    private void OnDisable()
    {
        HandleInterstitialADEvents(false);
        HandleAwardedAdEvents(false);
    }

}

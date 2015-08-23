namespace UnityEngine.Advertisements {
  using System;

  public static class Advertisement {

  	public static readonly string version = "1.2.1";

		
	private static Action _handleFinished;
	private static Action _handleSkipped;
	private static Action _handleFailed;
	private static Action _onContinue;


    public enum DebugLevel {
      None = 0,
      Error = 1,
      Warning = 2,
      Info = 4,
      Debug = 8,
      [System.ObsoleteAttribute("Use Advertisement.DebugLevel.None instead")]
      NONE = 0,
      [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Error instead")]
      ERROR = 1,
      [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Warning instead")]
      WARNING = 2,
      [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Info instead")]
      INFO = 4,
      [System.ObsoleteAttribute("Use Advertisement.DebugLevel.Debug instead")]
      DEBUG = 8
    }
		
    static private DebugLevel _debugLevel = Debug.isDebugBuild ? DebugLevel.Error | DebugLevel.Warning | DebugLevel.Info | DebugLevel.Debug : DebugLevel.Error | DebugLevel.Warning | DebugLevel.Info;
	
    static public DebugLevel debugLevel {
      get {
        return _debugLevel;
      }
	
      set {
        _debugLevel = value;
#if UNITY_ANDROID || UNITY_IOS
        UnityEngine.Advertisements.UnityAds.setLogLevel(_debugLevel);
#endif
      }
    }

    static public bool isSupported {
      get {
        return 
          Application.isEditor ||
          Application.platform == RuntimePlatform.IPhonePlayer || 
          Application.platform == RuntimePlatform.Android;
      }
    }

    static public bool isInitialized {
      get {
#if UNITY_ANDROID || UNITY_IOS
        return UnityAds.isInitialized;
#else
        return false;
#endif
      }
    }

    static public void Initialize(string appId, bool testMode = false) {
#if UNITY_ANDROID || UNITY_IOS
      UnityAds.SharedInstance.Init(appId, testMode);
#endif
    }

    static public void Show(string zoneId = null, ShowOptions options = null) {
#if UNITY_ANDROID || UNITY_IOS
      UnityAds.SharedInstance.Show(zoneId, options);
			_handleFinished = null;
			_handleSkipped = null;
			_handleFailed = null;
			_onContinue = null;

			if (string.IsNullOrEmpty(zoneId)) zoneId = null;
			
			//ShowOptions option = new ShowOptions();
			//option.resultCallback = HandleShowResult;
			
			//Advertisement.Show(zoneId,option);

#else
      if(options != null && options.resultCallback != null) {
        options.resultCallback(ShowResult.Failed);
      }
#endif
    }

    [System.Obsolete("Advertisement.allowPrecache is no longer supported and does nothing")]
    static public bool allowPrecache { 
      get {
#if UNITY_ANDROID || UNITY_IOS
        return UnityAds.allowPrecache;
#else
        return false;
#endif
      }
      set {
#if UNITY_ANDROID || UNITY_IOS
        UnityAds.allowPrecache = value;
#endif
      }
    }

    static public bool IsReady(string zoneId = null) {
#if UNITY_ANDROID || UNITY_IOS
      return UnityAds.canShowZone(zoneId);
#else
      return false;
#endif
    }

	[System.Obsolete("Use Advertisement.IsReady method instead")]
    static public bool isReady(string zoneId = null) {
      return IsReady(zoneId);
	}

    static public bool isShowing { 
      get {
#if UNITY_ANDROID || UNITY_IOS
        return UnityAds.isShowing;
#else
        return false;
#endif
      }
    }

    static public bool UnityDeveloperInternalTestMode {
      get; set;
    }

	private static void HandleShowResult (ShowResult result)
		{
			switch (result)
			{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				if (!object.ReferenceEquals(_handleFinished,null)) _handleFinished();
				break;
			case ShowResult.Skipped:
				Debug.LogWarning("The ad was skipped before reaching the end.");
				if (!object.ReferenceEquals(_handleSkipped,null)) _handleSkipped();
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				if (!object.ReferenceEquals(_handleFailed,null)) _handleFailed();
				break;
			}
			
		if (!object.ReferenceEquals(_onContinue,null)) _onContinue();
	}

  }

}

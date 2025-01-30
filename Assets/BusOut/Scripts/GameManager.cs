using GameTandat17z;
using System;
using System.Collections;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public static GameState gameState;
    public static GameMode gameMode = GameMode.classic;
    public static GameScene gameScene = GameScene.loading;

    public static Action<GameScene> OnSwitchScene;

    protected override void Awake()
    {
        base.Awake();

        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 80;
    }

    private void Start()
    {
        StartCoroutine(IeOnGameInitComplete());
    }

    private IEnumerator IeOnGameInitComplete()
    {
        if (!PlayerPrefs.HasKey("GAME_INITED"))
        {
            PlayerPrefs.SetInt("GAME_INITED", 1);
        }

        yield return new WaitForEndOfFrame();

        //Vibration.Init();

        //BoosterManager.isLockingAll = false;

        //UserDataManager.Instance.Init();
        //LevelManager.CountLevel();
        //TutorialManager.SetupOnStart();

        yield return new WaitForEndOfFrame();

        SwitchScene(GameScene.ingame);
    }

    public static void SwitchScene(GameScene scene)
    {
        if (scene == gameScene) return;

        gameScene = scene;

        if (gameScene == GameScene.ingame)
        {
            //PanelManager.Instance.OpenForget<GameplayPanel>();
            //GameplayManager.Instance.StartLevel(UserDataManager.Instance.GetCurrentLevel());
            ////GameplayManager.Instance.StartLevel(1);

            //Kernel.Resolve<AdsManager>().ShowBanner();
        }
        else if (gameScene == GameScene.home)
        {
            //_ = PanelManager.Instance.ClosePanel<GameplayPanel>(true);

            //Kernel.Resolve<AdsManager>().HideBanner();
        }

        OnSwitchScene?.Invoke(scene);
    }
}

public enum GameState
{
    Playing = 0,
    Pause = 1,
    Over = 2
}

public enum GameMode
{
    classic = 0,
}

public enum GameScene
{
    loading = 0,
    home = 1,
    ingame = 2
}

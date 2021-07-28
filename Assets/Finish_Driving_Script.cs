using UnityEngine;
using UnityEngine.UI;
using Assets.Route;
using System;
using UnityEngine.SceneManagement;

public class Finish_Driving_Script : MonoBehaviour
{
    private GameObject FinishPanel;
    private Button buttonBackMainMenu, buttonDriveAgain;
    private TitleMenuScript titleMenuScript;
    private RouteMapHolder routeMapHolder;
    private user_score userScore;
    private bool endDrivingFlag;

    void Start()
    {
        FinishPanel = GameObject.Find("Finish_Panel");

        buttonBackMainMenu = GameObject.Find("Button-back_to_main_menu").GetComponent<Button>();
        buttonDriveAgain = GameObject.Find("Button-drive_again").GetComponent<Button>();

        buttonBackMainMenu.onClick.AddListener(() =>
        {
            ResetUserDetails();
            StartMainMenu();
        });

        buttonDriveAgain.onClick.AddListener(() =>
        {
            HideFinishPanel();
            SaveTheUserDetails();
            StartDrivingScene();
        });

        routeMapHolder = GameObject.Find("Route Map").GetComponent<RouteMapHolder>();
        userScore = GameObject.Find("ScoreHolder").GetComponent<user_score>();
        titleMenuScript = GameObject.Find("MenuScript").GetComponent<TitleMenuScript>();

        endDrivingFlag = false;
        FinishPanel.SetActive(false);  // warning!!! - if this panel is SetActive="false", we can't find the GameObjects under this panel!!!
    }
    
    void Update()
    {
        if (endDrivingFlag == false && CheckIfarrivedEndOfRoute())
        {
            PauseTheGame();
            ShowFinishPanel();
            ShowUserScore();
            endDrivingFlag = true;
        }
    }

    private void ShowUserScore()
    {
        Text final_score = GameObject.Find("final_score_description").GetComponent<Text>();
        final_score.text += userScore.Score;
    }

    private bool CheckIfarrivedEndOfRoute()
    {
        return routeMapHolder.RouteMap.ArcsInRoute.Count == 0;
    }

    private void StartDrivingScene()
    {
        SceneManager.LoadScene("Sport Coupe Demo", LoadSceneMode.Single);
    }

    private void SaveTheUserDetails()
    {
        DontDestroyOnLoad(titleMenuScript);
    }

    private void StartMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void ResetUserDetails()
    {
        titleMenuScript.enabled = false;
        titleMenuScript.enabled = true;
    }

    private void PauseTheGame()
    {
        Time.timeScale = 0;  //  this command is freeze the scene
    }

    private void ContinueDriving()
    {
        Time.timeScale = 1;  //  this command is continue the scene running
    }

    private void ShowFinishPanel()
    {
        FinishPanel.SetActive(true);
    }

    private void HideFinishPanel()
    {
        FinishPanel.SetActive(false);
    }

}
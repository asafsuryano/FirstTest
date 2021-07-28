using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
using Google.XR.Cardboard;
using System.Collections;

public class TitleMenuScript : MonoBehaviour
{
    private static TitleMenuScript titleMenuInstance;
    private Button startSimBtn;
    private Button startSimVRButton;
    private Button exitButton;
    private new string name;
    private int drivingLevelChoice;
    private string drivingLevelChoiceName;
    private int routeChoice;
    private string routeChoiceName;
    private bool theGameIsStarted;  // flag for run "update" function only one time, in user_script
    private ToggleGroup drivingLevel;
    private ToggleGroup route;
    private bool isVr;

    public bool IsVr { get => isVr; set => isVr = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.startSimBtn = GameObject.Find("startGameBtn").GetComponent<Button>();
        this.startSimBtn.onClick.AddListener(StartGameNoVr);
        this.startSimVRButton = GameObject.Find("startGameVRBtn").GetComponent<Button>();
        this.startSimVRButton.onClick.AddListener(StartGameVR);
        this.drivingLevel = GameObject.Find("drivingLevelRadioBtn").GetComponent<ToggleGroup>();
        this.route = GameObject.Find("routeChoiceRadioBtn").GetComponent<ToggleGroup>();
        this.name = "";
        this.drivingLevelChoice = 0;
        this.routeChoice = 0;
        this.theGameIsStarted = false;

        exitButton = GameObject.Find("exitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        // Api.UpdateScreenParams();
    }
    void StartGameNoVr()
    {
        this.isVr = false;
        StartGame();
    }
    void StartGameVR()
    {
        this.isVr = true;
        StartGame();
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType<TitleMenuScript>().Length > 1)
        {
            Destroy(FindObjectsOfType<TitleMenuScript>()[0].gameObject);
        }
    }
    void StartGame()
    {
        this.name = GameObject.Find("TextName").GetComponent<Text>().text;
        IEnumerator<Toggle> drivingLevelToggles = this.drivingLevel.ActiveToggles().GetEnumerator();
        drivingLevelToggles.MoveNext();
        
        while (drivingLevelToggles.Current.isOn==false)
        {
            this.drivingLevel.ActiveToggles().GetEnumerator().MoveNext();
            this.drivingLevelChoice++;
        }
        IEnumerator<Toggle> routeToggles = this.route.ActiveToggles().GetEnumerator();
        routeToggles.MoveNext();
        while (routeToggles.Current.isOn == false)
        {
            this.route.ActiveToggles().GetEnumerator().MoveNext();
            this.routeChoice++;
        }
        //routeToggles.Reset();

        drivingLevelChoiceName = drivingLevelToggles.Current.GetComponentInChildren<Text>().text;
        routeChoiceName = routeToggles.Current.GetComponentInChildren<Text>().text;
        if (routeChoiceName.Equals("ינוריע ןיב"))
        {
            routeChoice = 2;
        }
        else
        {
            routeChoice = 1;
        }
        if (name == "")
        {
            GameObject.Find("Placeholder").GetComponent<Text>().text = "הבוח הדש";  //  שדה חובה
            GameObject.Find("Placeholder").GetComponent<Text>().color = Color.red;
        }
        else
        {
            this.theGameIsStarted = true;
            SceneManager.LoadScene(sceneName: "Sport Coupe Demo");  // start driving scene
        }
    }

    public void ExitGame()
    {
        print("Quit Game");
        Application.Quit();
    }

    public string GetName()
    {
        return this.name;
    }


    public int GetDrivingLevelChoice()
    {
        return this.drivingLevelChoice;
    }
    public string GetDrivingLevelChoiceName()
    {
        return drivingLevelChoiceName;
    }


    public int GetRouteChoice()
    {
        return this.routeChoice;
    }
    public string GetRouteChoiceName()
    {
        return routeChoiceName;
    }

    public bool GetTheGameIsStarted()
    {
        return theGameIsStarted;
    }
    public void SetTheGameIsStarted(bool theGameIsStarted)
    {
        this.theGameIsStarted = theGameIsStarted;
    }
}

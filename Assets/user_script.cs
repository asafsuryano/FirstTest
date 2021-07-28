using UnityEngine;
using UnityEngine.UI;

public class user_script : MonoBehaviour
{
    private User user;
    private TitleMenuScript titleMenuScript;
    private string route;
    private Text userInformation;
    private user_score userScore;

    public void Start()
    {
        user = new User();
        titleMenuScript = GameObject.Find("MenuScript").GetComponent<TitleMenuScript>();
        user.setUsername(titleMenuScript.GetName());
        user.setDrivingLevel(titleMenuScript.GetDrivingLevelChoiceName());
        user.SetRouteChosen(titleMenuScript.GetRouteChoiceName());
        userScore = GameObject.Find("ScoreHolder").GetComponent<user_score>();
    }

    private void GetInformationUser()
    {
        userInformation.text = user.getUsername() + "\n" + user.GetDrivingLevel() + "\n" + user.GetRouteChosen();
        GameObject.Find("score").GetComponent<Text>().text = userScore.Score + "";
    }

    public void Update()
    {
        //DontDestroyOnLoad(titleMenuScript);
        if (GameObject.Find("details") != null)
        {
            userInformation = GameObject.Find("details").GetComponent<Text>();
            GetInformationUser();
            titleMenuScript.SetTheGameIsStarted(false);
        }
    }
}
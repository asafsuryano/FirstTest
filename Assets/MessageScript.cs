using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour
{
    private float timeForMassege;
    private Text messageText;
    private RawImage rawImageMessage;
    private bool showedMessage;
    private Button restartBtn;
    private GameObject restartCanvas;
    private GameObject messageCanvas;
    private bool isVr;
    private bool isNeedRestart;
    public Text MessageText { get => messageText; set => messageText = value; }
    public bool ShowedMessage { get => showedMessage; set => showedMessage = value; }

    // Start is called before the first frame update
    void Start()
    {
        rawImageMessage = GameObject.Find("RawImageMessage").GetComponent<RawImage>();
        messageText = GameObject.Find("messageText").GetComponent<Text>();
        messageText.color = new Color(1, 0, 0);
        timeForMassege = 3;
        showedMessage = false;
        restartBtn = GameObject.Find("restartBtn").GetComponent<Button>();
        restartBtn.onClick.AddListener(startOver);
        restartCanvas = GameObject.Find("restartBtn");
        isVr = GameObject.Find("MenuScript").GetComponent<TitleMenuScript>().IsVr;
        isNeedRestart = false;
        restartCanvas.SetActive(false);
        messageCanvas = GameObject.Find("MessageCanvas");
        messageCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isNeedRestart)
        {
            if (showedMessage && timeForMassege > 0)
            {
                timeForMassege -= Time.smoothDeltaTime;
            }
            else
            {
                showedMessage = false;
                timeForMassege = 3;
                messageCanvas.SetActive(false);
            }
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                startOver();
            }
        }
    }
    public void disableCanvas()
    {
        messageCanvas.SetActive(false);
    }
    public void enableCanvas()
    {
        messageCanvas.SetActive(true);
    }
    public void showMessageToTellTheDriverToRestart()
    {
        Time.timeScale = 0;
        messageCanvas.SetActive(true);
        messageText.fontSize = 50;
        messageText.text = "לולסמה ימוחתל ץוחמ תעסנ";
        messageText.text = messageText.text + "\n";
        messageText.text = messageText.text + "שדחמ לחתה רותפכ לע הציחל ידי לע הלחתהמ לחתה אנא";
        messageText.text = messageText.text + "\n";
        messageText.text = messageText.text + "טלשב הצאהה רותפכ לע הציחל ידי לע וא";
        rawImageMessage.color = new Color(1, 1, 1, 0.5f);
        isNeedRestart = true;
        if (!isVr)
        {
            restartCanvas.SetActive(true);
        }
        
    }
    public void startOver()
    {
        SceneManager.LoadScene("Sport Coupe Demo", LoadSceneMode.Single);
    }
}

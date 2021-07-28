using UnityEngine;
using UnityEngine.UI;
using Assets.Route;
using System.Collections.Generic;
using System;
using System.Collections;

public class Question_Script : MonoBehaviour
{
    private QuestionDataHolder questionDataHolder;
    private List<(float x, float z, Boolean isArrived)> questionsMarksPositions;
    private CarDataHolder CarData;
    private GameObject QuestionPanel;
    private int CurrectAnswerindex;
    private Button buttonAnswer1, buttonAnswer2, buttonAnswer3, buttonAnswer4, ButtonKeepDriving;
    private ColorBlock oldButtonColor;
    private user_score userScore;
    private bool scored;
    private TitleMenuScript titleMenuScript;

    internal List<(float x, float z, Boolean isArrived)> QuestionsMarksPositions { get => questionsMarksPositions; set => questionsMarksPositions = value; }
    internal QuestionDataHolder QuestionDataHolder { get => QuestionDataHolder; set => QuestionDataHolder = value; }

    void Start()
    {
        CarData = GameObject.Find("CarDataHolderGameobject").GetComponent<CarDataHolder>();
        questionsMarksPositions = new List<(float x, float z, Boolean isArrived)>();
        LoadAllQuestionMarksPositionXZ();
        questionDataHolder = GameObject.Find("LoadQuestionFile").GetComponent<QuestionDataHolder>();
        QuestionPanel = GameObject.Find("Question_Panel");

        buttonAnswer1 = GameObject.Find("Button-answer1").GetComponent<Button>();
        buttonAnswer2 = GameObject.Find("Button-answer2").GetComponent<Button>();
        buttonAnswer3 = GameObject.Find("Button-answer3").GetComponent<Button>();
        buttonAnswer4 = GameObject.Find("Button-answer4").GetComponent<Button>();
        oldButtonColor = buttonAnswer1.colors;

        ButtonKeepDriving = GameObject.Find("Button-keep_driving").GetComponent<Button>();
        ButtonKeepDriving.onClick.AddListener(() =>
        {
            ResetButtons();
            HideQuestionPanel();
            scored = false;
            ContinueDriving();
        });

        ButtonKeepDriving.gameObject.SetActive(false);

        QuestionPanel.SetActive(false);  // warning!!! - if this panel is SetActive="false", we can't find the GameObjects under this panel!!!
        userScore = GameObject.Find("ScoreHolder").GetComponent<user_score>();
        titleMenuScript = GameObject.Find("MenuScript").GetComponent<TitleMenuScript>();

        scored = false;
    }

    private void LoadAllQuestionMarksPositionXZ()  // load position of x and z axis
    {
        string questionMarkObjectName = "QuestionMark";
        int index = 1;
        GameObject questionMark;

        while (GameObject.Find(questionMarkObjectName + index) != null)
        {
            questionMark = GameObject.Find(questionMarkObjectName + index);
            questionsMarksPositions.Add((questionMark.GetComponent<Transform>().position.x, questionMark.GetComponent<Transform>().position.z, false));
            index++;
        }
    }

    void Update()
    {
        if (!titleMenuScript.IsVr)
        {
            if (IfCarPositionEqualsToQuestionMarkPosition())
            {
                pauseTheGame();
                ShowTheoryQuestion();
                CheckUserAnswer();
            }
        }
    }

    private void pauseTheGame()
    {
        Time.timeScale = 0;  //  this command is freeze the scene
    }

    private void ContinueDriving()
    {
        Time.timeScale = 1;  //  this command is continue the scene running
    }

    private void CalculateScore()
    {
        if (scored == false)
        {
            userScore.SubtractPoints(5);
            scored = true;
        }
    }

    private void CheckUserAnswer()
    {
        buttonAnswer1.onClick.AddListener(()=>
        {
            if (CurrectAnswerindex == 1)
                CorrectAnswer(buttonAnswer1);
            else
                wrongAnswer(buttonAnswer1);
        });

        buttonAnswer2.onClick.AddListener(() =>
        {
            if (CurrectAnswerindex == 2)
                CorrectAnswer(buttonAnswer2);
            else
                wrongAnswer(buttonAnswer2);
        });

        buttonAnswer3.onClick.AddListener(() =>
        {
            if (CurrectAnswerindex == 3)
                CorrectAnswer(buttonAnswer3);
            else
                wrongAnswer(buttonAnswer3);
        });

        buttonAnswer4.onClick.AddListener(() =>
        {
            if (CurrectAnswerindex == 4)
                CorrectAnswer(buttonAnswer4);
            else
                wrongAnswer(buttonAnswer4);
        });
    }

    private void wrongAnswer(Button b)
    {
        // change button color:
        ColorBlock colors = b.colors;
        colors.normalColor = Color.red;
        colors.selectedColor = Color.red;
        b.colors = colors;
        CalculateScore();
        // set currect button answer to green
        CorrectAnswer(GameObject.Find("Button-answer"+CurrectAnswerindex).GetComponent<Button>());
        // show ButtonKeepDriving
        ButtonKeepDriving.gameObject.SetActive(true);
    }

    private void CorrectAnswer(Button b)
    {
        // change button color:
        ColorBlock colors = b.colors;
        colors.normalColor = Color.green;
        colors.selectedColor = Color.green;
        b.colors = colors;
        scored = true;
        // show ButtonKeepDriving
        ButtonKeepDriving.gameObject.SetActive(true);
    }

    private void ResetButtons()
    {
        buttonAnswer1.colors = oldButtonColor;
        buttonAnswer2.colors = oldButtonColor;
        buttonAnswer3.colors = oldButtonColor;
        buttonAnswer4.colors = oldButtonColor;

        ButtonKeepDriving.gameObject.SetActive(false);
    }

    private void ShowTheoryQuestion()
    {
        QuestionPanel.SetActive(true);
        ChooseQuestion();
    }

    private void HideQuestionPanel()
    {
        QuestionPanel.SetActive(false);
    }

    private void ChooseQuestion()
    {
        int index;
        // choose randome question:
        do
        {
            index = (new System.Random()).Next(questionDataHolder.Questions.Count);
        } while (questionDataHolder.Questions[index].GetIsAppeared() == true);

        GameObject.Find("question_description").GetComponent<Text>().text = questionDataHolder.Questions[index].GetQuestion();
        GameObject.Find("Button-answer1").GetComponentInChildren<Text>().text = questionDataHolder.Questions[index].GetAnswers()[0];
        GameObject.Find("Button-answer2").GetComponentInChildren<Text>().text = questionDataHolder.Questions[index].GetAnswers()[1];
        GameObject.Find("Button-answer3").GetComponentInChildren<Text>().text = questionDataHolder.Questions[index].GetAnswers()[2];
        GameObject.Find("Button-answer4").GetComponentInChildren<Text>().text = questionDataHolder.Questions[index].GetAnswers()[3];
        CurrectAnswerindex = questionDataHolder.Questions[index].GetCurrectIndexAnswer();
        questionDataHolder.Questions[index].SetIsAppeared(true);
    }

    private Boolean IfCarPositionEqualsToQuestionMarkPosition()
    {
        for (int i = 0; i < questionsMarksPositions.Count; i++)
            if (CheckDistance(CarData.User_car.getPosition().x, questionsMarksPositions[i].x,
                CarData.User_car.getPosition().z, questionsMarksPositions[i].z) < 2.0   //  the number 2.0 is for small distance.
                && questionsMarksPositions[i].isArrived == false)
            {
                questionsMarksPositions[i] = (questionsMarksPositions[i].x, questionsMarksPositions[i].z, true);  // change "isArrived" to "true"
                return true;
            }
        return false;
    }

    private float CheckDistance(float x1,float x2,float y1,float y2)
    {
        return (float)Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
    }

}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Route
{
    public class QuestionDataHolder : MonoBehaviour
    {
        private List<Question> questions;

        internal List<Question> Questions { get => questions; set => questions = value; }

        public void Start()
        {
            questions = new List<Question>();
            readArcsFromCSV();
        }

        public void Update()
        {

        }
       
        private void readArcsFromCSV()
        {
            TextAsset txt = Resources.Load("Data/Theory Questions") as TextAsset;
            //  print(txt);  // for check
            string questions = txt.text;
            string[] allLines = questions.Split('\n');
            for (int i = 1; i < allLines.Length; i++)
            {
                string[] details = allLines[i].Split(',');
                if (!(details[0] == ""))  // if not empty row
                {
                    int qusetionId = Int32.Parse(details[0]);
                    string questionDescription = ReverseString(details[1]);
                    string[] answers = new string[4];
                    for (int j = 0; j < 4; j++)  // read indexes:  2 <-> 5
                    {  
                        answers[j] = ReverseString(details[2 + j]);
                    }
                    int currectIndexAnswer = Int32.Parse(details[6]);
                    Question question = new Question(qusetionId, questionDescription, answers, currectIndexAnswer);

                    this.questions.Add(question);
                }
            }
        }

        public string ReverseString (string normalString)
        {
            string reverseString = "";
            for (int i = 0; i < normalString.Length; i++)
            {
                reverseString = normalString[i] + reverseString;
            }
            return reverseString;
        }

    }
}
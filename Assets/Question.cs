public class Question
{
    // private ArrayList questions = new ArrayList();
    private int questionId;
    private string questionDescription;
    private string [] answers;
    private int currectIndexAnswer;
    private bool isAppeared;

    public Question()
    {
        // initial values:
        this.questionId = 0;
        this.questionDescription = "";
        this.answers = new string [4];  //  4 answers
        for (int i = 0; i < answers.Length; i++)
            answers[i] = "";
        this.currectIndexAnswer = 0;
        this.isAppeared = false;
    }

    public Question(int questionId, string questionDescription, string[] answers, int currectIndexAnswer )
    {
        this.questionId = questionId;
        this.questionDescription = questionDescription;
        this.answers = answers;
        this.currectIndexAnswer = currectIndexAnswer;
        this.isAppeared = false;
    }

    public void SetCurrectIndexAnswer(int currectIndexAnswer)
    {
        this.currectIndexAnswer = currectIndexAnswer;
    }
    public int GetCurrectIndexAnswer()
    {
        return this.currectIndexAnswer;
    }

    public void SetQuestion(string questionDescription)
    {
        this.questionDescription = questionDescription;
    }
    public string GetQuestion()
    {
        return questionDescription;
    }

    public void SetAnswers(string[] answers)
    {
        this.answers = answers;
    }
    public string[] GetAnswers()
    {
        return answers;
    }

    public void SetIsAppeared(bool isAppeared)
    {
        this.isAppeared = isAppeared;
    }
    public bool GetIsAppeared()
    {
        return this.isAppeared;
    }

}
using UnityEngine;

public class user_score : MonoBehaviour
{
    private int score;

    public int Score { get => score; set => score = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.score = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SubtractPoints(int numOfPoints)
    {
        this.score -= numOfPoints;
    }
}

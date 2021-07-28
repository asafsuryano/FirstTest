using UnityEngine;
using UnityEngine.UI;

public class ReverseUserNameInput : MonoBehaviour
{
    private string userName;
    private int inputLength;

    private const char FirstHebChar = (char)1488; //א
    private const char LastHebChar = (char)1514; //ת

    private bool IsHebrew(char c)
    {
        return c >= FirstHebChar && c <= LastHebChar;
    }

    void Start()
    {
        this.userName = GameObject.Find("InputFieldName").GetComponent<InputField>().text;
        this.inputLength = 0;
    }

    void Update()
    {
        this.userName = GameObject.Find("InputFieldName").GetComponent<InputField>().text;
        
        if (this.userName.Length > 0 && IsHebrew(this.userName[0]))  //  if the input is in Hebrew
        {
            if (this.inputLength < this.userName.Length && this.userName.Length > 0)
            {
                this.inputLength = this.userName.Length;
                userName = ReverseHebrewString(this.userName);
            }
            else if (this.inputLength > this.userName.Length)
            {
                this.inputLength = this.userName.Length;
            }
        }

        GameObject.Find("InputFieldName").GetComponent<InputField>().text = this.userName;
    }
    
    private string ReverseHebrewString(string someString)
    {
        string reverseInput = someString[someString.Length-1] + "";
        for (int i = 0; i < someString.Length-1 ; i++)
        {
            reverseInput = reverseInput + someString[i];
        }
        return reverseInput;
    }
    
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI questionText;

    public DiaLog diaLog;

    public AnswerButton[] answerButton;


    private void Awake()
    {
        this.MakeSingleTon();
    }
    public void SetTime(string content)
    {
        if(timeText)
            this.timeText.text = content;
    }

    public void SetQuestion(string content)
    {
        if(questionText)
            this.questionText.text = content;
    }

    public void ShuffleAnswer()
    {
        if(this.answerButton != null && this.answerButton.Length > 0)
        {
            for(int i = 0; i < this.answerButton.Length; i++)
            {
                if (this.answerButton[i])
                {
                    this.answerButton[i].tag = "Untagged";
                }    
            }

            int ranIdx = Random.Range(0, this.answerButton.Length);

            if (this.answerButton[ranIdx])
            {
                this.answerButton[ranIdx].tag = "RightAnswer";
            }    
        }    
    }    

    public void MakeSingleTon()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }    
}

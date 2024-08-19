using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    public QuestionData[] questions;
    List<QuestionData> m_Question;

    QuestionData m_curQuestion;

    public QuestionData CurQuestion { get => m_curQuestion; set => m_curQuestion = value; }

    protected void Awake()
    {
        this.m_Question = this.questions.ToList();
        this.MakeSingleTon();
    }

    public QuestionData GetRandomQuestion()
    {
        if(this.m_Question != null && this.m_Question.Count > 0)
        {
            int randIdx = Random.Range(0, this.m_Question.Count);//random câu hỏi
            this.CurQuestion = this.m_Question[randIdx];
            this.m_Question.RemoveAt(randIdx);// xóa câu hỏi sau khi random
        }    
        return this.m_curQuestion;
    }
    public void MakeSingleTon()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}

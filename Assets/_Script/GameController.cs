using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] protected int m_rightCount;
    public float timePerQuestion;
    public float m_current;

    protected void Awake()
    {
        this.m_current = this.timePerQuestion;
    }
    private void Start()
    {
        this.CreateQuestion();
        UiManager.instance.SetTime("00 : " + this.m_current);

        StartCoroutine(this.TimeCountingDown());
    }
    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.instance.GetRandomQuestion();

        if (qs != null )
        {
            UiManager.instance.SetQuestion(qs.question);
            string[] wrongAnswers = new string[] {qs.answerA, qs.answerB, qs.answerC};

            UiManager.instance.ShuffleAnswer();

            var temp = UiManager.instance.answerButton;

            if(temp != null && temp.Length > 0 ) 
            {
                    int wrongAnswerCount = 0;

                for(int i = 0; i < temp.Length; i++)
                {
                    int answerID = i;
                    
                    if(string.Compare(temp[i].tag,"RightAnswer" ) == 0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }    
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswers[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }

                    temp[answerID].bntComp.onClick.RemoveAllListeners();
                    temp[answerID].bntComp.onClick.AddListener(() => this.CheckRightAnswer(temp[answerID]));
                }    
            }
        }    
    }    

    protected virtual void CheckRightAnswer(AnswerButton answerbutton)
    {
        if (answerbutton.CompareTag("RightAnswer"))
        {
            this.m_current = this.timePerQuestion;
            UiManager.instance.SetTime("00 : " + this.m_current);
            m_rightCount++;

            if (this.m_rightCount == QuestionManager.instance.questions.Length)
            {
                UiManager.instance.diaLog.SetDiaLogContent("Bạn đã chiến thắng!");
                AudioController.instance.PlayWinSound();
                UiManager.instance.diaLog.Show(true);
                StopAllCoroutines();
            }    
            else
            {
                this.CreateQuestion();
                AudioController.instance.PlayRightSound();
                Debug.Log("Chỉ ăn may thôi");
            }    
        }
        else
        {
            UiManager.instance.diaLog.SetDiaLogContent("Ngu vl!");
            UiManager.instance.diaLog.Show(true);
            AudioController.instance.PlayLoseSound();
            Debug.Log("Thứ kém cỏi");
        }    
    }
    IEnumerator TimeCountingDown()
    {
        yield return new WaitForSeconds(1);
        if (this.m_current > 0)
        {
            this.m_current--;
            UiManager.instance.SetTime("00 : " + this.m_current);
            StartCoroutine(this.TimeCountingDown());
        }
        else
        {
            UiManager.instance.diaLog.SetDiaLogContent("Thật đáng thất vọng!");
            UiManager.instance.diaLog.Show(true);
            StopAllCoroutines();
            AudioController.instance.PlayLoseSound();
        }

    }

    public void RePlay()
    {
        AudioController.instance.StopMusic();
        SceneManager.LoadScene("Quiz");
    }

    public void Exit()
    {
        Application.Quit();
    }

}

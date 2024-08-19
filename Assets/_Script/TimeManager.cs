/*using System.Collections;
using UnityEngine;

public class TimeManager : GameController
{
    public float timePerQuestion;
    public float m_current;
    protected void Awake()
    {
        this.m_current = this.timePerQuestion;

    }
    protected void Start()
    {
        UiManager.instance.SetTime("00 : " + this.m_current);

        StartCoroutine(this.TimeCountingDown());
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
        }
      
    }

}*/

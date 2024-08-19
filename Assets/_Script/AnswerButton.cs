using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    public Button bntComp;

    public void SetAnswerText(string context)
    {
        if(answerText)
            answerText.text = context;
    }    
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaLog : MonoBehaviour
{
    public TextMeshProUGUI diaLogContentText;

    public void Show(bool isShow)
    {
        this.gameObject.SetActive(isShow);
    }    

    public void  SetDiaLogContent(string content)
    {
        if(diaLogContentText)
            this.diaLogContentText.text = content;
    }    
}

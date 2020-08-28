using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    public static UICtrl instance;

    [SerializeField]
    Text score;
    [SerializeField]
    GameObject loseWindow;

    const string scoreTitle = "Gems collected : ";
    
    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
        }
    }

    public void ShowScore()
    {
        score.text = scoreTitle + GameCtrl.instance.Scores.ToString();
    }

    public void ShowLoseWindow()
    {
        loseWindow.gameObject.SetActive(true);

    }
    public void HideLoseWindow()
    {
        loseWindow.gameObject.SetActive(false);
    }

}

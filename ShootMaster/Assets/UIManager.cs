using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI TimerUI;
    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI ComboUI;
    public TextMeshProUGUI BestScoreUI;
    public TextMeshProUGUI StartRoundUI;

    public Renderer StartRoundColor;

    public Timer Timer;
    public GameManager gameManager;
    // Start is called before the first frame update
    private string TimerTextToShow = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerTextToShow = "00:";
        if (Timer.timeRemaining < 10)
        {
            TimerTextToShow += "0";
        }
        TimerUI.text = TimerTextToShow + Timer.timeRemaining.ToString();
        ScoreUI.text = gameManager.acturalPoints.ToString();

        ComboUI.text = gameManager.combo.ToString();

        BestScoreUI.text = gameManager.MaxPoints.ToString();

        if (gameManager.activeTimer)
        {
            StartRoundColor.material.color = Color.red;
            StartRoundUI.text = "STOP";
        }
        else
        {
            StartRoundColor.material.color = Color.green;
            StartRoundUI.text = "START";
        }
    }
}

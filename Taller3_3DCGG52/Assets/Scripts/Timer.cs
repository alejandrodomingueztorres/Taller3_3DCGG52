using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int minutes;

    [SerializeField]
    private int seconds;

    private int m, s;

    [SerializeField]
    private TextMeshProUGUI timerText;

    private GameController GameController;

    //Start is called before the first frame update
    void Start()
    {
        GameController = gameObject.GetComponent<GameController>();
    }

    public void startTimer()
    {
        m = minutes;
        s = seconds;
        writeTimer(m, s);
        Invoke("updateTimer", 1f);
    }

    public void stopTimer()
    {
        CancelInvoke();
    }

    public void updateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                GameController.endGame();
                return;
            }
            else
            {
                m--;
                s = 59;
            }
        }

        writeTimer(m, s);
        Invoke("updateTimer", 1f);
    }


    private void writeTimer(int m, int s)
    {
        if (s < 10)
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }
    }
}



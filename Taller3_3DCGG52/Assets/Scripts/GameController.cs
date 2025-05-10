using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Timer timer;
   

    void Start()
    {
        timer = gameObject.GetComponent<Timer>();
  
    }

    public void startGame()
    {
        timer.startTimer();
       

    }
    
    public void endGame()
    {
        timer.stopTimer();
      
        //Destroy (Player);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    
    
}

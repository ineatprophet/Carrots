using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

    public Text gameOverText;
    void Start(){ 
        string results = "You made it to Turn # " + GlobalVars.currentTurn.ToString() + " and killed " + 
            GlobalVars.rabbitCount.ToString() + " rabbits! Great Job!";
        gameOverText.text = results; 
    }
}

// Need a pair of buttons below the text for "Exit" and "Restart"
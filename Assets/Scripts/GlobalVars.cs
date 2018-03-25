using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVars : MonoBehaviour {
    /// <summary>
    /// like the name implies, this is for the collection of global variables and methods
    /// </summary>
    public static GameObject activeFarmer;
    public static int carrotStockpile;
    public static int currentTurn;
    public static int rabbitCount;

    public static List<GameObject> skillbarControllers; //static reference to the whole collection of skillbars

    private void Start() //initialize skillbarcontrollers reference
    {
        skillbarControllers = GameObject.FindGameObjectWithTag("GameController").GetComponent<SkillBarAccess>().skillbarControllers;
    }

    public static void GameOverTrigger() // Change scenes to the Game Over scene
    {
        SceneManager.LoadScene("Game Over");
    }

}

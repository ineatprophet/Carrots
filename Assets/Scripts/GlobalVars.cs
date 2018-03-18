using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVars : MonoBehaviour {

    public static GameObject activeFarmer;
    public static int carrotStockpile;
    public static int currentTurn;
    public static int rabbitCount;

    public static List<GameObject> skillbarControllers; //static reference to the whole collection of skillbars

    private void Start() //initialize skillbarcontrollers reference
    {
        skillbarControllers = GameObject.FindGameObjectWithTag("GameController").GetComponent<SkillBarAccess>().skillbarControllers;
    }

    public static void GameOverTrigger()
    {
        //Application.LoadLevel("Game Over");
        SceneManager.LoadScene("Game Over");
    }

}

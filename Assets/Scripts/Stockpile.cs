using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stockpile : MonoBehaviour {

    /// <summary>
    /// Unnecessary script. Should be combined with GlobalVars. 
    /// </summary>
    public Text carrotCount;
    public Text rabbitCount;

    public int carrots;
    public int rabbits;

    private void Start()
    {
        GlobalVars.carrotStockpile = 0;
        GlobalVars.rabbitCount = 2;
    }

    private void Update()
    {
        rabbitCount.text = GlobalVars.rabbitCount.ToString();
    }
}

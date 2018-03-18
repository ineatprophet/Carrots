using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarnUI : MonoBehaviour {

    public Text carrotCount;
    public Text turnCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        carrotCount.text = GlobalVars.carrotStockpile.ToString();
        turnCount.text = GlobalVars.currentTurn.ToString();
	}
}

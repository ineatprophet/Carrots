using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portrait : MonoBehaviour {

    public GameObject linkedFarmer;
	public void SelectFarmer() // change UI display and active farmer. Re-initialize all skillbars for new skillsheet.
    {
        GlobalVars.activeFarmer = linkedFarmer;
        GameObject.FindGameObjectWithTag("portrait_title").GetComponent<Text>().text = ("Current Farmer: " + linkedFarmer.GetComponent<Farmer>().farmerName);
        Debug.Log(GlobalVars.activeFarmer.ToString() + " is the new active farmer");
        foreach(GameObject sbc in GlobalVars.skillbarControllers)
        {
            sbc.GetComponent<SkillBarController>().InitializeSkillbar();
        }
    }
}
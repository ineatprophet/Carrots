using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillBarAccess : MonoBehaviour {

    /// <summary>
    /// Direct access to the Skillbars
    /// </summary>

    public GameObject botanyController;
    public GameObject shrubsController;
    public GameObject foodbearingController;
    public GameObject rootvegController;
    public GameObject carrotController;
    public GameObject harvestController;

    public List<GameObject> skillbarControllers = new List<GameObject>();

    private void Start()
    {
        skillbarControllers.Add(botanyController);
        skillbarControllers.Add(shrubsController);
        skillbarControllers.Add(foodbearingController);
        skillbarControllers.Add(rootvegController);
        skillbarControllers.Add(carrotController);
      //  skillbarControllers.Add(harvestController);
    }
}

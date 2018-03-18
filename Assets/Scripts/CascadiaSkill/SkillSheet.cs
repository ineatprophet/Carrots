using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
[ExecuteInEditMode]
public class SkillSheet : MonoBehaviour {

    // Purpose: To hold a collection of CascadiaSkills
    public GameObject farmer;
    public SkillSheet thisSkillSheet;
    public List<CascadiaSkill> mySkills = new List<CascadiaSkill>();

    private void Awake()
    {
        farmer = this.gameObject;
    }

    public void Start()
    {
        thisSkillSheet = GetComponent<SkillSheet>();
        FillSkills();
    }

    public void FillSkills()
    {
        //Debug.Log("mySkills started with " + mySkills.Count + " entries.");
        CS_Botany botany = new CS_Botany();
        botany.mySkillSheet = thisSkillSheet;
        mySkills.Add(botany);
        CS_Shrubs shrubs = new CS_Shrubs();
        shrubs.mySkillSheet = thisSkillSheet;
        mySkills.Add(shrubs);
        CS_FoodBearing foodBearing = new CS_FoodBearing();
        foodBearing.mySkillSheet = thisSkillSheet;
        mySkills.Add(foodBearing);
        CS_RootVegetables rootVegetables = new CS_RootVegetables();
        rootVegetables.mySkillSheet = thisSkillSheet;
        mySkills.Add(rootVegetables);
        CS_Carrots carrots = new CS_Carrots();
        carrots.mySkillSheet = thisSkillSheet;
        mySkills.Add(carrots);
        CS_Harvesting harvesting = new CS_Harvesting();
        harvesting.mySkillSheet = thisSkillSheet;
        mySkills.Add(harvesting);
        //harvesting.HarvestCarrots(10, 20, 30);
        //Debug.Log("mySkills now contains " + mySkills.Count + " entries.");
    }

}

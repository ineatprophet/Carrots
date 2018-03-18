using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICascadiaSkill
{
    int SkillCheck(List<SkillWeightPair>values);
}

//[System.Serializable]
public class CascadiaSkill : ICascadiaSkill {


    #region standard rpg info
    public string skillName = "a constructor is broken"; // default. lets me know a constructor is broken.
    [Range(0,100)]
    public int skillValue = (int)Random.Range(0,100) ;
    //variance information (used for calculating visualization)
    [Range(0,100)]
    public int lowBound = 0;
    [Range(0,100)]
    public int highBound = 100; // 0, 100 initial extremes. will be set later.
    [Range(-25,25)]
    public int boundOffset = 0; // How far off of the skillValue the bounds will be centered
    public int boundSize; // how wide the bounds are
    public int bestGuess = 50; // Where the skillValue is assumed to be. 
    public SkillBarController skillBar;
    public SkillSheet mySkillSheet;
    #endregion

    #region constructors
    public CascadiaSkill(string name)
    {
        skillName = name;
    }
    public CascadiaSkill()
    {
       // mySkillSheet = sheet;
    }
#endregion

    //relationship information, primarily for organizing in the skillsheet visually. May also impact learning or weighting
    public CascadiaSkill cs_parent;
    public string parentName = "  ";
    public List<CascadiaSkill> cs_children = new List<CascadiaSkill>();
    

    //send skillcheck a list of skill values and their associated weights. calculate final skill check result. Untested.
    public int SkillCheck(List<SkillWeightPair> values)
    {
        int finalResult = 0;
        float numerator = 0;
        float denominator = 0;
        for(int n = 0; n < values.Count; n++)
        {

            numerator += (values[n].value * values[n].weight); //sum of skill value multiplied by weight
            denominator += values[n].weight; //divided by the total weight
        }

        finalResult = (int)(numerator / denominator);

        return finalResult;
    }
  
    public void RandomizeSkillValue()
    {
        skillValue = (int)Random.Range(0, 100);
    }

    public void FindParent() //associate each skill in skillsheet with its parent, for recursive calls later.
    {
        foreach(CascadiaSkill skill in mySkillSheet.mySkills)
        {
            if(skill.skillName == parentName)
            {
                cs_parent = skill;
                Debug.Log("Farmer: " + mySkillSheet.farmer.ToString() + " My Name: " + skillName + " My Parent: " + parentName);
            }
        }
    }

    void OnEnable()
    {
        //FindParent();
    }

    

}

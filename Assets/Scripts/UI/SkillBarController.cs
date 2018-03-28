using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SkillBarController : MonoBehaviour {

    #region  0-100 sliders for easy visualization 
    // [Range(0, 100)]
    public int lowerLimit;
    //[Range(0, 100)]
    public int upperLimit;
    // [Range(0, 100)]
    public int skillBarCenter;
#endregion

    public CascadiaSkill targetSkill = null;
    public string mySkillName = "Botany";

    #region references to all images in the skillbar
    public GameObject leftside;
    public GameObject rightside;
    public GameObject blackfillLeft;
    public GameObject blackfillRight;
    public GameObject skillbar;
    #endregion

    public float skillbarWidth;
    public float skillbarHeight;

    public SkillSheet skillSheet;

    void Update () {
        if(targetSkill == null) // If a farmer hasn't been selected.
        {
            //Debug.Log("Skill is null");
        }
        else if(targetSkill.skillName == mySkillName)
        {
            //Debug.Log("updating");
            UpdateSBValues();
        }
        else if(targetSkill.skillName == null)
        {
            Debug.Log("targetSkill.skillName is Null");
        }
        UpdateSkillbar();
	}

    public void UpdateSkillbar() //draws the skillbar
    {
        //obtain the current ACTUAL width and height of the skillbar
        skillbarWidth = skillbar.GetComponent<RectTransform>().rect.width;
        skillbarHeight = skillbar.GetComponent<RectTransform>().rect.height;

        // adjust slider values to scale with the actual size. This could have been done inline, but it wasn't very readable.
        int adjustedLower = (int)(lowerLimit * (skillbarWidth / 100));
        int adjustedCenter = (int)(skillBarCenter * (skillbarWidth / 100));
        int adjustedUpper = (int)(upperLimit * (skillbarWidth / 100));

        // adjust sizes of each image in the skillbar
        blackfillLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(adjustedLower, skillbarHeight);
        leftside.GetComponent<RectTransform>().sizeDelta = new Vector2(adjustedCenter - adjustedLower, skillbarHeight);
        rightside.GetComponent<RectTransform>().sizeDelta = new Vector2(adjustedUpper - adjustedCenter, skillbarHeight);
        blackfillRight.GetComponent<RectTransform>().sizeDelta = new Vector2(skillbarWidth - adjustedUpper, skillbarHeight);

    }

    public void UpdateSBValues() //sets the values needed by UpdateSkillbar()
    {
        lowerLimit = targetSkill.lowBound;
        upperLimit = targetSkill.highBound;
        skillBarCenter = targetSkill.skillValue;
    }

    public void InitializeSkillbar() //called by clicking farmer portrait
    {
        skillSheet = GlobalVars.activeFarmer.GetComponent<SkillSheet>();
        //Debug.Log(skillSheet.ToString());
        foreach(CascadiaSkill skill in skillSheet.mySkills)
        {
            if(skill.skillName == mySkillName)
            {
                //Debug.Log("Found match. Linking " + skill.ToString() + " with value " + skill.skillValue.ToString() + " to " + this.ToString());
                targetSkill = skill;
                //Debug.Log(targetSkill.ToString());
                break;
            }
        }
    }
}

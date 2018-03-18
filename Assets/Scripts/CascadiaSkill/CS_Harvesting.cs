using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Harvesting : CascadiaSkill {
    

 public int HarvestCarrots(int carrotSkill, int rootvegSkill, int foodBearing, int shrubs, int botanySkill, int availableCarrots)
    {
        int result = 0;
        float carrotWeight = 2;
        float rootvegWeight = 1;
        float foodBearingWeight = 1; 
        float shrubWeight = 1;
        float botanyWeight = 1;
        float harvestWeight = 1.4f;

        List<SkillWeightPair> pairs = new List<SkillWeightPair>();
        pairs.Add(new SkillWeightPair(carrotSkill, carrotWeight));
        pairs.Add(new SkillWeightPair(botanySkill, botanyWeight));
        pairs.Add(new SkillWeightPair(rootvegSkill, rootvegWeight));
        pairs.Add(new SkillWeightPair(foodBearing, foodBearingWeight));
        pairs.Add(new SkillWeightPair(shrubs, shrubWeight));
        pairs.Add(new SkillWeightPair(skillValue, harvestWeight));

        // this line adds the sum of each skillValue multiplied by the associated weight, then divides by the sum of the weight. 
        // this gives the amount of carrots given. This should be changed to percentage of available carrots obtained.
        //result = (int)(((carrotSkill * carrotWeight) + (botanySkill * botanyWeight) + (skillValue * harvestWeight)) / (carrotWeight + botanyWeight + harvestWeight));
        result = SkillCheck(pairs);

        if(result > availableCarrots)
        {
            result = availableCarrots;
        }
        Debug.Log("Harvested " + result + " carrots");
        return result;
    }
    
public CS_Harvesting()
    {
        skillName = "Harvesting";
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotClass : MonoBehaviour {

	/*This class needs methods for the following activities: Harvest, Sow, Gather Seed, Inspect, Grow
     Alternately, this class needs to access some sort of generic method for the verbs listed above.
         
         */

        // Take relevant skills, weight them, and change the dirt to barren so it is ready to be worked again. Return number of carrots to stockpile.
    public int HarvestCarrots(int botanySkill, int carrotSkill, Plot carrotPlot, DirtClass dirt)
    {
        int availableCarrots = carrotPlot.localCarrots;
        float carrotPotential = (int)(botanySkill * .4) + (int)(carrotSkill * .6) / 100; //percentage of available carrots harvested. NEED TO ADD HARVEST SKILL
        Debug.Log("Heya. Have a carrot or two");
        dirt.SetDirtState(DirtClass.DirtState.Barren); //gotta till the soil for the next batch!

        return (int)(carrotPotential * availableCarrots);
        
    }
}

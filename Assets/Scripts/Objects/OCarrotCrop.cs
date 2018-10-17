using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Crops are to be attached to Plot gameobjects. This crop script gives a detailed breakdown of the carrot plants on the plot.
/// </summary>

public class OCarrotCrop : MonoBehaviour {
    public int maxCarrots; // determined by the size of the plot this crop is attached to.
    private int totalCarrots;
    public int TotalCarrots
    {
        get
        {
            return totalCarrots;
        }
        set
        {
            if (value <= maxCarrots)
            {
                totalCarrots = value;
            }
            else
            {
                totalCarrots = maxCarrots;
            }        
        }
    }
    public int objectScaleFactor = 100000; // The number of real objects the class instance represents.
    public Plot myPlot;
    public int cropAge = 0; // how many turns or days old the crop is
    public List<CarrotCropObject> localCarrotCrops = new List<CarrotCropObject>();

    private void Awake()
    {
        myPlot = this.gameObject.GetComponent<Plot>(); // set the reference to the parent plot on awake.
        maxCarrots = (int)myPlot.plotSize * 1000000; // 1 million carrots *can* be sown per acre
    }

    public void SowCarrots(int carrots) // to be called by a Sow action. Creates carrots % scale # carrotcropobjects
    {
        TotalCarrots = (int)(carrots * Random.Range(0f,1f));
        int cropCount = (int)(TotalCarrots / objectScaleFactor);
        int tempTotal = TotalCarrots;
       // Debug.Log("tempTotal is: " + tempTotal + " in " + this.gameObject.ToString());
        for(int i = 0; i<=cropCount; i++)
        {
           
            if(tempTotal - (objectScaleFactor) >= 0)
            {
                localCarrotCrops.Add(new CarrotCropObject(objectScaleFactor));
                tempTotal -= objectScaleFactor;
                //Debug.Log("Added a full CarrotCropObject with a value of " + objectScaleFactor);
            }
            else
            {
                localCarrotCrops.Add(new CarrotCropObject(tempTotal));
               // Debug.Log("Added a CarrotCropObject with a value of " + tempTotal);
            }
            
        }
    }


    public class CarrotCropObject
    {
        // A model of the carrot plant. Represents a large number of carrots per object instance.

        
        public enum CarrotPhase { Seed, Sprout, Juvenile, Mature, Flowering, Seeding };
        public CarrotPhase carrotPhase;
        public int phaseAge = 0; // increment each turn unless new phase reached
        public int plantCount;


        public CarrotCropObject(int amount) // when an instance of CarrotCropObject is intstantiated, initialize as a seed.
        {
            plantCount = amount;
            carrotPhase = CarrotPhase.Seed;
        }

        public void Grow() // glorified switch. should be called each turn for each object.
        {
            switch(carrotPhase)
            {
                case CarrotPhase.Seed:
                    SeedGrow();
                    return;
                case CarrotPhase.Sprout:
                    SproutGrow();
                    return;
                default:
                    return;
            }
        }

        public void SeedGrow() // how to handle growth as a seed
        {
            //need to factor soil, air, water, sow quality, etc... but that comes later.
            int germAge = (phaseAge - 14);
            if (germAge <= 0)
            {
                germAge = 0;
                return;
            }
            float baseProbability = germAge / 7; //0 -> 100% over seven days
            float chance = Random.Range(0, 1);
            if(chance < baseProbability)
            {
                carrotPhase = CarrotPhase.Sprout;
                phaseAge = 0;
            }
            else
            {
                phaseAge += 1;
            }
        }

        public void SproutGrow() // how to handle growth as a Sprout
        {
            if(phaseAge >= 10)
            {
                carrotPhase = CarrotPhase.Juvenile;
                phaseAge = 0;
            }
            else
            {
                phaseAge += 1;  
            }
        }
    }


}

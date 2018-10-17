using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plot : MonoBehaviour {
    /// <summary>
    /// Primarily this class is concerned with displaying the status of the plots in the farm. 
    /// </summary>
    public GameObject thisPlot;
    public float plotSize = 1; // size determines maximum amounts of crops. Measured in acres (should we be metric here?)

    public int localCarrots; // this should be generalized. Probably reference a custom class called Resources or similar that contains information about the contents of the plot.
    public Color initialColor;
    public OCarrotCrop myCarrotCrop;

    private void Start()
    {
        InitializeCarrots();
    }

    public void InitializeCarrots() // placeholder function until we have proper sowing functionality. 
    {
        myCarrotCrop = this.gameObject.AddComponent<OCarrotCrop>();
        //Debug.Log("Attempting to sow " + myCarrotCrop.maxCarrots + " carrots.");
        myCarrotCrop.SowCarrots(myCarrotCrop.maxCarrots);
        localCarrots = myCarrotCrop.TotalCarrots; // placeholder
        GetComponentInChildren<Text>().text = localCarrots.ToString(); //display num of carrots in plot
    }

    private void Update()
    {
        //Display number of carrots at location 
        GetComponentInChildren<Text>().text = localCarrots.ToString();
        //Need to add a second value for perceived number of carrots
    }

    public void SelectPlot() // called when a plot is clicked. Updates UI and sets the plot to be acted upon by the current active character.
    {
        List<GameObject> takenPlots = new List<GameObject>();
        takenPlots.Clear(); // ensure no data is lurking in the taken plot list
        foreach(GameObject farmer in GameObject.FindGameObjectsWithTag("Player")) // build a list of each plot that a Farmer is already standing in
        {
            if(farmer.GetComponent<Farmer>().currentPlot != null) // make sure not to add non-locations to the list
            {
                takenPlots.Add(farmer.GetComponent<Farmer>().currentPlot);
            }
        }

        if (takenPlots.Contains(thisPlot)) //Check to make sure plot is available
        {
            Debug.Log("This spot is taken!" + thisPlot.ToString());
        }
        else
        {
            GlobalVars.activeFarmer.GetComponent<Farmer>().currentPlot = this.gameObject; // if available, set the active farmer to this plot
            GlobalVars.activeFarmer.GetComponent<Farmer>().queuedAction = GlobalVars.actionDropdown.GetComponent<Dropdown>().value;// Stores the dropdown value in the Farmer script so the Dropdown can be set to this later.
        }

        foreach (GameObject plot in GameObject.FindGameObjectsWithTag("plot")) // cycle through each plot
        {
             plot.GetComponentInChildren<Image>().color = initialColor; // turn each plot back to default color
        }

        foreach (GameObject farmer in GameObject.FindGameObjectsWithTag("Player"))
        {
            Farmer farmerRef = farmer.GetComponent<Farmer>();
            if(farmerRef.currentPlot != null)
            {
                farmerRef.currentPlot.GetComponentInChildren<Image>().color = farmerRef.myColor; // set colors for each plot with a farmer according to their personal color.
            }
        }
    }
}

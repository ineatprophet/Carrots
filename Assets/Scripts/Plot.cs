using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plot : MonoBehaviour {

    public GameObject thisPlot;

    public int localCarrots;

    public enum DirtState { Barren, Worked, InUse };
    DirtState currentState = DirtState.Barren;
    public Color initialColor;

    public void SetDirtState(DirtState state) //to be used by Grow, Harvest, and Till eventually
    {
        currentState = state;
    }


    private void Start()
    {
        InitializeCarrots();
    }

    public void InitializeCarrots()
    {
        localCarrots = Random.Range(0, 100);
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
        Debug.Log("This many spots are taken: " + takenPlots.Count);

        if (takenPlots.Contains(thisPlot)) //Check to make sure plot is available
        {
            Debug.Log("This spot is taken!" + thisPlot.ToString());
        }
        else
        {
            GlobalVars.activeFarmer.GetComponent<Farmer>().currentPlot = this.gameObject; // if available, set the active farmer to this plot
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
                farmerRef.currentPlot.GetComponentInChildren<Image>().color = farmerRef.myColor; // set colors for each plot with a farmer
            }
            
        }
  
    }
}

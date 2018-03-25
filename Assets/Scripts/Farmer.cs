using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Contains the status information for the farmer, including location, name, actions, etc... Mostly just a data store.
/// </summary>
public class Farmer : MonoBehaviour {

    public string farmerName;
    public GameObject currentPlot;
    public string queuedAction;
    public Color myColor;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionDropdown : MonoBehaviour {

    public void DropdownValueChange()
    {
        string action = GetComponentInChildren<Text>().text;
        Debug.Log(action + " selected.");
    }

    private void Awake()
    {
        GlobalVars.actionDropdown = this.gameObject;
    }

    public int SetFarmerQueue()
    {
        return this.gameObject.GetComponent<Dropdown>().value; 
    }




}

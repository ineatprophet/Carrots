using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtClass : MonoBehaviour {

    public enum DirtState {Barren, Worked, InUse};

    DirtState currentState = DirtState.Barren;

    public void SetDirtState(DirtState state) //used by Grow, Harvest, and Till
    {
        currentState = state;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rabbits {

    public static int previousRabbits = 1;
    public static int currentRabbits = 2;

    public static void Breed() //increase rabbit count via Fibonacci sequence
    {
        int temp = currentRabbits; // store initial rabbit count
        currentRabbits = currentRabbits + previousRabbits;
        previousRabbits = temp;
        GlobalVars.rabbitCount = currentRabbits;
    }

    public static void Feed() // decrease stockpile of carrots by 1 per rabbit
    {
        GlobalVars.carrotStockpile -= currentRabbits;
        if(GlobalVars.carrotStockpile < 1)
        {
            GlobalVars.GameOverTrigger();
        }
    }
   
}

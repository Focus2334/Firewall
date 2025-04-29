using ScObjects;
using UnityEngine;

public static class CurrentValues
{
    public static int Points { get; private set; }
    public static MachineScObject CurrentPlayerMachine { get; private set; }

    public static void AddPoints(int value)
    {
        Points += value;
    }

    public static bool BuyForPoints(int price)
    {
        if (Points >= price) 
        { 
            AddPoints(-price);
            return true;
        }
        return false;
    }

    public static void SetCurrentPlayerMachine(MachineScObject newMachine)
    {
        CurrentPlayerMachine = newMachine;
    }
}

using ScObjects;
using UnityEngine;
using System.Collections.Generic;

public static class CurrentValues
{
    public static bool Initialized { get; private set; }

    public static int Points { get; private set; }

    public static MachineScObject CurrentPlayerMachine { get; private set; }

    public static List<MachineScObject> OpenedMachines { get; private set; }

    public static List<MachineScObject> AllAvaibleMachines { get; private set; }

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

    public static void AddToOpenedMachines(MachineScObject newMachine)
    {
        OpenedMachines.Add(newMachine);
    }

    public static void Initialize(List<MachineScObject> machines)
    {
        OpenedMachines = new List<MachineScObject>() { machines[0] };
        AllAvaibleMachines = machines;
        CurrentPlayerMachine = machines[0];
        Initialized = true;
    }
}

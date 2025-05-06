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

    public static WeaponScObject CurrentPlayerWeapon { get; private set; }

    public static List<WeaponScObject> OpenedWeapons { get; private set; }

    public static List<WeaponScObject> AllAvaibleWeapons { get; private set; }

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

    public static void SetCurrentPlayerWeapon(WeaponScObject newMachine)
    {
        CurrentPlayerWeapon = newMachine;
    }

    public static void AddToOpenedWeapons(WeaponScObject newMachine)
    {
        OpenedWeapons.Add(newMachine);
    }

    public static void Initialize(List<MachineScObject> machines, List<WeaponScObject> weapons)
    {
        OpenedMachines = new List<MachineScObject>() { machines[0] };
        OpenedWeapons = new List<WeaponScObject>() { weapons[0] };
        AllAvaibleMachines = machines;
        AllAvaibleWeapons = weapons;
        CurrentPlayerMachine = machines[0];
        CurrentPlayerWeapon = weapons[0];
        Initialized = true;
    }
}

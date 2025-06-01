using ScObjects;
using System.Collections.Generic;

public static class CurrentValues
{
    public static bool Initialized { get; private set; }
    
    public static bool FunnySettings { get; set; }

    public static bool EasyMode { get; set; }

    public static int Points { get; private set; }

    public static int MaxWave { get; set; }

    public static MachineScObject CurrentPlayerMachine { get; private set; }

    public static List<MachineScObject> OpenedMachines { get; private set; }

    public static List<MachineScObject> AllAvailableMachines { get; private set; }

    public static WeaponScObject CurrentPlayerWeapon { get; private set; }

    public static List<WeaponScObject> OpenedWeapons { get; private set; }

    public static List<WeaponScObject> AllAvailableWeapons { get; private set; }

    public static int EnemyCount { get; private set; }

    public static void IncrementEnemies() => EnemyCount++;
    public static void DecrementEnemies() => EnemyCount--;
    public static void ClearEnemies() => EnemyCount = 0;
    
    public static void AddPoints(int value) => Points += value;

    public static bool BuyForPoints(int price)
    {
        if (Points >= price) 
        { 
            AddPoints(-price);
            return true;
        }
        return false;
    }

    public static void SetCurrentPlayerMachine(MachineScObject newMachine) => CurrentPlayerMachine = newMachine;

    public static void AddToOpenedMachines(MachineScObject newMachine) => OpenedMachines.Add(newMachine);

    public static void SetCurrentPlayerWeapon(WeaponScObject newMachine) => CurrentPlayerWeapon = newMachine;

    public static void AddToOpenedWeapons(WeaponScObject newMachine) => OpenedWeapons.Add(newMachine);

    public static void Initialize(PlayerSaveData playerSaveData)
    {
        OpenedMachines = playerSaveData.OpenedMachines;
        OpenedWeapons = playerSaveData.OpenedWeapons;
        AllAvailableMachines = playerSaveData.AllAvailableMachines;
        AllAvailableWeapons = playerSaveData.AllAvailableWeapons;
        CurrentPlayerMachine = playerSaveData.CurrentPlayerMachine;
        CurrentPlayerWeapon = playerSaveData.CurrentPlayerWeapon;
        Initialized = true;
    }
}

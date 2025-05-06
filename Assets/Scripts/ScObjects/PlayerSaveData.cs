using System.Collections.Generic;

namespace ScObjects
{
    public class PlayerSaveData
    {
        public int PlayerMoney;
        public MachineScObject CurrentPlayerMachine;
        public WeaponScObject CurrentPlayerWeapon;
        public List<MachineScObject> OpenedMachines;
        public List<MachineScObject> AllAvailableMachines;
        public List<WeaponScObject> AllAvailableWeapons;
        public List<WeaponScObject> OpenedWeapons;

        public override string ToString()
        {
            return $"{PlayerMoney} {CurrentPlayerMachine} {string.Join('/', AllAvailableMachines)}";
        }
    }
}
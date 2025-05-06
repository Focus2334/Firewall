using ScObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuScript : MonoBehaviour
    {
        [SerializeField] private ShipCanvasScript shipCanvasScript;
        [SerializeField] private List<MachineScObject> playerMachines;

        public void Play() => SceneManager.LoadScene("Game scene");

        public void Exit()
        {
            var saveData = new PlayerSaveData
            {
                AllAvailableMachines = CurrentValues.AllAvailableMachines,
                CurrentPlayerMachine = CurrentValues.CurrentPlayerMachine,
                OpenedMachines = CurrentValues.OpenedMachines,
                PlayerMoney = CurrentValues.Points
            };
            SaveScObject.SavePreservation(saveData);
            Application.Quit();
        }

        public void OpenShipMenu()
        {
            shipCanvasScript.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private void Start()
        {
            if (!CurrentValues.Initialized) 
                if (SaveScObject.TryLoadSave(out var playerSaveData))
                    CurrentValues.Initialize(playerSaveData);
                else
                    CurrentValues.Initialize(new PlayerSaveData
                    {
                        PlayerMoney = 0,
                        AllAvailableMachines = playerMachines,
                        CurrentPlayerMachine = playerMachines[0],
                        OpenedMachines = new List<MachineScObject> { playerMachines[0] },
                        /*OpenedWeapons = ,
                        AllAvailableWeapons = ,
                        CurrentPlayerWeapon = */
                    });
        }
    }
}
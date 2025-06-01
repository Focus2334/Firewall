using ScObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class MainMenuScript : MonoBehaviour
    {
        [SerializeField] private ShipCanvasScript shipCanvasScript;
        [SerializeField] private List<MachineScObject> playerMachines;
        [SerializeField] private List<WeaponScObject> playerWeapons;
        [SerializeField] private GameObject guide;
        [SerializeField] private TMP_Text score;

        public void Play()
        {
            if (CurrentValues.FunnySettings)
                SceneManager.LoadScene("Steel kaput");
            else
                SceneManager.LoadScene("Narrative screen");
        }

        public void FnnyChange()
        {
            CurrentValues.FunnySettings = !CurrentValues.FunnySettings;
        }

        public void EasyChange()
        {
            CurrentValues.EasyMode = !CurrentValues.EasyMode;
        }

        public void TurnOnGuide()
        {
            guide.SetActive(!guide.activeSelf);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void OpenShipMenu()
        {
            shipCanvasScript.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private void Start()
        {
            if (CurrentValues.MaxWave > 0)
                score.text = $"Лучший результат: {CurrentValues.MaxWave} волн(а)";
            CurrentValues.FunnySettings = false;
            CurrentValues.EasyMode = false;
            if (!CurrentValues.Initialized)
                CurrentValues.Initialize(new PlayerSaveData
                {
                    PlayerMoney = 0,
                    AllAvailableMachines = playerMachines,
                    CurrentPlayerMachine = playerMachines[0],
                    OpenedMachines = new List<MachineScObject> { playerMachines[0] },
                    OpenedWeapons = new List<WeaponScObject> { playerWeapons[0] },
                    AllAvailableWeapons = playerWeapons,
                    CurrentPlayerWeapon = playerWeapons[0]
                });
            if (CurrentValues.CurrentPlayerMachine.MachineName == "Steel kaput")
            {
                CurrentValues.SetCurrentPlayerMachine(playerMachines[0]);
                CurrentValues.SetCurrentPlayerWeapon(playerWeapons[0]);
            }
        }
    }
}
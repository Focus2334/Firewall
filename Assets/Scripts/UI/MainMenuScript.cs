using ScObjects;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuScript : MonoBehaviour
    {
        [SerializeField] private ShipCanvasScript shipCanvasScript;

        [SerializeField] private List<MachineScObject> playerMachines;
        [SerializeField] private List<WeaponScObject> playerWeapons;

        public void Play() => SceneManager.LoadScene("Game scene");

        public void Exit() => Application.Quit();

        public void OpenShipMenu()
        {
            shipCanvasScript.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private void Start()
        {
            if (!CurrentValues.Initialized) 
            { 
                CurrentValues.Initialize(playerMachines, playerWeapons);
            }
        }
    }
}
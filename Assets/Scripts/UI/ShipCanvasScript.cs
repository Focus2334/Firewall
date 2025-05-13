using ScObjects;
using TMPro;
using UI;
using UnityEngine;
using System.Collections.Generic;

public class ShipCanvasScript : MonoBehaviour
{
    [SerializeField] private MachineScObject selectedMachine;
    [SerializeField] private WeaponScObject selectedWeapon;
    [SerializeField] private MainMenuScript mainMenu;
    [SerializeField] private TMP_Dropdown shipDropdown;
    [SerializeField] private TMP_Dropdown weaponDropdown;
    [SerializeField] private TMP_Text shipDropdownText;
    [SerializeField] private TMP_Text weaponDropdownText;
    [SerializeField] private TMP_Text buyText;
    [SerializeField] private TMP_Text weaponBuyText;
    [SerializeField] private TMP_Text babloText;
    [SerializeField] private GameObject bablo;

    private int babloAcces = 0;

    public void BuyShip()
    {
        if (CurrentValues.OpenedMachines.Contains(selectedMachine))
        {
            CurrentValues.SetCurrentPlayerMachine(selectedMachine);
            buyText.text = "ÈÑÏÎËÜÇÓÅÒÑß";
        }
        else if (CurrentValues.BuyForPoints(100))
        {
            CurrentValues.SetCurrentPlayerMachine(selectedMachine);
            CurrentValues.OpenedMachines.Add(selectedMachine);
            babloText.text = CurrentValues.Points.ToString();
            buyText.text = "ÈÑÏÎËÜÇÓÅÒÑß";
        }
    }

    public void BuyWeapon()
    {
        if (CurrentValues.OpenedWeapons.Contains(selectedWeapon))
        {
            CurrentValues.SetCurrentPlayerWeapon(selectedWeapon);
            weaponBuyText.text = "ÈÑÏÎËÜÇÓÅÒÑß";
        }
        else if (CurrentValues.BuyForPoints(100))
        {
            CurrentValues.SetCurrentPlayerWeapon(selectedWeapon);
            CurrentValues.OpenedWeapons.Add(selectedWeapon);
            babloText.text = CurrentValues.Points.ToString();
            weaponBuyText.text = "ÈÑÏÎËÜÇÓÅÒÑß";
        }
    }

    public void BABLO()
    {
        CurrentValues.AddPoints(100);
        babloText.text = CurrentValues.Points.ToString();
    }

    public void Exit()
    {
        babloAcces = 0;
        bablo.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChangeSelectedMachine()
    {
        selectedMachine = CurrentValues.AllAvailableMachines[shipDropdown.value];

        if (selectedMachine.MachineName == CurrentValues.CurrentPlayerMachine.MachineName)
        {
            buyText.text = "ÈÑÏÎËÜÇÓÅÒÑß";
        }
        else if (CurrentValues.OpenedMachines.Contains(selectedMachine))
        {
            buyText.text = "ÈÑÏÎËÜÇÎÂÀÒÜ";
        }
        else
        {
            buyText.text = "ÊÓÏÈÒÜ";
        }
    }

    public void ChangeSelectedWeapon()
    {
        selectedWeapon = CurrentValues.AllAvailableWeapons[weaponDropdown.value];
        if (selectedWeapon.WeaponName == CurrentValues.CurrentPlayerWeapon.WeaponName)
        {
            weaponBuyText.text = "ÈÑÏÎËÜÇÓÅÒÑß";
        }
        else if (CurrentValues.OpenedWeapons.Contains(selectedWeapon))
        {
            weaponBuyText.text = "ÈÑÏÎËÜÇÎÂÀÒÜ";
        }
        else
        {
            weaponBuyText.text = "ÊÓÏÈÒÜ";
        }
    }

    private void Start()
    {
        selectedMachine = CurrentValues.AllAvailableMachines[0];
        shipDropdownText.text = selectedMachine.MachineName;
        babloText.text = CurrentValues.Points.ToString();
        
        foreach (var item in CurrentValues.AllAvailableMachines)
        {
            shipDropdown.options.Add(new TMP_Dropdown.OptionData(item.MachineName));
        }

        selectedWeapon = CurrentValues.AllAvailableWeapons[0];
        weaponDropdownText.text = selectedWeapon.WeaponName;

        foreach (var item in CurrentValues.AllAvailableWeapons)
        {
            weaponDropdown.options.Add(new TMP_Dropdown.OptionData(item.WeaponName));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            babloAcces++;
            if (babloAcces > 10)
            {
                bablo.SetActive(true);
            }
        }
    }
}

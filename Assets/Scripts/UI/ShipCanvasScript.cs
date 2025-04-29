using ScObjects;
using TMPro;
using UI;
using UnityEngine;
using System.Collections.Generic;

public class ShipCanvasScript : MonoBehaviour
{
    [SerializeField] private MachineScObject selectedMachine;
    [SerializeField] private MainMenuScript mainMenu;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text dropdownText;
    [SerializeField] private TMP_Text buyText;
    [SerializeField] private TMP_Text babloText;
    [SerializeField] private GameObject bablo;

    private int babloAcces = 0;

    public void Buy()
    {
        if (CurrentValues.OpenedMachines.Contains(selectedMachine))
        {
            CurrentValues.SetCurrentPlayerMachine(selectedMachine);
            print("i");
        }
        else if (CurrentValues.BuyForPoints(100))
        {
            CurrentValues.SetCurrentPlayerMachine(selectedMachine);
            CurrentValues.OpenedMachines.Add(selectedMachine);
            babloText.text = CurrentValues.Points.ToString();
            print(CurrentValues.Points);
        }
    }

    public void BABLO()
    {
        CurrentValues.AddPoints(100);
        babloText.text = CurrentValues.Points.ToString();
        print(CurrentValues.Points);
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
        selectedMachine = CurrentValues.AllAvaibleMachines[dropdown.value];
        if (CurrentValues.OpenedMachines.Contains(selectedMachine))
        {
            buyText.text = "ÈÑÏÎËÜÇÎÂÀÒÜ";
        }
        else
        {
            buyText.text = "ÊÓÏÈÒÜ";
        }
    }

    private void Start()
    {
        selectedMachine = CurrentValues.AllAvaibleMachines[0];
        dropdownText.text = selectedMachine.MachineName;
        babloText.text = CurrentValues.Points.ToString();
        
        foreach (var item in CurrentValues.AllAvaibleMachines)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(item.MachineName));
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

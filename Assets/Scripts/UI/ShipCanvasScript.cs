using ScObjects;
using UI;
using UnityEngine;

public class ShipCanvasScript : MonoBehaviour
{
    [SerializeField] MachineScObject machine;
    [SerializeField] MainMenuScript mainMenu;
    public void Buy()
    {
        if (CurrentValues.BuyForPoints(100))
        {
            CurrentValues.SetCurrentPlayerMachine(machine);
            print(CurrentValues.Points);
        }
    }

    public void BABLO()
    {
        CurrentValues.AddPoints(100);
        print(CurrentValues.Points);
    }

    public void Exit()
    {
        mainMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

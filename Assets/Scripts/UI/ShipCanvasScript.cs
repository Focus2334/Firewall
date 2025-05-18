using ScObjects;
using TMPro;
using UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShipCanvasScript : MonoBehaviour
{
    private MachineScObject selectedMachine;
    private WeaponScObject selectedWeapon;
    [SerializeField] private MainMenuScript mainMenu;
    [SerializeField] private TMP_Dropdown shipDropdown;
    [SerializeField] private TMP_Dropdown weaponDropdown;
    [SerializeField] private TMP_Text shipDropdownText;
    [SerializeField] private TMP_Text weaponDropdownText;
    [SerializeField] private TMP_Text buyText;
    [SerializeField] private TMP_Text weaponBuyText;
    [SerializeField] private TMP_Text babloText;
    [SerializeField] private GameObject bablo;
    [SerializeField] private Image shipImage;
    [SerializeField] private Image weaponImage;
    [SerializeField] private TMP_Text shipInfoSpeed;
    [SerializeField] private TMP_Text shipInfoAccel;
    [SerializeField] private TMP_Text shipInfoHP;
    [SerializeField] private TMP_Text shipInfoRec;
    [SerializeField] private TMP_Text shipInfoEnergy;
    [SerializeField] private TMP_Text shipInfoEnergyRec;
    [SerializeField] private TMP_Text weaponInfoDamage;
    [SerializeField] private TMP_Text weaponInfoRate;
    [SerializeField] private TMP_Text weaponInfoSize;
    [SerializeField] private TMP_Text weaponInfoReloadSpeed;
    [SerializeField] private TMP_Text weaponInfoProjVelocity;

    private int babloAcces = 0;

    public void BuyShip()
    {
        if (CurrentValues.OpenedMachines.Contains(selectedMachine))
        {
            CurrentValues.SetCurrentPlayerMachine(selectedMachine);
            buyText.text = "������������";
        }
        else if (CurrentValues.BuyForPoints(100))
        {
            CurrentValues.SetCurrentPlayerMachine(selectedMachine);
            CurrentValues.OpenedMachines.Add(selectedMachine);
            babloText.text = CurrentValues.Points.ToString();
            buyText.text = "������������";
        }
    }

    public void BuyWeapon()
    {
        if (CurrentValues.OpenedWeapons.Contains(selectedWeapon))
        {
            CurrentValues.SetCurrentPlayerWeapon(selectedWeapon);
            weaponBuyText.text = "������������";
        }
        else if (CurrentValues.BuyForPoints(100))
        {
            CurrentValues.SetCurrentPlayerWeapon(selectedWeapon);
            CurrentValues.OpenedWeapons.Add(selectedWeapon);
            babloText.text = CurrentValues.Points.ToString();
            weaponBuyText.text = "������������";
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
        shipImage.sprite = selectedMachine.Sprite;
        shipInfoSpeed.text = $"��������: {selectedMachine.MaxSpeed}";
        shipInfoAccel.text = $"���������: {selectedMachine.Acceleration}";
        shipInfoHP.text = $"��������: {selectedMachine.HitPoints}";
        shipInfoRec.text = $"��������������: {selectedMachine.HitPointsRecoverSpeed}";
        shipInfoEnergy.text = $"�������: {selectedMachine.MaxStamina}";
        shipInfoEnergyRec.text = $"�������������� �������: {selectedMachine.StaminaRecoverSpeed}";
        if (selectedMachine.MachineName == CurrentValues.CurrentPlayerMachine.MachineName)
        {
            buyText.text = "������������";
        }
        else if (CurrentValues.OpenedMachines.Contains(selectedMachine))
        {
            buyText.text = "������������";
        }
        else
        {
            buyText.text = "������[100]";
        }
    }

    public void ChangeSelectedWeapon()
    {
        selectedWeapon = CurrentValues.AllAvailableWeapons[weaponDropdown.value];
        weaponImage.sprite = selectedWeapon.Texture;
        weaponInfoDamage.text = $"����: {selectedWeapon.Damage}";
        weaponInfoRate.text = $"�����-\r\n�����������: {selectedWeapon.FireRate}";
        weaponInfoSize.text = $"���-�� \r\n��������: {selectedWeapon.MagSize}";
        weaponInfoReloadSpeed.text = $"����� \r\n�����������: {selectedWeapon.ReloadTime}";
        weaponInfoProjVelocity.text = $"�������� \r\n�������: {selectedWeapon.Projectile.BulletSpeed}";
        if (selectedWeapon.WeaponName == CurrentValues.CurrentPlayerWeapon.WeaponName)
        {
            weaponBuyText.text = "������������";
        }
        else if (CurrentValues.OpenedWeapons.Contains(selectedWeapon))
        {
            weaponBuyText.text = "������������";
        }
        else
        {
            weaponBuyText.text = "������[100]";
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
        ChangeSelectedWeapon();
        ChangeSelectedMachine();
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

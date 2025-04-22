using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScObjects;
using UI;
using Weapon;

namespace Player
{
    public class PlayerScript : MonoBehaviour, ICanTakeDamage
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private WeaponScript weaponScript;
        [SerializeField] private WeaponbarScript weaponBar;
        [SerializeField] private HPbarScript HPBar;
        [SerializeField] private EnergyBarScript energyBar;
        [SerializeField] private MachineScObject machineSc; 
        //��� ������, � ������� ���� SerializeField ���� ������, ��� ������ ����� ���������� ����� ��������� ������
        [SerializeField] private WeaponScObject weaponSc;
        //��� ������, � ������� ���� SerializeField ���� ������, ��� ������ ����� ���������� ����� ��������� ������

        public Rigidbody2D PlayerRigidbody2D { get; private set; }
        public MachineScObject MachineScObject => machineSc;
        private float currentHp;
        private float currentStamina;

        private float dashTimer;

        public bool TakeDamage(float value)
        {
            currentHp -= value;
            HPBar.SetBarProgress(currentHp / machineSc.HitPoints);
            HPBar.SetText(currentHp.ToString());
            if (currentHp <= 0)
            {
                currentHp -= value;
                if (currentHp <= 0) 
                    Death();
                return true;
            }
            
            return true;
        }

        public void AddStamina(float value)
        {
            currentStamina += value;
            energyBar.SetBarProgress(currentStamina / machineSc.MaxStamina);
            energyBar.SetText(math.round(currentStamina).ToString());
        }

        public void SetStamina(float value)
        {
            currentStamina = value;
            energyBar.SetBarProgress(currentStamina / machineSc.MaxStamina);
            energyBar.SetText(math.round(currentStamina).ToString());
        }

        private bool Fire()
        {
            var current = weaponScript.Fire();
            if (current > 0) 
                UpdateWeaponBar(current.ToString(), Color.white);
            
            return true;
        }

        private void UpdateWeaponBar(string value, Color color) => weaponBar.UpdateNumber(value, color);

        private void Death() => SceneManager.LoadScene("Main menu");

        private void Start()
        {
            weaponScript.SetScObject(weaponSc);
            weaponBar.UpdateName(weaponSc.WeaponName);
            UpdateWeaponBar(weaponSc.MagSize.ToString(), Color.white);
            currentHp = machineSc.HitPoints;
            currentStamina = machineSc.MaxStamina;
            PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            playerMovement.MovePlayer(playerInput.GetMovementInput());
            playerMovement.RotatePlayer(playerInput.GetMousePosition());
            if (playerInput.GetFireInput()) 
                Fire();

            if (playerInput.GetDashInput() && currentStamina >= machineSc.DashStaminaNeed)
            {
                playerMovement.Dash();
                dashTimer = machineSc.DashTime;
            }

            if (playerInput.GetReloadInput())
            {
                weaponScript.StartReloadWeapon();
            }
            
            if (dashTimer > 0)
            {
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    playerMovement.FinishDash();
                }
            }
            
            if (weaponScript.Reloading)
            {
                UpdateWeaponBar((math.round(weaponScript.ReloadTimer * 10) / 10).ToString(), 
                    new Color(0.63f, 0.15f, 0.05f, 1));
                
                if (weaponScript.ReloadTimer - Time.deltaTime <= 0) 
                    UpdateWeaponBar(weaponSc.MagSize.ToString(), Color.white);
            }

            if (currentStamina < machineSc.MaxStamina)
            {
                AddStamina(machineSc.StaminaRecoverSpeed * Time.deltaTime);
                if (currentStamina >= machineSc.MaxStamina)
                    SetStamina(machineSc.MaxStamina);
            }
        }
    }
}
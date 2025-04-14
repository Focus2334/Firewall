using UnityEngine;

namespace Player
{
    public class PlayerScript : MonoBehaviour, ICanTakeDamage
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private WeaponScript weaponScript;
        [SerializeField] private MachineScObject machineSc;
        [SerializeField] private WeaponScObject weaponSc;

        public Rigidbody2D PlayerRigidbody2D { get; private set; }
        private float currentHp;

        public bool TakeDamage(float value)
        {
            currentHp -= value;
            if (currentHp <= 0)
            {
                Death();
            }

            print(currentHp);
            return true;
        }

        public bool Fire()
        {
            weaponScript.Fire();
            return true;
        }

        private bool Death()
        {
            print("player dead");
            return true;
        }

        private void Start()
        {
            weaponScript.SetScObject(weaponSc);
            currentHp = machineSc.HitPoints;
            print(currentHp);
            PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            playerMovement.MovePlayer(playerInput.GetMovementInput());
            playerMovement.RotatePlayer(playerInput.GetMousePosition());
            if (playerInput.GetFireInput())
            {
                weaponScript.Fire();
            }
        }
    }
}
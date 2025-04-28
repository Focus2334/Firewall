using UnityEngine;

namespace ScObjects
{
    [CreateAssetMenu(fileName = "New MachineData", menuName = "Machine Data", order = 51)]
    public class MachineScObject : ScriptableObject
    {
        [SerializeField] private string machineName;
        [SerializeField] private Texture2D texture;
        [SerializeField] private Sprite sprite;
        [SerializeField] private float hitPoints;
        [SerializeField] private float hitPointsRecoverSpeed;
        [SerializeField] private float maxStamina;
        [SerializeField] private float staminaRecoverSpeed;
        [SerializeField] private float dashStaminaNeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float maxDashSpeed;
        [SerializeField] private float dashAccel;
        [SerializeField] private float dashTime;
        public string MachineName => machineName;
        
        public Sprite Sprite => sprite;

        public Texture2D Texture => texture;

        public float HitPoints => hitPoints;

        public float HitPointsRecoverSpeed => hitPointsRecoverSpeed;

        public float MaxStamina => maxStamina;

        public float StaminaRecoverSpeed => staminaRecoverSpeed;

        public float MaxSpeed => maxSpeed;

        public float Acceleration => acceleration;
         
        public float DashStaminaNeed => dashStaminaNeed;

        public float MaxDashSpeed => maxDashSpeed;

        public float DashAccel => dashAccel;

        public float DashTime => dashTime;
    }
}
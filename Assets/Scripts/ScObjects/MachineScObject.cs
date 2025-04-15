using UnityEngine;

namespace ScObjects
{
    [CreateAssetMenu(fileName = "New MachineData", menuName = "Machine Data", order = 51)]
    public class MachineScObject : ScriptableObject
    {
        [SerializeField] private string machineName;
        [SerializeField] private Texture2D texture;
        [SerializeField] private float hitPoints;
        [SerializeField] private float hitPointsRecoverSpeed;

        public string MachineName => machineName;

        public Texture2D Texture => texture;

        public float HitPoints => hitPoints;

        public float HitPointsRecoverSpeed => hitPointsRecoverSpeed;
    }
}
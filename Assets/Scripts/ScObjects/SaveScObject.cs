using UnityEngine;

namespace ScObjects
{
    [CreateAssetMenu(fileName = "New SaveData", menuName = "Save Data", order = 55)]
    public class SaveScObject : ScriptableObject
    {
        private int points;

        public int Points { get { return points; } set { points = value; } }
    }
}
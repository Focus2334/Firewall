using TMPro;
using UnityEngine;

namespace UI
{
    public class WeaponBarScript : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI projCount;
        [SerializeField] private TextMeshProUGUI weaponName;

        public void UpdateName(string newWeaponName) => weaponName.SetText(newWeaponName);

        public void UpdateNumber(string newProjectileName, Color color)
        {
            projCount.SetText(newProjectileName);
            projCount.color = color;
        }
    }
}
using System;
using TMPro;
using UnityEngine;

public class WeaponbarScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI projCount;
    [SerializeField] private TextMeshProUGUI weaponName;

    public void UpdateName(string name)
    {
        weaponName.SetText(name);
    }

    public void UpdateNumber(string name)
    {
        projCount.SetText(name);
    }
}

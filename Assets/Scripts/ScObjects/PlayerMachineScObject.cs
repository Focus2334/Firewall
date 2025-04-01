using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MachineData", menuName = "Machine Data", order = 51)]
public class PlayerMachineScObject : ScriptableObject
{
    [SerializeField]
    private string machineName;
    [SerializeField]
    private Texture2D texture;
    [SerializeField]
    private double HitPoints;
    [SerializeField]
    private double HitPointsRecoverSpeed;
}

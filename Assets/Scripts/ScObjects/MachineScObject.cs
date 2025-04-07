using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MachineData", menuName = "Machine Data", order = 51)]
public class MachineScObject : ScriptableObject
{
    [SerializeField]
    private string machineName;
    [SerializeField]
    private Texture2D texture;
    [SerializeField]
    private float hitPoints;
    [SerializeField]
    private float hitPointsRecoverSpeed;

    public string MachineName { get { return machineName; } }
    public Texture2D Texture { get { return texture; } }
    public float HitPoints {  get { return hitPoints; } }
    public float HitPointsRecoverSpeed { get { return hitPointsRecoverSpeed; } }
}

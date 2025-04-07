using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 53)]
public class EnemyScObject : ScriptableObject
{
    [SerializeField]
    private string enemyName;
    [SerializeField]
    private MachineScObject machine;
    [SerializeField]
    private WeaponScObject weapon;

    public string EnemyName { get { return enemyName; } }
    public MachineScObject Machine { get { return machine; } }
    public WeaponScObject Weapon { get { return weapon; } }
}

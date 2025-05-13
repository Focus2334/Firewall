using UnityEngine;

public class EnemyPointsScript : MonoBehaviour, IProjectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CurrentValues.AddPoints(50);
            Destroy(gameObject);
        }
    }
}

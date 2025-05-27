using UnityEngine;

public class HitScript : MonoBehaviour
{
    [SerializeField] private float lifetime = 0.1f;

    private void Awake()
    {
        var newT = transform.position;
        newT.z = -9;
        transform.position = newT;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if ( lifetime < 0 )
            Destroy(gameObject);
    }
}

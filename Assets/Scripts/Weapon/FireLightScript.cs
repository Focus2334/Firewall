using UnityEngine;

public class FireLightScript : MonoBehaviour
{
    private float lifetime = 0.05f;
    [SerializeField] private Light lights;
    private void Update()
    {
        lifetime -= Time.deltaTime;
        lights.range *= 1.02f;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }

    }
}

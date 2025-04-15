using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Weapon
{
    public class FireLightScript : MonoBehaviour
    {
        private float lifetime = 0.05f;
        [SerializeField] private Light2D lights;

        private void Update()
        {
            lifetime -= Time.deltaTime;
            lights.pointLightOuterRadius *= 1.02f;
            if (lifetime < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
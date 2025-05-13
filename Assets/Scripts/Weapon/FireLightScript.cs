using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Weapon
{
    public class FireLightScript : MonoBehaviour
    {
        [SerializeField] private float lifetime = 0.05f;
        [SerializeField] private Light2D lights;

        private void Update()
        {
            lifetime -= Time.deltaTime;
            if (!(lights is null))
            {
                lights.pointLightOuterRadius += 10f * Time.deltaTime;
            }
            
            if (lifetime < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
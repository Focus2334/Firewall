using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EnergyBarScript : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        public void SetBarProgress(float progress) => image.fillAmount = progress;

        public void SetText(string text) => textMeshProUGUI.text = text;
    }
}


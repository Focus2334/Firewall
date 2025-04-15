using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HPbarScript : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        public void SetBarProgress(float progress) => image.fillAmount = progress;

        public void SetText(string text) => textMeshProUGUI.text = text;
    }
}
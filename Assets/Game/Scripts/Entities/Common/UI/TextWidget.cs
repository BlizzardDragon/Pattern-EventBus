using TMPro;
using UnityEngine;

namespace Roguelike_EventBus.Common.UI
{
    public sealed class TextWidget : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        public void SetText(string value)
        {
            text.text = value;
        }
    }
}
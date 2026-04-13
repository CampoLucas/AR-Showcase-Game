using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AR.UI.Buttons
{
    public class ToggleButton : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool startsOn;
        [SerializeField] private bool changeColor;

        [Header("Toggle Button")]
        [SerializeField] private Button button;
        [SerializeField] private Image img;
        [SerializeField] private Color onColor;
        [SerializeField] private Color offColor;

        [Header("Events")]
        [SerializeField] private UnityEvent toggleOn;
        [SerializeField] private UnityEvent toggleOff;

        private bool _on = false;

        private void Awake()
        {
            if (button)
            {
                button.onClick.AddListener(OnToggleHandler);
            }

            Set(startsOn);
        }

        private void OnToggleHandler()
        {
            Toggle();
        }

        public void Toggle()
        {
            Set(!_on);
        }

        public void Set(bool value)
        {

            _on = value;
            if (value)
            {
                if (changeColor) img.color = onColor;
                toggleOn.Invoke();
            }
            else
            {
                if (changeColor) img.color = offColor;
                toggleOff.Invoke();
            }
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnToggleHandler);
            button = null;
            img = null;

            toggleOn.RemoveAllListeners();
            toggleOff.RemoveAllListeners();

            toggleOn = null;
            toggleOff = null;
        }
    }
}

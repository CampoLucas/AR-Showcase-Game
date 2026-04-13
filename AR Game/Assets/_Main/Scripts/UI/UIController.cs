using UnityEngine;

namespace AR.UI.Buttons
{
    public class UIController : MonoBehaviour
    {
        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }
    }
}
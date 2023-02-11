using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScreenFade : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

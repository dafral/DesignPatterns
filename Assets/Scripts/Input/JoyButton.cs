using UnityEngine;
using UnityEngine.EventSystems;

namespace MyInput
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool IsPressed { get; private set; }
        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressed = true;
        }

    }
}

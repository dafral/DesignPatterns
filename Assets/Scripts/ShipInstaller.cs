using UnityEngine;

namespace Ships
{

    public class ShipInstaller : MonoBehaviour
    {
        private enum InputType { Keyboard, Joystick };

        [SerializeField] private InputType _inputType;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.Configure(GetInput());
        }

        private IInput GetInput()
        {
            if (_inputType == InputType.Keyboard)
            {
                Destroy(_joystick.gameObject);
                return new UnityInputAdapter();
            }
            else 
            {
                return new JoystickInputAdapter(_joystick);
            }
        }
    }
}

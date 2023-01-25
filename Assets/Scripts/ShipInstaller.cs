using System;
using UnityEngine;

namespace Ships
{

    public class ShipInstaller : MonoBehaviour
    {
        private enum InputType { Keyboard, Joystick, AI };
        private enum CheckLimitsType { Viewport, InitialPosition}

        [SerializeField] private InputType _inputType;
        [SerializeField] private CheckLimitsType _checkLimitsType;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.Configure(GetInput(), GetCheckLimits());
        }

        private IInput GetInput()
        {
            if(_inputType == InputType.AI)
            {
                Destroy(_joystick.gameObject);
                return new AIInputAdapter(_ship);
            }
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

        private ICheckLimits GetCheckLimits()
        {
            if(_checkLimitsType == CheckLimitsType.Viewport)
            {
                return new ViewportCheckLimits(_ship.transform, Camera.main);
            }
            else 
            {
                return new InitialPositionCheckLimits(_ship.transform, 3.5f);
            }
        }
    }
}

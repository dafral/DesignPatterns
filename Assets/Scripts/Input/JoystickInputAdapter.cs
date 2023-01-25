using UnityEngine;

namespace MyInput
{
    public class JoystickInputAdapter : IInput
    {
        private readonly Joystick _joystick;
        private readonly JoyButton _joyButton;

        public JoystickInputAdapter(Joystick joystick, JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }

        public bool IsFireActionPressed()
        {
            return _joyButton.IsPressed;
        }
    }
}

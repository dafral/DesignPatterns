using MyInput;
using Ships.Enemies;
using UnityEngine;
using UnityEngine.Assertions;

namespace Ships.Common
{
    public class ShipBuilder
    {
        public enum InputType { Keyboard, Joystick, AI };
        public enum CheckLimitsType { Viewport, InitialPosition }

        private Ship _prefab;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private IInput _input;
        private InputType _inputType;
        private ICheckLimits _checkLimits;
        private CheckLimitsType _checkLimitsType;
        private ShipToSpawnConfiguration _shipConfiguration;
        private Joystick _joystick;
        private JoyButton _joyButton;

        public ShipBuilder FromPrefab(Ship prefab)
        {
            _prefab = prefab;
            return this;
        }

        public ShipBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public ShipBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public ShipBuilder WithCheckLimitsType(CheckLimitsType checkLimitsType)
        {
            _checkLimitsType = checkLimitsType;
            return this;
        }

        public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipConfiguration)
        {
            _shipConfiguration = shipConfiguration;
            return this;
        }

        public ShipBuilder WithInputType(InputType inputType)
        {
            _inputType = inputType;
            return this;
        }

        public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton;
            return this;
        }

        private IInput GetInput(Ship ship)
        {
            if(_input != null)
            {
                return _input;
            }

            switch (_inputType)
            {
                case InputType.Keyboard:
                    return new UnityInputAdapter();
                case InputType.Joystick:
                    Assert.IsNotNull(_joystick, "Joystick is null!");
                    Assert.IsNotNull(_joyButton, "JoyButton is null!");
                    return new JoystickInputAdapter(_joystick, _joyButton);
                case InputType.AI:
                    return new AIInputAdapter(ship);
                default:
                    return new UnityInputAdapter();
            }
        }

        private ICheckLimits GetCheckLimits(Ship ship)
        {
            if (_input != null)
            {
                return _checkLimits;
            }

            switch (_checkLimitsType)
            {
                case CheckLimitsType.Viewport:
                    return new ViewportCheckLimits(ship.transform, Camera.main);
                case CheckLimitsType.InitialPosition:
                    return new InitialPositionCheckLimits(ship.transform, 10);
                default:
                    return new ViewportCheckLimits(ship.transform, Camera.main);
            }
        }

        public Ship Build()
        {
            Ship ship = Object.Instantiate(_prefab, _position, _rotation);
            ShipConfiguration shipConfiguration = new ShipConfiguration(
                                                  GetInput(ship),
                                                  GetCheckLimits(ship),
                                                  _shipConfiguration.Speed,
                                                  _shipConfiguration.FireRate,
                                                  _shipConfiguration.ProjectileId);

            ship.Configure(shipConfiguration);
            return ship;
        }
    }
}

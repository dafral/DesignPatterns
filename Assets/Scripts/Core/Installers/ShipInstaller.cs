using UnityEngine;
using MyInput;
using Ships.Enemies;
using Ships.Common;
using InputType = Ships.Common.ShipBuilder.InputType;
using CheckLimitsType = Ships.Common.ShipBuilder.CheckLimitsType;
using System;
using Core.Services;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private InputType _inputType;
        [SerializeField] private CheckLimitsType _checkLimitsType;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joyButton;

        [Header("Configurations")]
        [SerializeField] private ShipToSpawnConfiguration _shipToSpawnConfiguration;
        
        private ShipBuilder _shipBuilder;

        private void Awake()
        {
            ShipFactory _shipFactory = ServiceLocator.Instance.GetService<ShipFactory>();
            _shipBuilder = _shipFactory.
                           Create(_shipToSpawnConfiguration.ShipId.Value).
                           WithConfiguration(_shipToSpawnConfiguration).
                           WithTeam(Teams.Player);

            SetInput(_shipBuilder);
            SetCheckLimits(_shipBuilder);
        }

        public void SpawnUserShip()
        {
            _shipBuilder.Build();
        }

        private void SetInput(ShipBuilder shipBuilder)
        {
            shipBuilder.WithInputType(_inputType);

            if (_inputType == InputType.Joystick)
            {
                shipBuilder.WithJoysticks(_joystick, _joyButton);
            }
            else 
            {
                Destroy(_joystick.gameObject);
                Destroy(_joyButton.gameObject);
            }
        }

        private void SetCheckLimits(ShipBuilder shipBuilder)
        {
            shipBuilder.WithCheckLimitsType(_checkLimitsType);
        }
    }
}

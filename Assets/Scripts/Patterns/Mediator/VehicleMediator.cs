using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleMediator : MonoBehaviour, IVehicle
    {
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _lights;
        [SerializeField] private SteeringWheel _steeringWheel;
        [SerializeField] private Brake _brake;
        [SerializeField] private AutoPilot _autoPilot;

        private void Awake()
        {
            _steeringWheel.Configure(this);
            _brake.Configure(this);
            _autoPilot.Configure(this);
        }

        public void BrakePressed()
        {
            foreach (Wheel wheel in _wheels)
            {
                wheel.AddFriction();
            }

            foreach (VehicleLight brakeLight in _lights)
            {
                brakeLight.TurnOn();
            }
        }

        public void BrakeReleased()
        {
            foreach (Wheel wheel in _wheels)
            {
                wheel.ReleaseFriction();
            }

            foreach (VehicleLight brakeLight in _lights)
            {
                brakeLight.TurnOff();
            }
        }

        public void LeftPressed()
        {
            foreach (Wheel wheel in _wheels)
            {
                wheel.TurnLeft();
            }
        }

        public void RightPressed()
        {
            foreach (Wheel wheel in _wheels)
            {
                wheel.TurnRight();
            }
        }

        public void OnObstacleDetected()
        {
            BrakePressed();
        }
    }
}

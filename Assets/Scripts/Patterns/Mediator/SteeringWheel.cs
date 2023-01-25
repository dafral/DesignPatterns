using UnityEngine;

namespace Patterns.Mediator
{
    public class SteeringWheel : MonoBehaviour
    {
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Left"))
            {
                _vehicle.LeftPressed();
            }
            else if (Input.GetButtonDown("Right"))
            {
                _vehicle.RightPressed();
            }

        }
    }
}

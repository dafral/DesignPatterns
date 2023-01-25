using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void Update()
        {
            if(Input.GetButtonDown("Break"))
            {
                _vehicle.BrakePressed();
            }
            else if(Input.GetButtonUp("Break"))
            {
                _vehicle.BrakeReleased();
            }
        }
    }
}

using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleLight
    {
        internal void TurnOn()
        {
            Debug.Log("Turning light ON!");
        }

        internal void TurnOff()
        {
            Debug.Log("Turning light OFF!");
        }
    }
}

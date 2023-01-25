using UnityEngine;

namespace Patterns.Mediator
{
    public class Wheel
    {
        internal void AddFriction()
        {
            Debug.Log("ADDING friction to wheel!");
        }

        internal void ReleaseFriction()
        {
            Debug.Log("RELEASING friction to wheel!");
        }

        internal void TurnLeft()
        {
            Debug.Log("Turning wheel to LEFT!");
        }

        internal void TurnRight()
        {
            Debug.Log("Turning wheel to RIGHT!");
        }
    }
}

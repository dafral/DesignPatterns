using UnityEngine;

namespace MyInput
{
    public interface IInput
    {
        public Vector2 GetDirection();
        public bool IsFireActionPressed();
    }
}

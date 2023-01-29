using UnityEngine;

namespace Ships
{
    public interface ICheckLimits
    {
        public Vector2 ClampFinalPosition(Vector2 currentPosition);
    }
}

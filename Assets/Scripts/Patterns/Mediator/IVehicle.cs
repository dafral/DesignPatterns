namespace Patterns.Mediator
{
    public interface IVehicle
    {
        void BrakeReleased();
        void BrakePressed();
        void RightPressed();
        void LeftPressed();
        void OnObstacleDetected();
    }
}

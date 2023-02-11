namespace UI
{
    public interface IGameMenuMediator
    {
        public void OnBackToMenuPressed();
        public void OnRestartGamePressed();
        public void OnResumeGamePressed();
        public void OnPauseGamePressed();
    }
}

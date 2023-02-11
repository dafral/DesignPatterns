using UnityEngine;

namespace UI
{
    public abstract class MenuView : MonoBehaviour
    {
        public abstract void Configure(IGameMenuMediator gameMenuMediator);
        public abstract void Show();
        public abstract void Hide();
    }
}

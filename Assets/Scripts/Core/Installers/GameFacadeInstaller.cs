using UnityEngine;
using Core.Services;
using Battle;

namespace Core.Installers
{
    public class GameFacadeInstaller : Installer
    {
        [SerializeField] private GameFacade _gameFacade;

        public override void Install(ServiceLocator serviceLocator)
        {
            ServiceLocator.Instance.RegisterService<IGameFacade>(_gameFacade);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.UnregisterService<IGameFacade>();
        }
    }
}

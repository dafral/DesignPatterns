using UI;
using UnityEngine;
using Core.Services;
using Core.Commands;

namespace Core.Installers
{
    public class LoadingScreenInstaller : Installer
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_loadingScreen.gameObject);
            serviceLocator.RegisterService(_loadingScreen);
        }
    }
}
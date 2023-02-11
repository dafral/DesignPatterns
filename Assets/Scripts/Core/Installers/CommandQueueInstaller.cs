using UnityEngine;
using Core.Services;
using Core.Commands;

namespace Core.Installers
{
    public class CommandQueueInstaller : Installer
    {
        [SerializeField] private CommandQueue _commandQueue;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_commandQueue.gameObject);
            serviceLocator.RegisterService(_commandQueue);
        }
    }
}
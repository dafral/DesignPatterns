using UnityEngine;
using UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Core.Services;
using Core.Commands;

namespace Core.Installers
{
    public class GlobalInstaller : GeneralInstaller
    {
        protected override void DoStart()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));
        }

        protected override void DoInstallDependencies()
        {

        }
    }
}
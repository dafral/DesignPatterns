using UnityEngine;
using UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Core.Services;

namespace Core
{
    public class GlobalInstaller : GeneralInstaller
    {
        protected override async void DoStart()
        {
            await LoadNextScene();
        }

        protected override void DoInstallDependencies()
        {

        }

        private async Task LoadNextScene()
        {
            LoadingScreen loadingScreen = ServiceLocator.Instance.GetService<LoadingScreen>();
            loadingScreen.Show();
            await LoadScene("Game");
            loadingScreen.Hide();
        }

        private async Task LoadScene(string sceneName)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while(!loadSceneAsync.isDone)
            {
                await Task.Yield();
            }

            // Loading frame for precaution
            await Task.Yield();
        }

    }
}
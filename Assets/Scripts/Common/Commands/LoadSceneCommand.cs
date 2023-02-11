using Core.Services;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Commands
{
    public class LoadSceneCommand : ICommand
    {
        private readonly string _sceneToLoad;

        public LoadSceneCommand(string sceneToLoad)
        {
            _sceneToLoad = sceneToLoad;
        }

        public async Task Execute()
        {
            LoadingScreen loadingScreen = ServiceLocator.Instance.GetService<LoadingScreen>();
            loadingScreen.Show();
            await LoadScene(_sceneToLoad);
            loadingScreen.Hide();
        }

        private async Task LoadScene(string sceneName)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                await Task.Yield();
            }

            // Loading frame for precaution
            await Task.Yield();
        }
    }
}

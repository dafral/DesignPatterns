using Core.Services;
using System.Threading.Tasks;
using UI;

namespace Core.Commands
{
    public class HideScreenFadeCommand : ICommand
    {
        public async Task Execute()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Hide();
            await Task.Delay(200);
        }
    }
}

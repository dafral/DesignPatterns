using Core.Services;
using System.Threading.Tasks;
using UI;

namespace Core.Commands
{
    public class ShowScreenFadeCommand : ICommand
    {
        public async Task Execute()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Show();
            await Task.Delay(200);
        }
    }
}

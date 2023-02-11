using System.Threading.Tasks;
using Core.Services;
using Ships.Enemies;

namespace Core.Commands
{
    public class StopBattleCommand : ICommand
    {
        public Task Execute()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EnemySpawner>().StopSpawn();
            return Task.CompletedTask;
        }
    }
}

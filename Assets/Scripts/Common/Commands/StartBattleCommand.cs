using System.Threading.Tasks;
using UI;
using Core.Services;
using Battle;
using Ships;
using Ships.Enemies;

namespace Core.Commands
{
    public class StartBattleCommand : ICommand
    {
        public async Task Execute()
        {
            await new ShowScreenFadeCommand().Execute();

            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<GameStateController>().Reset();
            serviceLocator.GetService<ScoreView>().Reset();
            serviceLocator.GetService<EnemySpawner>().StartSpawn();
            serviceLocator.GetService<ShipInstaller>().SpawnUserShip();

            await new HideScreenFadeCommand().Execute();
        }
    }
}

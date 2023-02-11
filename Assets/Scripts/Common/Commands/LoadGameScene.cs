using System.Threading.Tasks;

namespace Core.Commands
{
    public class LoadGameScene : ICommand
    {
        public async Task Execute()
        {
            await new LoadSceneCommand("Game").Execute();
            await new StartBattleCommand().Execute();
        }
    }
}

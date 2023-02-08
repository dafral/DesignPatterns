using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterns.Command
{

    public class CommandQueue
    {
        public static CommandQueue Instance => _instance ?? (_instance = new CommandQueue());

        private static CommandQueue _instance;
        private readonly Queue<ICommand> _commandsToExecute;
        private bool _runningCommand;

        private CommandQueue()
        {
            _commandsToExecute = new Queue<ICommand>();
            _runningCommand = false;
        }

        public void AddCommand(ICommand commandToEnqueue)
        {
            _commandsToExecute.Enqueue(commandToEnqueue);
            RunNextCommand().WrapErrors();
        }

        private async Task RunNextCommand()
        {
            if(_runningCommand)
            {
                return;
            }

            while(_commandsToExecute.Count > 0)
            {
                _runningCommand = true;
                ICommand commandToExecute = _commandsToExecute.Dequeue();
                await commandToExecute.Execute();
            }

            _runningCommand = false;
        }
    }
}

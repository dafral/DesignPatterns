using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public CompositeCommand()
        {
            _commands = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public async Task Execute()
        {
            var tasks = new List<Task>(_commands.Count);
            foreach (var command in _commands)
            {
                var task = command.Execute();
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
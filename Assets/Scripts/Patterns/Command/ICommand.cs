using System.Threading.Tasks;

namespace Patterns.Command
{
    public interface ICommand
    {
        public Task Execute();
    }
}

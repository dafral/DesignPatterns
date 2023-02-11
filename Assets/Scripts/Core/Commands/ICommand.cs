using System.Threading.Tasks;

namespace Core.Commands
{
    public interface ICommand
    {
        public Task Execute();
    }
}
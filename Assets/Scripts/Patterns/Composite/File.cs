using System.Text;

namespace Patterns.Composite
{
    public class File : IFile
    {
        private readonly string _name;
        
        public bool IsDirectory => false;

        public File(string name)
        {
            _name = name;
        }

        public void Add(IFile file)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(IFile file)
        {
            throw new System.NotImplementedException();
        }

        public string Print(int level)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('-', level + 1);
            stringBuilder.AppendLine(_name);
            return stringBuilder.ToString();
        }

    }
}

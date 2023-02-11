using System.Collections.Generic;
using System.Text;

namespace Patterns.Composite
{
    public class Directory : IFile
    {
        public bool IsDirectory => true;

        private readonly string _name;
        private readonly List<IFile> _files;

        public Directory(string name)
        {
            _name = name;
            _files = new List<IFile>();
        }

        public void Add(IFile file)
        {
            _files.Add(file);
        }


        public void Remove(IFile file)
        {
            _files.Remove(file);
        }

        public string Print(int level)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int nextLevel = level + 1;

            stringBuilder.Append('-', nextLevel);
            stringBuilder.AppendLine(_name);

            foreach(IFile file in _files)
            {
                stringBuilder.Append(file.Print(nextLevel));
            }

            return stringBuilder.ToString();
        }
    }
}

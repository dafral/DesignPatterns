namespace Patterns.Composite
{
    public interface IFile
    {
        public bool IsDirectory { get; }
        public void Add(IFile file);
        public void Remove(IFile file);
        public string Print(int level);
    }
}

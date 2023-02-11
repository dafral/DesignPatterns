using Patterns.Command;
using UnityEngine;

namespace Patterns.Composite
{
    public class Consumer : MonoBehaviour
    {
        private void Awake()
        {
            Directory directory1 = new Directory("Directory1");
            directory1.Add(new File("File1"));
            directory1.Add(new File("File2"));

            Directory directory2 = new Directory("Directory2");
            directory1.Add(directory2);
            directory2.Add(new File("File3"));

            Directory directory3 = new Directory("Directory3");
            directory1.Add(directory3);
            directory3.Add(new File("File4"));

            Directory directory4 = new Directory("Directory4");
            directory3.Add(directory4);
            directory4.Add(new File("File5"));

            Print(directory1);
        }

        private static void Print(IFile root)
        {
            Debug.Log(root.Print(0));
        }
    }
}

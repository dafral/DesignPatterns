using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Command
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup1;
        [SerializeField] private CanvasGroup _canvasGroup2;
        [SerializeField] private Consumer _consumer;

        private void Awake()
        {
            List<ICommand> commands1 = new List<ICommand>
            {
                new CanvasFadeCommand(_canvasGroup1, 0, 0.5f),
                new CanvasFadeCommand(_canvasGroup2, 1, 0.5f)
            };

            List<ICommand> commands2 = new List<ICommand>
            {
                new CanvasFadeCommand(_canvasGroup1, 1, 0.5f),
                new CanvasFadeCommand(_canvasGroup2, 0, 0.5f)
            };

            _consumer.Configure(commands1, commands2);
        }
    }
}

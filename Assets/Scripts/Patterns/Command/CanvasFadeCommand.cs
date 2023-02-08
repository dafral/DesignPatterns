using System.Threading.Tasks;
using UnityEngine;

namespace Patterns.Command
{
    public class CanvasFadeCommand : ICommand
    {
        private readonly CanvasGroup _canvasGroup;
        private readonly float _newAlpha;
        private readonly float _duration;

        public CanvasFadeCommand(CanvasGroup canvasGroup, float newAlpha, float duration)
        {
            _canvasGroup = canvasGroup;
            _newAlpha = newAlpha;
            _duration = duration;
        }

        public async Task Execute()
        {
            float initialAlpha = _canvasGroup.alpha;
            float alphaDifference = _newAlpha - initialAlpha;
            float alphaIncrement = alphaDifference / _duration;

            while(Mathf.Abs(_canvasGroup.alpha - _newAlpha) > 0.01f)
            {
                _canvasGroup.alpha += alphaIncrement * Time.deltaTime;
                await Task.Yield();
            }
        }
    }
}

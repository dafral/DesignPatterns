using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;

namespace UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameFacade _gameFacade;

        public static GameOverView Instance { get; private set; }

        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            _restartButton.onClick.AddListener(RestartGame);
            gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            _gameFacade.StartBattle();
            gameObject.SetActive(false);
        }

        public void Show()
        {
            _gameFacade.StopBattle();
            _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
            gameObject.SetActive(true);
        }

    }
}

using FrameworkUnity.OOP.VContainer;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Roguelike_EventBus
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _loseScreen;
        private GameManagerVContainer _gameManager;
        private PlayerService _playerService;


        [Inject]
        public void Construct(GameManagerVContainer gameManager, PlayerService playerService)
        {
            _gameManager = gameManager;
            _playerService = playerService;
        }

        private void Start()
        {
            _playerService.Player.Get<DeathComponent>().IsDeadChanged += _ =>
            {
                _gameManager.LoseGame();
                Invoke(nameof(ShowLoseScreen), 2);
            };
        }

        private void ShowLoseScreen() => _loseScreen.SetActive(true);
        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

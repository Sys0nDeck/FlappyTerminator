using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Terminator _terminator;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _terminator.Damaged += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _terminator.Damaged -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        SetActivePlayerControl(false);
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
        SetActivePlayerControl(false);
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        _enemySpawner.Clear();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _terminator.Reset();
        SetActivePlayerControl(true);
    }

    private void SetActivePlayerControl(bool enabled)
    {
        _playerInput.enabled = enabled;
    }
}

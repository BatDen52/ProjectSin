using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private GameMenu _menu;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private CameraEffects _cameraEffects;

    private void Awake()
    {
        _game.Init(_blockSpawner, _menu, _scoreText, _levelNumberText, _cameraEffects);
        _blockSpawner.Init(_audioManager);

        _game.enabled = true;
    }
}

using DG.Tweening;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const string LEVEL_SCENE_SUBNAME = "Level";

    [SerializeField] private int _startTryCount = 3;

    private BlockSpawner _blockSpawner;
    private GameMenu _menu;
    private TMP_Text _levelNumberText;
    private TMP_Text _scoreText;
    private CameraEffects _cameraEffects;
    private int _tryCount;
    private int _score;

    public event Action<int> TryCountChanged;
    public event Action Lose;

    public int TryCount => _tryCount;

    private void Awake()
    {
        _tryCount = _startTryCount;
    }

    private void OnEnable()
    {
        _blockSpawner.BlockDestroyed += OnBlockDestroyed;
        _blockSpawner.AllBlockDestroyed += OnAllBlockDestroyed;
    }

    private void OnDisable()
    {
        _blockSpawner.BlockDestroyed -= OnBlockDestroyed;
        _blockSpawner.AllBlockDestroyed -= OnAllBlockDestroyed;
    }

    private void Start()
    {
        TryCountChanged?.Invoke(_tryCount);
    }

    public void Init(BlockSpawner blockSpawner, GameMenu menu, 
        TMP_Text scoreText, TMP_Text levelNumberText, CameraEffects ballDieEffect)
    {
        _blockSpawner = blockSpawner;
        _menu = menu;
        _scoreText = scoreText;
        _levelNumberText = levelNumberText;
        _cameraEffects = ballDieEffect;

        _levelNumberText.text = $"{LEVEL_SCENE_SUBNAME} {SceneManager.GetActiveScene().buildIndex}";
    }

    private void OnBallDestroyed()
    {
        _tryCount--;

        _cameraEffects.PlayDie();
        TryCountChanged?.Invoke(_tryCount);

        if (_tryCount == 0)
        {
            Lose?.Invoke();
            _menu.OpenFailWindow();
        }
        else
        {
        }
    }

    private void OnBlockDestroyed(int reward)
    {
        _score += reward;
        _scoreText.text = "Score: " + _score;
    }

    private void OnAllBlockDestroyed()
    {
        _menu.OpenWinWindow();
    }
}

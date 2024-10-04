using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private const int DEFAULT_LEVEL_INDEX = 1;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _selectLevelButton;
    [SerializeField] private Button _aboutButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private SettingstWindow _settingstWindow;
    [SerializeField] private SelectLevelWindow _selectLevelWindow;
    [SerializeField] private AboutWindow _aboutWindow;

    [SerializeField] private float _waitingInAlphaTime = 0.5f;
    [SerializeField] private float _showingTime;
    [SerializeField] private CanvasGroup _menuPanel;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(LoadScene);
        _settingsButton.onClick.AddListener(_settingstWindow.Open);
        _selectLevelButton.onClick.AddListener(_selectLevelWindow.Open);
        _selectLevelButton.onClick.AddListener(_selectLevelWindow.Open);
        _aboutButton.onClick.AddListener(_aboutWindow.Open);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(LoadScene);
        _settingsButton.onClick.RemoveListener(_settingstWindow.Open);
        _selectLevelButton.onClick.RemoveListener(_selectLevelWindow.Open);
        _aboutButton.onClick.RemoveListener(_aboutWindow.Open);
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void LoadScene()
    {
        if (SaveService.HasUnlockedLevel)
        {
            SceneManager.LoadScene(SaveService.LastUnlockedLevel);
        }
        else
        {
            SceneManager.LoadScene(DEFAULT_LEVEL_INDEX);
        }
    }

    private void Exit()
    {
        Application.Quit();
    }
}

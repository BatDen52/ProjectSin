using TMPro;
using UnityEngine;

public class PlayerInputInitializer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private TMP_Text _interactInput;

    private void Awake()
    {
        _player.Initialize(_inputReader);
        _interactInput?.gameObject.SetActive(true);
    }
}

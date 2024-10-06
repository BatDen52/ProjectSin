using UnityEngine;

public class EscListener : MonoBehaviour
{
    [SerializeField] private PauseWindow _pauseWindow;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseWindow.gameObject.SetActive(!_pauseWindow.gameObject.activeSelf);
        }
    }
}

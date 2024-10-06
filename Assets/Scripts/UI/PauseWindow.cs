using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : PauseWindowBase
{
    [SerializeField] private Button _continueButton;

    protected override void OnEnable()
    {
        base.OnEnable();

        _continueButton.onClick.AddListener(Continue);

        Cursor.visible = true;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _continueButton.onClick.RemoveListener(Continue);
     
        Cursor.visible = false;
    }

    private void Continue()
    {
        gameObject.SetActive(false);
    }
}

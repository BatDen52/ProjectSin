using UnityEngine;
using UnityEngine.EventSystems;

public class InputReader : MonoBehaviour, IInputReader
{    
    private bool _isJump;
    private bool _isInterect;
    private bool _isAttack;

    public float Direction { get; private set; }

    private void Update()
    {
        if (TimeManager.IsPaused)
            return;

        Direction = Input.GetAxis(ConstantsData.InputData.HORIZONTAL_AXIS);

        if (Input.GetKeyDown(KeyCode.W))
            _isJump = true;

        if (Input.GetKeyDown(KeyCode.F))
            _isInterect = true;

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
            _isAttack = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    public bool GetIsInteract() => GetBoolAsTrigger(ref _isInterect);

    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool lockalValue = value;
        value = false;
        return lockalValue;
    }
}
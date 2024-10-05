using UnityEngine;

public class LightBonus : MonoBehaviour, IItem
{
    [SerializeField] private SoulsLight _soulsLight;

    public Sprite Icon => throw new System.NotImplementedException();

    public void Collect()
    {
        _soulsLight.Interact();
        Destroy(gameObject);
    }
}

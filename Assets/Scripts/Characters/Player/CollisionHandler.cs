using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> InteractableFounded;
    public event Action<MedKit> MedKitFounded;
    public event Action<Key> KeyFounded;
    public event Action<LightBonus> BonusFounded;
    public event Action TakedDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable finish))
        {
            InteractableFounded?.Invoke(finish);
        }

        if (collision.TryGetComponent(out MedKit medKit))
            MedKitFounded?.Invoke(medKit);

        if (collision.TryGetComponent(out Key key))
            KeyFounded?.Invoke(key);

        if (collision.TryGetComponent(out LightBonus bonus))
            BonusFounded?.Invoke(bonus);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable _))
        {
            InteractableFounded?.Invoke(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out FalledLetter letter))
            TakedDamage?.Invoke();
    }
}

using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Flyer flyer))
        {
            flyer.TakeDamage(_damage);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

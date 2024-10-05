using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private float _upAdded = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player) == false)
            return;

        player.transform.position += Vector3.up * _upAdded;
        player.GetComponent<Rigidbody2D>().velocity /= 2;
    }
}

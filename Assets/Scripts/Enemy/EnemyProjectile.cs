using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed = 5f;

    private void Start() {
        Destroy(gameObject, lifetime);
    }

    private void Update() {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null) {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
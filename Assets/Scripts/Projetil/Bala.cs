using UnityEngine;

public class Bala : MonoBehaviour {
    public float speed = 5f;
    public Vector3 direction = Vector3.up;

    void Update() {
        // Move a bala na direção especificada
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnBecameInvisible() {
        // Destrói a bala quando ela sai da tela
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosionPrefab;
    private WaveManager waveManager;

    public void SetWaveManager(WaveManager manager) {
        waveManager = manager;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Projectile")) {
            Debug.Log("Houve colisão!");
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Notifica o WaveManager que o asteroide foi destruído
            if (waveManager != null) {
                waveManager.OnEnemyDefeated();
            }

            Destroy(gameObject);
        }
    }
}

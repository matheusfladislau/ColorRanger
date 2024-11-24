using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    private WaveManager waveManager;
    public int pointValue = 100;
    public string enemyType = "normal"; // Adicione isso para identificar o tipo do inimigo

    public void SetWaveManager(WaveManager manager) {
        waveManager = manager;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Projectile1")) {
            Debug.Log("Houve colisão!");

            if (PointsManager.Instance != null) {
                PointsManager.Instance.AddPoints(pointValue, enemyType);
            }

            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            if (waveManager != null) {
                waveManager.OnEnemyDefeated();
            }

            Destroy(gameObject);
        }
    }
}

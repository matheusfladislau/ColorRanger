using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Prefab do asteroide (usado como inimigo)
    public float spawnYPosition = 5f; // Posição Y onde os asteroides vão aparecer no topo
    public float spawnRangeX = 8f; // Alcance no eixo X para spawnar os asteroides aleatoriamente
    private WaveManager waveManager;

    void Start() {
        // Busca o WaveManager na cena
        waveManager = FindObjectOfType<WaveManager>();
    }

    public void SpawnEnemies(int count) {
        for (int i = 0; i < count; i++) {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, 0);
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            // Atribui o WaveManager ao asteroide para que ele possa reportar sua destruição
            Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
            if (asteroidScript != null) {
                asteroidScript.SetWaveManager(waveManager);
            }
        }
    }
}

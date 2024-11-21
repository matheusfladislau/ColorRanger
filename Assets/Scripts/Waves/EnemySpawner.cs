using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public float spawnYPosition = 5f; // Posição Y onde os inimigos vão aparecer
    public float spawnRangeX = 8f; // Alcance no eixo X para spawnar os inimigos aleatoriamente
    private WaveManager waveManager;

    void Start() {
        // Busca o WaveManager na cena
        waveManager = FindObjectOfType<WaveManager>();
    }

    public void SpawnEnemies(int count) {
        for (int i = 0; i < count; i++) {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, 0);

            // Escolha aleatória do inimigo
            GameObject randomEnemy = GetRandomEnemy();

            // Instancia o inimigo aleatório
            GameObject enemy = Instantiate(randomEnemy, spawnPosition, Quaternion.identity);

            // Atribui o WaveManager ao inimigo, se necessário
            Enemy asteroidScript = enemy.GetComponent<Enemy>();
            if (asteroidScript != null) {
                asteroidScript.SetWaveManager(waveManager);
            }
        }
    }

    private GameObject GetRandomEnemy() {
        int randomIndex = Random.Range(0, 3); // Retorna um valor entre 0 e 2 (inclusive)
        switch (randomIndex) {
            case 0: return enemyPrefab1;
            case 1: return enemyPrefab2;
            case 2: return enemyPrefab3;
            default: return enemyPrefab1; // Garantia de retorno
        }
    }
}
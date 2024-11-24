using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject explosionPrefab;
    public GameObject projectilePrefab; // Prefab do projétil do inimigo
    private WaveManager waveManager;
    public int pointValue = 100;
    public string enemyType = "normal";

    // Configurações de disparo
    public float minFireRate = 1f; // Tempo mínimo entre disparos
    public float maxFireRate = 3f; // Tempo máximo entre disparos
    private float nextFireTime;

    private void Start() {
        // Define o primeiro disparo
        SetNextFireTime();
    }

    private void Update() {
        // Verifica se é hora de disparar
        if (Time.time >= nextFireTime) {
            Fire();
            SetNextFireTime();
        }
    }

    private void SetNextFireTime() {
        // Define um tempo aleatório para o próximo disparo
        nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
    }

    private void Fire() {
        if (projectilePrefab != null) {
            // Cria o projétil na posição do inimigo
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Encontra a direção para a nave do jogador
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                Vector2 direction = (player.transform.position - transform.position).normalized;

                // Se o projétil tiver um Rigidbody2D, aplica velocidade
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null) {
                    float projectileSpeed = 5f; // Ajuste a velocidade conforme necessário
                    rb.velocity = direction * projectileSpeed;

                    // Opcional: Rotaciona o projétil na direção do movimento
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
            }
        }
    }

    public void SetWaveManager(WaveManager manager) {
        waveManager = manager;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (enemyType == "blue" && (collision.CompareTag("Projectile1")) ||
            enemyType == "green" && (collision.CompareTag("Projectile2")) ||
            enemyType == "red" && (collision.CompareTag("Projectile3")) ) {
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
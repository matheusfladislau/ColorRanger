using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerHealth : MonoBehaviour {
    private TextMeshPro livesText;
    public GameObject explosionPrefab;
    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 2f;

    void Start() {
        // Busca o TextMeshPro pelo nome do objeto
        livesText = GameObject.Find("LifeMessage").GetComponent<TextMeshPro>();
        UpdateLivesDisplay();
    }

    public void TakeDamage(int damage) {
        if (isInvulnerable) return;

        HealthManager.Instance.TakeDamage(damage);
        UpdateLivesDisplay();

        if (explosionPrefab != null) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        if (HealthManager.Instance.GetCurrentHealth() > 0) {
            StartCoroutine(InvulnerabilityPeriod());
        }
    }

    private void UpdateLivesDisplay() {
        if (livesText != null) {
            livesText.text = "Vidas: " + HealthManager.Instance.GetCurrentHealth().ToString();
        }
        else {
            Debug.LogWarning("TextMeshPro de vidas não encontrado!");
        }
    }

    private IEnumerator InvulnerabilityPeriod() {
        isInvulnerable = true;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null) {
            float blinkTime = 0.2f;
            for (float i = 0; i < invulnerabilityDuration; i += blinkTime) {
                sprite.enabled = !sprite.enabled;
                yield return new WaitForSeconds(blinkTime / 2);
            }
            sprite.enabled = true;
        }

        isInvulnerable = false;
    }
}
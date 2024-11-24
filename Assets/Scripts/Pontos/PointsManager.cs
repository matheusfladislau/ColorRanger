using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance { get; private set; }
    public TextMeshPro scoreText;
    private int totalPoints = 0;

    // Sistema de Combo
    private string lastEnemyType = "";
    private int comboCount = 0;
    private int comboBonus = 20;
    private int comboRequirement = 3;

    // Configurações de animação
    public Color highlightColor = Color.yellow;
    public Color comboColor = Color.red; // Cor especial para quando fizer combo
    public float highlightDuration = 0.2f;
    private Color originalColor;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }

        if (scoreText != null) {
            originalColor = scoreText.color;
        }
    }

    void Start() {
        UpdateScoreText();
    }

    public void AddPoints(int points, string enemyType) {
        // Verifica combo
        if (enemyType == lastEnemyType) {
            comboCount++;
            if (comboCount >= comboRequirement) {
                // Adiciona bonus e reseta o combo
                totalPoints += points + comboBonus;
                Debug.Log($"COMBO! Bônus de {comboBonus} pontos!");
                StartCoroutine(AnimateScoreChange(true)); // true para indicar que é um combo
                comboCount = 0;
            }
            else {
                totalPoints += points;
                StartCoroutine(AnimateScoreChange(false));
            }
        }
        else {
            // Reseta o combo se for um inimigo diferente
            comboCount = 1;
            totalPoints += points;
            StartCoroutine(AnimateScoreChange(false));
        }

        lastEnemyType = enemyType;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        if (scoreText != null) {
            scoreText.text = "Pontos: " + totalPoints.ToString();

            // Opcional: mostrar progresso do combo
            if (comboCount > 0) {
                scoreText.text += $"\nCombo: {comboCount}/{comboRequirement}";
            }
        }
    }

    private IEnumerator AnimateScoreChange(bool isCombo) {
        if (scoreText != null) {
            // Escolhe a cor baseada se é combo ou não
            Color targetColor = isCombo ? comboColor : highlightColor;
            scoreText.color = targetColor;

            // Aumenta mais se for combo
            float scale = isCombo ? 1.4f : 1.2f;
            scoreText.transform.localScale = Vector3.one * scale;

            yield return new WaitForSeconds(highlightDuration);

            scoreText.color = originalColor;
            scoreText.transform.localScale = Vector3.one;
        }
    }

    public int GetTotalPoints() {
        return totalPoints;
    }
}

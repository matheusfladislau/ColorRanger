using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public static HealthManager Instance { get; private set; }
    public int maxHealth = 3;
    private int currentHealth;
    private TextMeshProUGUI gameOverText; // Referência ao texto de Game Over

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        if (Instance == this && currentHealth == 0) {
            currentHealth = maxHealth;
        }
    }

    void Start() {
        // Encontra ou cria o texto de Game Over
    }

    private void SetupGameOverText() {
        // Procura o texto existente ou cria um novo
        gameOverText = GameObject.Find("GameOverText")?.GetComponent<TextMeshProUGUI>();

        if (gameOverText == null) {
            // Cria um novo Canvas se necessário
            Canvas canvas = FindObjectOfType<Canvas>();
            if (canvas == null) {
                GameObject canvasObj = new GameObject("GameOverCanvas");
                canvas = canvasObj.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasObj.AddComponent<CanvasScaler>();
                canvasObj.AddComponent<GraphicRaycaster>();
            }

            // Cria o texto de Game Over
            GameObject textObj = new GameObject("GameOverText");
            textObj.transform.SetParent(canvas.transform);
            gameOverText = textObj.AddComponent<TextMeshProUGUI>();

            // Configura o texto
            gameOverText.fontSize = 72;
            gameOverText.alignment = TextAlignmentOptions.Center;
            gameOverText.color = Color.red;

            // Posiciona no centro da tela
            RectTransform rectTransform = gameOverText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.sizeDelta = Vector2.zero;
        }


        // Esconde o texto inicialmente
        gameOverText.text = "";
        gameOverText.enabled = false;
    }

    public void TakeDamage(int damage) {
        currentHealth--;

        if (currentHealth <= 0) {
            StartCoroutine(GameOverSequence());
        }
    }

    private IEnumerator GameOverSequence() {
        // Mostra o texto de Game Over
        if (gameOverText == null) {
            SetupGameOverText();
        }
        gameOverText.text = "GAME OVER";
        gameOverText.enabled = true;

        // Espera 2 segundos
        yield return new WaitForSeconds(2f);

        // Carrega a cena do menu
        SceneManager.LoadScene("MenuInicial");

        // Reseta o texto para a próxima vez
        if (gameOverText != null) {
            gameOverText.text = "";
            gameOverText.enabled = false;
        }
    }

    public int GetCurrentHealth() {
        return currentHealth;
    }

    public void ResetHealth() {
        currentHealth = maxHealth;
    }
}
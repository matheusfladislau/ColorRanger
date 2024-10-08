using UnityEngine;

public class MovVerticalAleatoria : MonoBehaviour {
    public float speed = 5f;
    public float tempoMinTroca = 1f; // Tempo mínimo antes de trocar de direção
    public float tempoMaxTroca = 3f; // Tempo máximo antes de trocar de direção

    private float tempoTrocaDirecao;
    private float tempoAtual;
    private int direcao;

    void Start() {
        EscolherNovaDirecao();
    }

    void Update() {
        // Movimenta o objeto na direção vertical atual
        transform.Translate(Vector3.up * direcao * speed * Time.deltaTime);

        // Atualiza o tempo e verifica se é hora de trocar de direção
        tempoAtual += Time.deltaTime;
        if (tempoAtual >= tempoTrocaDirecao) {
            EscolherNovaDirecao();
        }
    }

    void EscolherNovaDirecao() {
        // Escolhe aleatoriamente -1 (baixo) ou 1 (cima)
        direcao = Random.Range(0, 2) == 0 ? -1 : 1;

        // Define um novo tempo aleatório para manter essa direção
        tempoTrocaDirecao = Random.Range(tempoMinTroca, tempoMaxTroca);

        // Reseta o temporizador
        tempoAtual = 0f;
    }
}

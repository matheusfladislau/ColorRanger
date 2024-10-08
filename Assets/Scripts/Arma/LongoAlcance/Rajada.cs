using System.Collections;
using UnityEngine;

public class Burst : Arma {
    public GameObject balaPrefab;

    public int capacidadeMunição = 9;
    private int municaoAtual;
    public float tempoRecarga = 2f;
    public float intervaloRajada = 0.1f;
    private bool estaRecarregando = false;

    void Start() {
        municaoAtual = capacidadeMunição;
    }

    public override void Atacar() {
        if (estaRecarregando) {
            Debug.Log("Recarregando... Aguarde");
            return;
        }

        if (municaoAtual >= 3) {
            StartCoroutine(DispararRajada());
        }
        else if (municaoAtual > 0) {
            StartCoroutine(DispararRajada(municaoAtual));
        }
        else {
            StartCoroutine(Recarregar());
        }
    }

    private IEnumerator DispararRajada(int balas = 3) {
        for (int i = 0; i < balas; i++) {
            if (municaoAtual > 0) {
                Instantiate(balaPrefab, transform.position, Quaternion.identity);
                municaoAtual--;
                yield return new WaitForSeconds(intervaloRajada);
            }
        }
    }

    private IEnumerator Recarregar() {
        estaRecarregando = true;
        Debug.Log("Iniciando recarga...");
        yield return new WaitForSeconds(tempoRecarga);
        municaoAtual = capacidadeMunição;
        estaRecarregando = false;
        Debug.Log("Recarga completa!");
    }
}

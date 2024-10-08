using System.Collections;
using UnityEngine;

public class Burst : Arma {
    public GameObject balaPrefab;

    public int capacidadeMunição = 9;
    private int municaoAtual;
    
    public float intervaloRajada = 0.1f;

    public float tempoRecarga = 1f;
    private bool estaRecarregando = false;

    public float cooldownRajada = 0.5f;
    private bool cooldownAtivo = false;

    void Start() {
        municaoAtual = capacidadeMunição;
    }

    public override void Atacar() {
        if (estaRecarregando) {
            Debug.Log("Recarregando... Aguarde");
            return;
        } else if (cooldownAtivo) {
            Debug.Log("Cooldown... Aguarde");
            return;
        }

        if (municaoAtual > 3) {
            StartCoroutine(DispararRajada());
            StartCoroutine(Cooldown());
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

    private IEnumerator Cooldown() {
        cooldownAtivo = true;
        Debug.Log("Ativando cooldown da rajada...");
        yield return new WaitForSeconds(cooldownRajada);
        cooldownAtivo = false;
        Debug.Log("Rajada pronta!");
    }
}

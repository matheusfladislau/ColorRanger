using System.Collections;
using UnityEngine;

public class canhao : Arma {

    public GameObject balaPrefab;

    public int capacidadeMunição = 5;
    private int municaoAtual;
    public float tempoRecarga = 2f;
    private bool estaRecarregando = false;

    void Start() {
        municaoAtual = capacidadeMunição;
    }

    public override void Atacar() {
        if (estaRecarregando) {
            Debug.Log("Recarregando... Aguarde");
            return;
        }

        if (municaoAtual > 0) {
            Instantiate(balaPrefab, transform.position, Quaternion.identity);
            municaoAtual--;
        }
        else {
            StartCoroutine(Recarregar());
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

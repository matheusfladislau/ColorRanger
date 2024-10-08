using UnityEngine;

public class Spaceship : MonoBehaviour {
    public string botaoAtaque = "Fire1";
    private Arma _armaAtual;

    void Start() {
        _armaAtual = GetComponentInChildren<Arma>();
    }

    void Update() {
        if (Input.GetButtonDown(botaoAtaque) && _armaAtual != null) _armaAtual.Atacar();
    }
}

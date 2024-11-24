using System;
using UnityEngine;

public class Spaceship : MonoBehaviour {
    public string botaoAtaque = "Fire1";
    public string botaoTrocar = "Space";
    private Arma _armaAtual;
    private CorMudanca _color;
    private int _currentNumber = 0;


    void Start() {
        _armaAtual = GetComponentInChildren<Arma>();
        _color = GetComponent<CorMudanca>();
    }

    void Update() {
        if (Input.GetButtonDown(botaoAtaque) && _armaAtual != null) _armaAtual.Atacar();
        if (Input.GetButtonDown(botaoTrocar)) {
            _color.ChangeColor();
        }
    }
}

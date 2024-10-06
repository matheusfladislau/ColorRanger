using UnityEngine;

public class Spaceship : MonoBehaviour {
    public string botaoAtaque = "Fire1";
    private canhao _cannon;

    void Start() {
        _cannon = GetComponentInChildren<canhao>();
    }

    void Update() {
        if (Input.GetButtonDown(botaoAtaque) && _cannon != null) _cannon.Atacar();
    }
}

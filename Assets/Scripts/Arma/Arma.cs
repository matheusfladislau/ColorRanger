using UnityEngine;

public abstract class Arma : MonoBehaviour {
    public string nome;
    public string dano;
    public string descricao;

    public abstract void Atacar();
}

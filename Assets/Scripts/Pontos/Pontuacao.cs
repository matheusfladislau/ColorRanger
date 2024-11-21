using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public int pontos = 0;
    private Queue<string> cores = new Queue<string>(); // Fila para rastrear as últimas cores
    private int navesAtingidasParaRecompenca = 3; // Número de naves consecutivas necessárias

    public void Pontuar(string enemyColor) {
        // Adiciona a cor do inimigo destruído na fila
        cores.Enqueue(enemyColor);

        // Remove elementos excedentes
        if (cores.Count > navesAtingidasParaRecompenca) {
            cores.Dequeue();
        }

        // Verifica se as últimas 3 cores são iguais
        if (cores.Count == navesAtingidasParaRecompenca && CoresIguais()) {
            pontos += 20; // Pontuação bônus
            cores.Clear(); // Reseta a sequência
        }
        else {
            pontos += 5; // Pontuação padrão
        }

        Debug.Log("Pontuação atual: " + pontos);
    }

    private bool CoresIguais() {
        // Verifica se todas as cores na fila são iguais
        string primeiraCor = null;
        foreach (string cor in cores) {
            if (primeiraCor == null)
                primeiraCor = cor;
            else if (cor != primeiraCor)
                return false;
        }
        return true;
    }
}

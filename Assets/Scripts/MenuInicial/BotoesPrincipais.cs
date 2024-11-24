using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar() {
        SceneManager.LoadScene("Jogo");
    }

    public void Sair() {
        Debug.Log("Sair do jogo.");
        Application.Quit();
    }
}

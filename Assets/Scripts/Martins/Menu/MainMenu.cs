using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string loadingScene;
    public string gameScene;
    public float loadingTime = 2f; // Tempo de espera na tela de loading

    public void PlayGame()
    {
        // Carrega a cena da tela de loading
        SceneManager.LoadScene(loadingScene);
        
        // Inicia uma corrotina para transitar para a cena do jogo após o tempo especificado
        StartCoroutine(TransitionToGame());
    }

    private System.Collections.IEnumerator TransitionToGame()
    {
        // Aguarda o tempo de espera na tela de loading
        yield return new WaitForSeconds(loadingTime);

        // Carrega a cena do jogo
        SceneManager.LoadScene(gameScene);
    }
}

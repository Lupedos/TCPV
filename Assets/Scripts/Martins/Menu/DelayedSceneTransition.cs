using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedSceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public float delayTime = 2f; // Tempo de espera antes da transição para a próxima cena

    private void Start()
    {
        // Inicia a corrotina para atrasar a transição para a próxima cena
        StartCoroutine(DelayedTransition());
    }

    private System.Collections.IEnumerator DelayedTransition()
    {
        // Aguarda o tempo especificado antes de carregar a próxima cena
        yield return new WaitForSeconds(delayTime);

        // Carrega a próxima cena
        SceneManager.LoadScene(sceneToLoad);
    }
}
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        // Subskrybujesz do zdarzenia ³adowania sceny
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Ta funkcja zostanie wywo³ana po za³adowaniu nowej sceny
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Wywo³aj tutaj swoj¹ funkcjê
        MojaFunkcja();
    }

    // Funkcja, któr¹ chcesz wywo³aæ po za³adowaniu sceny
    void MojaFunkcja()
    {
        // Tutaj umieœæ kod, który ma zostaæ wykonany po za³adowaniu sceny
        UnityEngine.Debug.Log("Scena zosta³a za³adowana. Wywo³ano moj¹ funkcjê.");
    }

    // Pamiêtaj o odsubskrybowaniu zdarzenia po zakoñczeniu
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

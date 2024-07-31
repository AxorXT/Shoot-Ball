using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Si estamos en el Editor de Unity, simplemente detener la reproducci�n.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si estamos en una build del juego, salir de la aplicaci�n.
        Application.Quit();
#endif
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaGanar : MonoBehaviour
{
    public GameObject mensajeUI; // Arrastra aquí un GameObject de UI para mostrar el mensaje
    public float tiempoMostrarMensaje = 5f; // Tiempo que el mensaje estará visible
    public string escenaSiguiente = "Menu"; // Nombre de la escena a cargar

    void Start()
    {
        if (mensajeUI != null)
        {
            mensajeUI.SetActive(false); // Oculta el mensaje al iniciar
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            if (mensajeUI != null)
            {
                mensajeUI.SetActive(true); // Muestra el mensaje
            }            
            StartCoroutine(CambiarEscenaConRetraso());
        }
    }

    private IEnumerator CambiarEscenaConRetraso()
    {
        yield return new WaitForSeconds(tiempoMostrarMensaje); // Espera el tiempo especificado
        LevelLoader.LoadLevel("Menu");
    }
}

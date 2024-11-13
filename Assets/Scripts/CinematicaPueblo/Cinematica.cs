using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public string sceneName;  // Nombre de la escena a la que deseas cambiar
    private bool playerInTrigger = false;  // Variable para verificar si el jugador está en el área del trigger

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;  // Marca que el jugador ha entrado en el trigger
            Debug.Log("Presiona Espacio para continuar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el jugador sale del área del trigger
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;  // Desactiva la marca cuando el jugador sale del trigger
        }
    }

    private void Update()
    {
        // Si el jugador está en el trigger y presiona Espacio, cambia de escena
        if (playerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

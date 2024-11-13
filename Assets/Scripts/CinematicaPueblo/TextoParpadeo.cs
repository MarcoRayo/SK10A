using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ParpadeoTexto : MonoBehaviour
{
    public Text mensajeUI;
    public float intervaloParpadeo; // Tiempo de parpadeo en segundos

    void Start()
    {
        // Verifica que el texto está asignado correctamente
        if (mensajeUI != null)
        {
            StartCoroutine(ParpadearTexto());
        }
        else
        {
            Debug.LogError("mensajeUI no está asignado");
        }
    }

    // Corutina para hacer parpadear el texto
    IEnumerator ParpadearTexto()
    {
        while (true) // Hace que parpadee continuamente
        {
            mensajeUI.enabled = false; // Desactiva el texto (invisible)
            yield return new WaitForSeconds(intervaloParpadeo);

            mensajeUI.enabled = true; // Activa el texto (visible)
            yield return new WaitForSeconds(intervaloParpadeo);
        }
    }
}

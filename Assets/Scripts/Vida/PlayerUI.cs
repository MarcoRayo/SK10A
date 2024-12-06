using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider barraVida; // Asigna el Slider desde el Inspector
    public int vidaMaxima = 25;
    private int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
        barraVida.maxValue = vidaMaxima; // Configura el valor máximo del Slider
        barraVida.value = vidaActual;   // Configura el valor inicial
    }

    public void ActualizarVida(int nuevaVida)
    {
        vidaActual = nuevaVida;
        barraVida.value = vidaActual; // Actualiza la barra de vida
    }

    public void RecibirDaño(int daño)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Asegúrate de que no sea menor a 0
        ActualizarVida(vidaActual);
    }
}

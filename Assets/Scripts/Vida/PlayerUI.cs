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
        barraVida.maxValue = vidaMaxima; // Configura el valor m�ximo del Slider
        barraVida.value = vidaActual;   // Configura el valor inicial
    }

    public void ActualizarVida(int nuevaVida)
    {
        vidaActual = nuevaVida;
        barraVida.value = vidaActual; // Actualiza la barra de vida
    }

    public void RecibirDa�o(int da�o)
    {
        vidaActual -= da�o;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Aseg�rate de que no sea menor a 0
        ActualizarVida(vidaActual);
    }
}

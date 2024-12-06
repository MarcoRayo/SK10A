using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamiento_Planta : MonoBehaviour
{
    public Animator animator; // Controlador del Animator
    public GameObject target; // Jugador
    public bool atacando; // Bandera para saber si est� atacando

    // Start se ejecuta al inicio
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtiene el componente Animator
        target = GameObject.Find("PlayerArmature"); // Encuentra al jugador en la escena
    }

    // M�todo principal que controla el comportamiento del enemigo
    public void Comportamientos_Enemigo()
    {
        float distancia = Vector3.Distance(transform.position, target.transform.position); // Calcula la distancia al jugador

        if (distancia > 5) // Fuera del rango lejano
        {
            animator.SetBool("Sleeping", true); // Activar animaci�n de dormir
            animator.SetBool("Bite", false);   // Desactivar animaci�n de ataque
            atacando = false; // Resetea la bandera de ataque
        }
        else if (distancia > 1) // Dentro del rango de visi�n, pero fuera del alcance de ataque
        {
            animator.SetBool("Sleeping", false); // Salir del estado de dormir
            animator.SetBool("Bite", true);     // No atacar
            atacando = false; // Asegurarse de que no est� atacando
        }
        else // Dentro del rango de ataque
        {
            if (!atacando) // Si no est� atacando, inicia el ataque
            {
                atacando = true; // Marca que est� atacando
                animator.SetBool("Sleeping", false); // Asegura que no est� durmiendo
                animator.SetBool("Bite", true);      // Activa la animaci�n de ataque

                // Mensaje para depurar
                Debug.Log("Enemigo atacando al jugador.");
            }
        }
    }

    // M�todo que se llama al finalizar la animaci�n de ataque
    public void Final_Ani()
    {
        Debug.Log("Finalizando ataque.");
        animator.SetBool("Bite", false); // Detiene la animaci�n de ataque
        animator.SetBool("Sleeping", true); // Regresa a dormir
        atacando = false; // Libera la bandera de ataque
    }

    // M�todos para manejar la caja de ataque (opcional si usas colliders)
    public void AttackboxOn()
    {
        Debug.Log("Activando caja de ataque");

        if (target != null)
        {
            PlayerUI playerHealth = target.GetComponent<PlayerUI>();
            if (playerHealth != null)
            {
                playerHealth.RecibirDa�o(10); // Ajusta el valor de da�o seg�n sea necesario
                Debug.Log("Jugador da�ado por el enemigo.");
            }
            else
            {
                Debug.LogWarning("El objeto objetivo no tiene el componente PlayerHealth.");
            }
        }
        else
        {
            Debug.LogError("Target no est� asignado.");
        }
    }

    public void AttackboxOff()
    {
        Debug.Log("Desactivando caja de ataque.");
        // Aqu� desactivas el collider o terminas el efecto
    }

    // Se ejecuta en cada frame
    private void Update()
    {
        Comportamientos_Enemigo(); // Llama al comportamiento del enemigo en cada frame
    }
}

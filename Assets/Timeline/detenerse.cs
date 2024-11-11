using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detenerse : MonoBehaviour
{    
    public Transform character;      // El objeto del personaje que sigue el spline
    public Transform endPoint;       // Último punto del spline, en este caso el punto 7
    public Animator animator;        // Animator del personaje
    public float stopDistance = 0.8f; // Distancia mínima para detenerse en el punto final

    void Start()
    {
        animator = GetComponent<Animator>();  // Obtiene el Animator automáticamente
    }

    void Update()
    {
        // Comprueba si el personaje ha llegado al último punto
        float distanceToEnd = Vector3.Distance(character.position, endPoint.position);
        print("no Entro");
        print("Distancia que falta: " + distanceToEnd + ", Distancia minima: " + stopDistance);

        if (distanceToEnd < stopDistance)
        {
            print("Entro");
            // Detiene la animación de caminar
            animator.SetBool("ChangeAnimation", true);

            // Opcional: Cambia a una animación específica, como una animación de espera
            animator.SetTrigger("ChangeAnimation");
        }
        else
        {
            // Si aún no ha llegado al final, continúa la animación de caminar
            animator.SetBool("ChangeAnimation", false);
        }
    }
}

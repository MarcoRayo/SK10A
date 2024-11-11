using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detenerse : MonoBehaviour
{    
    public Transform character;      // El objeto del personaje que sigue el spline
    public Transform endPoint;       // �ltimo punto del spline, en este caso el punto 7
    public Animator animator;        // Animator del personaje
    public float stopDistance = 0.8f; // Distancia m�nima para detenerse en el punto final

    void Start()
    {
        animator = GetComponent<Animator>();  // Obtiene el Animator autom�ticamente
    }

    void Update()
    {
        // Comprueba si el personaje ha llegado al �ltimo punto
        float distanceToEnd = Vector3.Distance(character.position, endPoint.position);
        print("no Entro");
        print("Distancia que falta: " + distanceToEnd + ", Distancia minima: " + stopDistance);

        if (distanceToEnd < stopDistance)
        {
            print("Entro");
            // Detiene la animaci�n de caminar
            animator.SetBool("ChangeAnimation", true);

            // Opcional: Cambia a una animaci�n espec�fica, como una animaci�n de espera
            animator.SetTrigger("ChangeAnimation");
        }
        else
        {
            // Si a�n no ha llegado al final, contin�a la animaci�n de caminar
            animator.SetBool("ChangeAnimation", false);
        }
    }
}

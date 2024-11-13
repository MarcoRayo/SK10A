using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detenerse : MonoBehaviour
{    
    public Transform character;      // El objeto del personaje que sigue el spline
    public Transform endPoint;       // Último punto del spline, en este caso el punto 7
    public Animator animator;        // Animator del personaje
    public float stopDistance = 0.8f; // Distancia mínima para detenerse en el punto final
    public Text mensajeUI;
    void Start()
    {
        animator = GetComponent<Animator>();  // Obtiene el Animator automáticamente
        //mensajeUI = GameObject.Find("MensajeUI").GetComponent<Text>();
    }

    void Update()
    {
        float distanceToEnd = Vector3.Distance(character.position, endPoint.position);

        if (distanceToEnd < stopDistance)
        {
            animator.SetBool("ChangeAnimation", true);
            mensajeUI.text = "Presiona SPACE para continuar";
            animator.SetTrigger("ChangeAnimation");            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LevelLoader.LoadLevel("Laberinto");
            }

        }
        else
        {
            mensajeUI.text = "Presiona ENTER para emitir la historia";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                LevelLoader.LoadLevel("Laberinto");
            }
            animator.SetBool("ChangeAnimation", false);
        }
    }
}

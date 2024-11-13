using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamiento_Enemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;

    public GameObject target;

    public bool atacando;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("PlayerArmature");
    }    

    public void Comportamientos_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            animator.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    animator.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    animator.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (!atacando) // Asegúrate de no atacar si ya está atacando
            {
                if (Vector3.Distance(transform.position, target.transform.position) > 1)
                {
                    var lookPos = target.transform.position - transform.position;
                    lookPos.y = 0;
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation.normalized, 3);
                    animator.SetBool("walk", false);

                    animator.SetBool("run", true);
                    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                    animator.SetBool("attack", false);
                }
                else
                {
                    animator.SetBool("walk", false);
                    animator.SetBool("run", false);

                    animator.SetBool("attack", true); // Inicia la animación de ataque
                    atacando = true; // Marca que está atacando
                }
            }
        }
    }


    public void Final_Ani() {
        animator.SetBool("attack", false);
        atacando = false;
    }

    private void Update()
    {
        Comportamientos_Enemigo();
    }

    public void AttackboxOn()
    {
        Debug.Log("Activando caja de ataque");
        // Aquí va el código para activar el collider o cualquier otro efecto del ataque
    }

    // Método adicional para desactivar la caja de ataque, si es necesario
    public void AttackboxOff()
    {
        animator.SetBool("attack", false);
        atacando = false;
        Debug.Log("Desactivando caja de ataque");
        // Código para desactivar el collider o efecto
    }
}

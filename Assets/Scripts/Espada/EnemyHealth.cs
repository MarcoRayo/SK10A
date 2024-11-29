using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp; // Salud m�xima del enemigo
    public int da�o;    
    private int currentHealth;
    public Animator ani;

    void Start()
    {
        currentHealth = hp; // Inicializa la salud al m�ximo
    }
    /*
    public ValueOutputDefinition onTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "arma");
        {
            if (ani != null)
            {
                ani.Play("Planta");
            }
            hp -= da�o;
        }        
        if (hp <= 0)
        {
            Die();
        }
    }    
    */
    private void Die()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject); // Elimina al enemigo de la escena
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public int damage = 10; // Daño que la espada inflige
    public string enemyTag = "Enemy"; // Etiqueta que identifica a los enemigos

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto colisionado tiene la etiqueta del enemigo
        if (other.CompareTag(enemyTag))
        {
            Debug.Log("Espada golpeó al enemigo: " + other.name);

            // Intenta obtener el componente "EnemyHealth" del objeto golpeado
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                //enemyHealth.TakeDamage(damage); // Aplica daño al enemigo
            }
        }
    }
}

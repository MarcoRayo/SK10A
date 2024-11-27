using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Comportamiento_Dragon : MonoBehaviour
{
    public Animator animator;  // Referencia al Animator del drag�n
    public Transform player;  // Referencia al jugador (Personaje)
    public float visionRange = 15f;  // Rango de visi�n del drag�n
    public float attackRange = 2f;   // Rango de ataque (cuando el drag�n est� cerca del jugador)
    public float health = 100f; // Salud del drag�n
    private NavMeshAgent agent;  // Para mover al drag�n
    private bool isAttacking = false;  // Para controlar el ataque
    private bool isDead = false;  // Para verificar si el drag�n est� muerto
    public float alturaBajo = 1f; // La altura en la que el drag�n debe estar cuando baja

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isDead) return;

        // Calcular la distancia entre el drag�n y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distancia: " + distanceToPlayer + ", Vision: " + visionRange);

        if (distanceToPlayer <= visionRange)
        {
            // Si est� dentro del rango de visi�n, el drag�n lo sigue
            animator.SetBool("Caminar", false);
            animator.SetBool("Bajar", true);  // Hacer que baje (si est� volando)
            PursuePlayer(distanceToPlayer);
        }
        else
        {
            // Si el jugador est� fuera del rango de visi�n, el drag�n no lo persigue
            animator.SetBool("Caminar", true);
            animator.SetBool("Bajar", false); // Subir (volver a volar)
        }

        // Si est� lo suficientemente cerca para atacar
        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            AttackPlayer();
        }

        // Si el drag�n recibe da�o
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    // M�todo para hacer que el drag�n persiga al jugador
    void PursuePlayer(float distanceToPlayer)
    {
        // Hacer que el drag�n se mueva hacia el jugador
        agent.SetDestination(player.position);

        // Si el drag�n est� bajando, aseguramos que su altura se mantenga
        if (animator.GetBool("Bajar"))
        {
            // Ajusta la posici�n en Y para que el drag�n no suba
            Vector3 targetPosition = new Vector3(transform.position.x, alturaBajo, transform.position.z);
            agent.Warp(targetPosition); // Esto mantiene la altura constante
        }

        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            AttackPlayer();
        }
    }
 

    // M�todo para hacer que el drag�n ataque al jugador
    void AttackPlayer()
    {
        // Activamos la animaci�n de ataque
        animator.SetBool("Atacar", true);
        isAttacking = true;

        // Simulamos un ataque: por ejemplo, infligir da�o al jugador (esto puede variar)
        // player.GetComponent<PlayerHealth>().TakeDamage(damage);

        // Aqu� podemos a�adir una peque�a espera para que el drag�n termine la animaci�n
        Invoke("ResetAttack", 1f);  // Resetea el estado de ataque despu�s de 1 segundo (dependiendo de la animaci�n)
    }

    // Resetea el estado de ataque despu�s de la animaci�n
    void ResetAttack()
    {
        animator.SetBool("Atacar", false);
        isAttacking = false;
    }

    // M�todo para que el drag�n reciba da�o
    public void TakeDamage(float damage)
    {
        if (isDead) return;

        health -= damage;
        animator.SetBool("Da�o", true);  // Activar la animaci�n de da�o

        // Resetea la animaci�n de da�o despu�s de 1 segundo (ajustar seg�n la duraci�n de la animaci�n)
        Invoke("ResetDamage", 1f);

        if (health <= 0)
        {
            Die();
        }
    }

    // Resetea el estado de da�o
    void ResetDamage()
    {
        animator.SetBool("Da�o", false);
    }

    // M�todo para que el drag�n muera
    void Die()
    {
        isDead = true;
        animator.SetBool("Matar", true);  // Activar la animaci�n de muerte

        // Aqu� podemos desactivar el drag�n o destruirlo
        Destroy(gameObject, 2f);  // Destruir el drag�n despu�s de 2 segundos (despu�s de la animaci�n de muerte)
    }
}

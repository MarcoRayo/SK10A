using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Comportamiento_Dragon : MonoBehaviour
{
    public Animator animator;  // Referencia al Animator del dragón
    public Transform player;  // Referencia al jugador (Personaje)
    public float visionRange = 15f;  // Rango de visión del dragón
    public float attackRange = 2f;   // Rango de ataque (cuando el dragón está cerca del jugador)
    public float health = 100f; // Salud del dragón
    private NavMeshAgent agent;  // Para mover al dragón
    private bool isAttacking = false;  // Para controlar el ataque
    private bool isDead = false;  // Para verificar si el dragón está muerto
    public float alturaBajo = 1f; // La altura en la que el dragón debe estar cuando baja

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isDead) return;

        // Calcular la distancia entre el dragón y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distancia: " + distanceToPlayer + ", Vision: " + visionRange);

        if (distanceToPlayer <= visionRange)
        {
            // Si está dentro del rango de visión, el dragón lo sigue
            animator.SetBool("Caminar", false);
            animator.SetBool("Bajar", true);  // Hacer que baje (si está volando)
            PursuePlayer(distanceToPlayer);
        }
        else
        {
            // Si el jugador está fuera del rango de visión, el dragón no lo persigue
            animator.SetBool("Caminar", true);
            animator.SetBool("Bajar", false); // Subir (volver a volar)
        }

        // Si está lo suficientemente cerca para atacar
        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            AttackPlayer();
        }

        // Si el dragón recibe daño
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    // Método para hacer que el dragón persiga al jugador
    void PursuePlayer(float distanceToPlayer)
    {
        // Hacer que el dragón se mueva hacia el jugador
        agent.SetDestination(player.position);

        // Si el dragón está bajando, aseguramos que su altura se mantenga
        if (animator.GetBool("Bajar"))
        {
            // Ajusta la posición en Y para que el dragón no suba
            Vector3 targetPosition = new Vector3(transform.position.x, alturaBajo, transform.position.z);
            agent.Warp(targetPosition); // Esto mantiene la altura constante
        }

        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            AttackPlayer();
        }
    }
 

    // Método para hacer que el dragón ataque al jugador
    void AttackPlayer()
    {
        // Activamos la animación de ataque
        animator.SetBool("Atacar", true);
        isAttacking = true;

        // Simulamos un ataque: por ejemplo, infligir daño al jugador (esto puede variar)
        // player.GetComponent<PlayerHealth>().TakeDamage(damage);

        // Aquí podemos añadir una pequeña espera para que el dragón termine la animación
        Invoke("ResetAttack", 1f);  // Resetea el estado de ataque después de 1 segundo (dependiendo de la animación)
    }

    // Resetea el estado de ataque después de la animación
    void ResetAttack()
    {
        animator.SetBool("Atacar", false);
        isAttacking = false;
    }

    // Método para que el dragón reciba daño
    public void TakeDamage(float damage)
    {
        if (isDead) return;

        health -= damage;
        animator.SetBool("Daño", true);  // Activar la animación de daño

        // Resetea la animación de daño después de 1 segundo (ajustar según la duración de la animación)
        Invoke("ResetDamage", 1f);

        if (health <= 0)
        {
            Die();
        }
    }

    // Resetea el estado de daño
    void ResetDamage()
    {
        animator.SetBool("Daño", false);
    }

    // Método para que el dragón muera
    void Die()
    {
        isDead = true;
        animator.SetBool("Matar", true);  // Activar la animación de muerte

        // Aquí podemos desactivar el dragón o destruirlo
        Destroy(gameObject, 2f);  // Destruir el dragón después de 2 segundos (después de la animación de muerte)
    }
}

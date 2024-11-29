using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public Animator animator;  // Referencia al Animator

    private void Start()
    {
        // Obtener el Animator del enemigo si no se ha asignado manualmente
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemigo recibi� da�o. Salud restante: " + health);

        // Activar animaci�n de da�o o efecto visual si lo deseas aqu�

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Cambiar el par�metro isDead en el Animator para activar la animaci�n de muerte
        if (animator != null)
        {
            animator.SetBool("isDead", true);  // Cambia "isDead" al par�metro que hayas configurado
        }

        // Opcional: Agregar efectos visuales, sonido, etc.
        Debug.Log("El enemigo ha muerto.");

        // Destruir al enemigo despu�s de un tiempo (si quieres darle tiempo para la animaci�n de muerte)
        Destroy(gameObject, 2f);  // El enemigo se destruye despu�s de 2 segundos
    }
}

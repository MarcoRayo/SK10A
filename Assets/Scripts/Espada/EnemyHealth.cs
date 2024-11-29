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
        Debug.Log("Enemigo recibió daño. Salud restante: " + health);

        // Activar animación de daño o efecto visual si lo deseas aquí

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Cambiar el parámetro isDead en el Animator para activar la animación de muerte
        if (animator != null)
        {
            animator.SetBool("isDead", true);  // Cambia "isDead" al parámetro que hayas configurado
        }

        // Opcional: Agregar efectos visuales, sonido, etc.
        Debug.Log("El enemigo ha muerto.");

        // Destruir al enemigo después de un tiempo (si quieres darle tiempo para la animación de muerte)
        Destroy(gameObject, 2f);  // El enemigo se destruye después de 2 segundos
    }
}

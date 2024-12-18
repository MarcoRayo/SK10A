using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI; // Necesario para UI
using TMPro; // Si usas TextMeshPro

public class Estados : MonoBehaviour
{
    public Animator playerArmature;
    public Rig rig1;
    public ThirdPersonController player;
    public int vida = 10;
    public TextMeshProUGUI mensajeMuerte;  // Referencia al texto de muerte
    public TextMeshProUGUI textoVida;     // Referencia al texto que muestra la vida
    public Slider barraVida;              // Referencia a la barra de vida
    public Transform puntoRespawn;

    private bool estaMuerto = false;

    void Start()
    {
        // Ocultar mensaje de muerte al inicio y actualizar la UI
        mensajeMuerte.gameObject.SetActive(false);
        ActualizarUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("arma") && !estaMuerto)
        {
            vida -= 1;
            ActualizarUI();
            Debug.Log("Vida: " + vida);

            if (vida <= 0)
            {
                Morir();
            }
        }
    }

    void ActualizarUI()
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vida;
        }

        if (barraVida != null)
        {
            barraVida.value = vida;
        }
    }

    void Morir()
    {
        // El jugador ha muerto
        estaMuerto = true;

        // Reproducir la animaci�n de muerte
        playerArmature.SetTrigger("die");

        // Desactivar el movimiento del jugador
        player.enabled = false;

        // Mostrar mensaje de muerte
        mensajeMuerte.gameObject.SetActive(true);
        mensajeMuerte.text = "�Has muerto!\nPresiona Enter para revivir.";

        // Desactivar los controles del jugador
        player.MoveSpeed = 0.0f;
        player.SprintSpeed = 0.0f;
    }

    void Update()
    {
        // Verificar si el jugador presiona ENTER para revivir
        if (estaMuerto && Input.GetKeyDown(KeyCode.Return))
        {
            Revivir();
        }

        // Si el jugador no est� muerto, permite atacar
        if (!estaMuerto && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clic detectado");
            playerArmature.SetTrigger("Atacar");
            StartCoroutine(Atacar());
        }
    }

    void Revivir()
    {
        // Restaurar la vida del jugador
        vida = 10;

        // Ocultar el mensaje de muerte
        mensajeMuerte.gameObject.SetActive(false);

        // Revivir al jugador y permitirle moverse
        estaMuerto = false;
        player.enabled = true;

        // Restaurar la velocidad del jugador
        player.MoveSpeed = 2.0f;
        player.SprintSpeed = 5.3f;

        // Cambiar la posici�n del jugador al punto de respawn
        transform.position = puntoRespawn.position;

        // Cambiar la animaci�n para que el jugador se levante
        playerArmature.SetTrigger("revivir");

        // Actualizar la UI
        ActualizarUI();

        Debug.Log("Jugador revivido. Salud restaurada a: " + vida + ". Posici�n: " + puntoRespawn.position);
    }

    IEnumerator Atacar()
    {
        rig1.weight = 0.0f;
        player.MoveSpeed = 0.0f;
        player.SprintSpeed = 0.0f;

        yield return new WaitForSeconds(1.0f);

        rig1.weight = 1.0f;
        player.MoveSpeed = 2.0f;
        player.SprintSpeed = 5.3f;
    }
}

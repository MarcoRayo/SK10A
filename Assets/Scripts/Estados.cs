using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine;
using UnityEngine.UI; // Necesario para UI
using TMPro; // Si usas TextMeshPro
using StarterAssets;
using System.Collections;

public class Estados : MonoBehaviour
{
    public Animator playerArmature;
    public Rig rig1;
    public ThirdPersonController player;
    public int vida = 10;
    public TextMeshProUGUI mensajeMuerte;  // Referencia al texto de UI

    private bool estaMuerto = false;

    void Start()
    {
        // Asegúrate de que el mensaje de muerte esté desactivado al principio
        mensajeMuerte.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("arma") && !estaMuerto)
        {
            vida -= 1;
            print("Vida: " + vida);
            if (vida <= 0)
            {
                Morir();
            }
        }
    }

    void Morir()
    {
        // El jugador ha muerto
        estaMuerto = true;

        // Reproducir la animación de muerte
        playerArmature.SetTrigger("die");

        // Desactivar el movimiento del jugador
        player.enabled = false;

        // Mostrar mensaje de muerte
        mensajeMuerte.gameObject.SetActive(true);
        mensajeMuerte.text = "¡Has muerto!\nPresiona Enter para revivir.";

        // Desactivar los controles del jugador (movimiento y ataques)
        player.MoveSpeed = 0.0f;
        player.SprintSpeed = 0.0f;
        player.enabled = false;
    }

    void Update()
    {
        // Verificar si el jugador presiona ENTER para revivir
        if (estaMuerto && Input.GetKeyDown(KeyCode.Return)) // ENTER es KeyCode.Return
        {
            Revivir();
        }

        // Si el jugador no está muerto, permite atacar
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

        // Opcional: Cambiar la animación para que el jugador se levante
        playerArmature.SetTrigger("revivir");

        // Información en consola
        Debug.Log("Jugador revivido. Salud restaurada a: " + vida);
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

using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Estados : MonoBehaviour
{
    public Animator playerArmature;
    public Rig rig1;
    public ThirdPersonController player;
    public int vida = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("arma"))
        {
            vida = vida -1;
            print("Vida: " + vida );
            if (vida <= 0)
            {
                playerArmature.SetTrigger("die");
                player.enabled = false;
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clic detectado");
            playerArmature.SetTrigger("Atacar");
            StartCoroutine(Atacar());
        }
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

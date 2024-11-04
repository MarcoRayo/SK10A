using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Estados : MonoBehaviour
{
    public Animator playerArmature;
    public Rig rig1;
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
        yield return new WaitForSeconds(1);
        rig1.weight = 1.0f;
    }
}

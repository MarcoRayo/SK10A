using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public RawImage _img;
    public float _x;
    public float _y;

    private void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime,_img.uvRect.size);
    }

    public void Empezar(string name) {
        SceneManager.LoadScene(name);
    }

    public void Salir() { 
        Application.Quit();
        Debug.Log("Estas saliendo");
    }   
}

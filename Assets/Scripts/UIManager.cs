using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //script que se encarga de manejar las escenas

//codigo que se va a encargar de manejar los elementos de la UI (textos, canvas, etc).
public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    public GameObject MenuScreen;

    void Awake() //solo se va a llamr una vez, depende del script
    {
        
    }

    public void ShowMenuScreen()
    {
        MenuScreen.SetActive(true); //la pantalla menu esta activa, aparece

    }
}

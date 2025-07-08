using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Button Menu_button;
    void Awake()
    {
        Menu_button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

}

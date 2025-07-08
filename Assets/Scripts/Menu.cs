using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button Arterial_leg;
    public Button Arterial_arm;
    public Button Venous_arm;
    public Button Venous_leg;

    void Awake()
    {
        Arterial_leg.onClick.AddListener(() =>
        {
            BeatManager.ResetTime(); 
            SceneManager.LoadScene(1);
        });

        Arterial_arm.onClick.AddListener(() =>
        {
            BeatManager.ResetTime();
            SceneManager.LoadScene(2);
        });

        Venous_leg.onClick.AddListener(() =>
        {
            BeatManager.ResetTime();
            SceneManager.LoadScene(3);
        });

        Venous_arm.onClick.AddListener(() =>
        {
            BeatManager.ResetTime();
            SceneManager.LoadScene(4);
        });
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerFinal : MonoBehaviour
{
    public Button _buttonSalir;

    private void Start()
    {
        _buttonSalir.onClick.AddListener(() => SalirButton());
    }
    void SalirButton()
    {
        Application.Quit();
    }
}

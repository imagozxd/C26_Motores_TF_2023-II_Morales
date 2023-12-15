using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerControl : MonoBehaviour
{
    public Button _buttonJugar;
    public Button _buttonSalir;

    private void Start()
    {
        _buttonJugar.onClick.AddListener(() => JugarButton());
        _buttonSalir.onClick.AddListener(() => SalirButton());
    }
    void JugarButton()
    {
        SceneManager.LoadScene("zz");
    }
    void SalirButton()
    {
        Application.Quit();
    }
}

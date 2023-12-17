using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerControl : MonoBehaviour
{
    public Button _buttonJugar;
    public Button _buttonSalir;

    public float delayCanvas = 5f;
    public GameObject canvas;

    private void Start()
    {
        canvas.GetComponent<Canvas>().enabled = false;

        Invoke("ActivarCanvas", delayCanvas);

        _buttonJugar.onClick.AddListener(() => JugarButton());
        _buttonSalir.onClick.AddListener(() => SalirButton());
    }
    void ActivarCanvas()
    {
        canvas.GetComponent<Canvas>().enabled = true;    
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

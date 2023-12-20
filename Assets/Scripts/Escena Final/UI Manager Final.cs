using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerFinal : MonoBehaviour
{
    public Button _buttonSalir;

    public ScoreSO scoreSO;
    public Text textoDias;

    private void Start()
    {
        _buttonSalir.onClick.AddListener(() => SalirButton());

        textoDias.text = "Pudiste salir en: " + scoreSO.dias.ToString() + " dias";

    }
    void SalirButton()
    {
        Application.Quit();
    }
}

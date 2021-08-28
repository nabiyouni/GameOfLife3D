using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameManager3D gameManager;

    public UnityEngine.UI.Button toggleStateButton;
    private string startString = "Start";
    private string stopString = "Stop";
    public UnityEngine.UI.Button clearButton;
    public UnityEngine.UI.Button randomButton;

    void Start()
    {
        toggleStateButton.GetComponentInChildren<TextMeshProUGUI>().text = startString;
        gameManager.setRunState(false);
    }

    public void toggleState()
    {
        bool newState = toggleStateButton.GetComponentInChildren<TextMeshProUGUI>().text == startString;
        toggleStateButton.GetComponentInChildren<TextMeshProUGUI>().text = newState ? stopString : startString;
        gameManager.setRunState(newState);
    }

    public void clearScreen() {
        gameManager.clearScreen();
    }

    public void randomizeScreen()
    {
        gameManager.randomizeScreen();
    }
}

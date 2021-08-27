using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameManager gameManager;

    public UnityEngine.UI.Button toggleStateButton;
    public string startString = "Start";
    public string stopString = "Stop";

    // Start is called before the first frame update
    void Start()
    {
        toggleStateButton.GetComponentInChildren<Text>().text = startString;
        gameManager.setRunState(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleState()
    {
        bool newState = toggleStateButton.GetComponentInChildren<Text>().text == startString;
        toggleStateButton.GetComponentInChildren<Text>().text = newState ? stopString : startString;
        gameManager.setRunState(newState);
    }
}

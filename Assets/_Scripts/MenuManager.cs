using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private Text mainText = null;

    public void EnableMenuPanel(bool startingGame, bool success = false)
    {
        // Enable panel
        menuPanel.SetActive(true);

        // Set main text
        if (startingGame)
        {
            mainText.text = "TOP DOWN GAME";
        }
        else if (success)
        {
            mainText.text = "SUCCESS";
        }
        else
        {
            mainText.text = "GAME OVER";
        }
    }

    public void DisableMenuPanel()
    {
        // Disable panel
        menuPanel.SetActive(false);
    }
}

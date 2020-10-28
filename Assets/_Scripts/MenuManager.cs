using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class shows and hides the menu panel
/// </summary>
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private Text mainText = null;

    /// <summary>
    /// Shows menu panel with a different text, depending on the parameters
    /// </summary>
    /// <param name="matchWasBeingPlayed">If a was being played</param>
    /// <param name="mapWasCleared">If the map was cleared, in case a match was being played</param>
    public void ShowMenuPanel(bool matchWasBeingPlayed, bool mapWasCleared = false)
    {
        // Enable panel
        menuPanel.SetActive(true);
        
        // Set main text
        if (!matchWasBeingPlayed)
        {
            mainText.text = "TOP DOWN GAME";
        }
        else if (mapWasCleared)
        {
            mainText.text = "SUCCESS";
        }
        else
        {
            mainText.text = "GAME OVER";
        }
    }

    /// <summary>
    /// Hides menu panel
    /// </summary>
    public void HideMenuPanel()
    {
        // Disable panel
        menuPanel.SetActive(false);
    }
}

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
    /// Shows the menu panel
    /// </summary>
    /// <remarks>
    /// The parameters influence the text shown on screen.
    /// </remarks>
    /// <param name="matchWasBeingPlayed">If a match was being played</param>
    /// <param name="mapWasCleared">If the map was cleared, in case a match was being played</param>
    public void ShowMenuPanel(bool matchWasBeingPlayed, bool mapWasCleared = false)
    {
        menuPanel.SetActive(true);
        
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
        menuPanel.SetActive(false);
    }
}

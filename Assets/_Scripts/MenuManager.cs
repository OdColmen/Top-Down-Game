using UnityEngine;
using UnityEngine.UI;

// This class shows and hides the menu panel
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private Text mainText = null;

    // The parameters influence the text shown on screen.
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

    public void HideMenuPanel()
    {
        menuPanel.SetActive(false);
    }
}

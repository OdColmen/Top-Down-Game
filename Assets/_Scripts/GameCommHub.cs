using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Communication Hub connects the main game classes; MenuManager, MatchManager and MapLoader,
/// in order to switch between menu and gameplay
/// </summary>
public class GameCommHub : MonoBehaviour
{
    [SerializeField] private MenuManager menu = null;
    [SerializeField] private MatchManager match = null;
    [SerializeField] private MapLoader mapLoader = null;

    void Start()
    {
        // Subscribe to game over event
        match.GameOver += GameOver;

        // Enable menu & disable game
        ShowMenuStopMatch(false);
    }

    /// <summary>
    /// Executes game over tasks
    /// </summary>
    private void GameOver(bool mapWasCleared)
    {
        ShowMenuStopMatch(true, mapWasCleared);
    }

    /// <summary>
    /// Hides the menu panel, loads a new map, and starts a new match
    /// </summary>
    public void HideMenuStartGame()
    {
        menu.HideMenuPanel();
        mapLoader.LoadMap();
        match.StartMatch();
    }

    /// <summary>
    /// Shows the menu panel, disables current map, and stops current match
    /// </summary>
    /// <param name="matchWasBeingPlayed">If a match was being played</param>
    /// <param name="mapWasCleared">If the map was cleared, in case a match was being played</param>
    public void ShowMenuStopMatch(bool matchWasBeingPlayed, bool mapWasCleared = false)
    {
        menu.ShowMenuPanel(matchWasBeingPlayed, mapWasCleared);
        mapLoader.DisableMap();
        match.StopMatch();
    }
}

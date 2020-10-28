using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        EnableMenuDisableGame(false);
    }
    
    private void GameOver(bool mapWasCleared)
    {
        EnableMenuDisableGame(true, mapWasCleared);
    }    

    public void EnableGameDisableMenu()
    {
        menu.DisableMenuPanel();
        mapLoader.LoadMap();
        match.StartMatch();
    }

    public void EnableMenuDisableGame(bool matchWasBeingPlayed, bool mapWasCleared = false)
    {
        menu.EnableMenuPanel(matchWasBeingPlayed, mapWasCleared);
        mapLoader.DisableMap();
        match.StopMatch();
    }
}

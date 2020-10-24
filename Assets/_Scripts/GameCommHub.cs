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
        EnableMenuDisableGame(true);
    }
    
    private void GameOver(bool success)
    {
        EnableMenuDisableGame(false, success);
    }    

    public void EnableGameDisableMenu()
    {
        menu.DisableMenuPanel();
        mapLoader.LoadMap();
        match.StartMatch();
    }

    public void EnableMenuDisableGame(bool startingGame, bool success = false)
    {
        menu.EnableMenuPanel(startingGame, success);
        mapLoader.DisableMap();
        match.StopMatch();
    }
}

using UnityEngine;

// Game Communication Hub connects the main game classes; MenuManager, MatchManager and MapLoader,
// in order to switch between menu and gameplay
public class GameCommHub : MonoBehaviour
{
    [SerializeField] private MenuManager menu = null;
    [SerializeField] private MatchManager match = null;
    [SerializeField] private MapLoader mapLoader = null;

    void Start()
    {
        match.GameOver += GameOver;

        ShowMenuStopMatch(false);
    }

    private void GameOver(bool mapWasCleared)
    {
        ShowMenuStopMatch(true, mapWasCleared);
    }

    public void HideMenuStartGame()
    {
        menu.HideMenuPanel();
        mapLoader.LoadMap();
        match.StartMatch();
    }

    public void ShowMenuStopMatch(bool matchWasBeingPlayed, bool mapWasCleared = false)
    {
        menu.ShowMenuPanel(matchWasBeingPlayed, mapWasCleared);
        mapLoader.DisableMap();
        match.StopMatch();
    }

    private void OnDestroy()
    {
        match.GameOver -= GameOver;
    }
}

using UnityEngine;

// This class handles the game characters, enabling and disabling them,
// and invokes the GameOver event when needed.
public class MatchManager : MonoBehaviour
{
    // GameOver Is invoked when the player wins or loses a match.
    public delegate void GameOver_EventHandler(bool mapWasCleared);
    public event GameOver_EventHandler GameOver;

    CharacterEnabler characterEnabler;
    ItemCollector itemCollector;
    HealthManager healthManager;

    void Awake()
    {
        characterEnabler = GetComponent<CharacterEnabler>();
        
        itemCollector = GetComponent<ItemCollector>();
        itemCollector.AllItemsWereCollected += AllItemsWereCollected;
        
        healthManager = GetComponent<HealthManager>();
        healthManager.HealthReachedZero += HealthReachedZero;
    }

    // Starts a new match by enabling all the characters
    public void StartMatch()
    {
        healthManager.RestoreHealth();
        characterEnabler.EnableCharacters();
    }

    // Stops current match by disabling all the characters
    public void StopMatch()
    {
        characterEnabler.DisableCharacters();
    }

    // Invokes the Game Over event. Intended to be used when the map was cleared.
    private void AllItemsWereCollected()
    {
        GameOver?.Invoke(true);
    }

    // Invokes the Game Over event. Intended to be used when the map was not cleared.
    private void HealthReachedZero()
    {
        GameOver?.Invoke(false);
    }
}
using UnityEngine;

/// <summary>
/// This class handles the game characters enabling and disabling them,
/// and invokes the GameOver event when needed.
/// </summary>
public class MatchManager : MonoBehaviour
{
    public delegate void GameOver_EventHandler(bool mapWasCleared);
    /// <summary>
    /// It's invoked when the player wins or loses a match.
    /// </summary>
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

    /// <summary>
    /// Starts a new match by enabling all the characters
    /// </summary>
    public void StartMatch()
    {
        healthManager.RestoreHealth();
        characterEnabler.EnableCharacters();
    }

    /// <summary>
    /// Stops current match by disabling all the characters
    /// </summary>
    public void StopMatch()
    {
        characterEnabler.DisableCharacters();
    }

    /// <summary>
    /// Invokes the Game Over event. Intended to be used when the map was cleared.
    /// </summary>
    private void AllItemsWereCollected()
    {
        GameOver?.Invoke(true);
    }

    /// <summary>
    /// Invokes the Game Over event. Intended to be used when the map was not cleared.
    /// </summary>
    private void HealthReachedZero()
    {
        GameOver?.Invoke(false);
    }
}
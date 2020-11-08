using UnityEngine;

/// <summary>
/// This class manages the hero and NPC GameObjects, the item collection logic,
/// and invokes the GameOver event.
/// </summary>
public class MatchManager : MonoBehaviour
{
    public delegate void GameOverEventHandler(bool mapWasCleared);
    /// <summary>
    /// It's invoked when the player wins or loses a match.
    /// </summary>
    public event GameOverEventHandler GameOver;

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
    /// Invokes the Game Over event. Intented to be used when the map was cleared.
    /// </summary>
    private void AllItemsWereCollected()
    {
        GameOver?.Invoke(true);
    }

    /// <summary>
    /// Invokes the Game Over event. Intented to be used when the map was not cleared.
    /// </summary>
    private void HealthReachedZero()
    {
        GameOver?.Invoke(false);
    }
}
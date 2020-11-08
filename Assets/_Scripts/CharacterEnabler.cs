using UnityEngine;

/// <summary>
/// This class enables and disables every game character
/// </summary>
class CharacterEnabler : MonoBehaviour
{
    [SerializeField] private GameObject[] characters = null;

    /// <summary>
    /// Enables characters on stage
    /// </summary>
    public void EnableCharacters()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(true);
        }
    }

    /// <summary>
    /// Disables characters on stage
    /// </summary>
    public void DisableCharacters()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
    }
}

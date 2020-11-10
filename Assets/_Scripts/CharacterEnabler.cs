using UnityEngine;

// This class enables and disables every game character
class CharacterEnabler : MonoBehaviour
{
    [SerializeField] private GameObject[] characters = null;

    public void EnableCharacters()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(true);
        }
    }

    public void DisableCharacters()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
    }
}

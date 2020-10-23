using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    private GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadMap(GameObject map)
    {
        // Instantiate map on game
        Instantiate(map);

        Debug.Log("Load Map");
    }
}

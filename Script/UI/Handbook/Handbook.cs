using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handbook : MonoBehaviour
{
    public List<GameObject> gameObjectList = new List<GameObject>();
    public void SelectThis(GameObject that)
    {
        foreach (GameObject gameUI in gameObjectList)
        {
            gameUI.SetActive(false);
        }
        that.SetActive(true);
        
    }
}

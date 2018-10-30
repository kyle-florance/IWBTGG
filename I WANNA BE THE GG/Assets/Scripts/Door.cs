using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Door : MonoBehaviour {

    public string nextScene;
    public int doorID;
    //public Transform exitLocation;
    //public Player playerPrefab;
    public GameObject player;

    private GameObject[] sceneObjects;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}

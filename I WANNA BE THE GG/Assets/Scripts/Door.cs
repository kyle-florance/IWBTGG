using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Door : MonoBehaviour {

    public string nextScene;
    public int doorID;
    private Transform exitLocation;
    //public Player playerPrefab;
    public GameObject player;

    private GameObject[] doors;

    void Awake()
    {
        exitLocation = this.transform.GetChild(0).gameObject.transform;
        GameMaster gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if (gm.usingDoor)
        {
            if (GameMaster.gm.doorID == this.doorID)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = this.exitLocation.position;
                GameMaster.gm.usingDoor = false;
            }
            
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //GameMaster.gm.lastLocation = exitLocation;
            GameMaster.gm.usingDoor = true;
            GameMaster.gm.doorID = doorID;
            SceneManager.LoadScene(nextScene);
        }
    }
}

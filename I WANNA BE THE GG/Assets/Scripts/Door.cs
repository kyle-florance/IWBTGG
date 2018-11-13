using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Door : MonoBehaviour {

    public string nextScene;
    public int doorID;
    private Transform exitLocation;
    private GameObject player;
    //public Transform playerPrefab;


    void Awake()
    {
        exitLocation = this.transform.GetChild(0).gameObject.transform;
        GameMaster gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if (gm.usingDoor)
        {
            if (GameMaster.gm.doorID == this.doorID)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                //Destroy(player);
                player.transform.position = exitLocation.position;
                //Instantiate(playerPrefab, exitLocation.position, exitLocation.rotation);
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

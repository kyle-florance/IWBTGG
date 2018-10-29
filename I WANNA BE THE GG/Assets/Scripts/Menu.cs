using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {


	// Use this for initialization
	void Start () {
        //pressLoad();
	}
	
    public void pressLoad()
    {
        GameMaster.gm.load();
    }

    public void pressSave()
    {
        GameMaster.gm.spawnPositionX = GameObject.FindGameObjectWithTag("Respawn").transform.position.x;
        GameMaster.gm.spawnPositionY = GameObject.FindGameObjectWithTag("Respawn").transform.position.y;
        GameMaster.gm.spawnPositionZ = GameObject.FindGameObjectWithTag("Respawn").transform.position.z;
        GameMaster.gm.save();
    }
}

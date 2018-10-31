using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveSpawnPoint : MonoBehaviour {

    Transform player;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            player = GameObject.FindWithTag("Player").transform;

            GameMaster gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

            gm.SceneName = SceneManager.GetActiveScene().name;
            gm.spawnPositionX = player.position.x;
            gm.spawnPositionY = player.position.y;
            gm.spawnPositionZ = player.position.z;
            //Debug.Log("Move and Save Spawn Point Position X:  " + gm.spawnPositionX);
            //Debug.Log("Move and Save Spawn Point Position Y:  " + gm.spawnPositionY);
            gm.spawnPoint.SetPositionAndRotation(player.position, player.rotation);
            gm.save();
        }
    }
}

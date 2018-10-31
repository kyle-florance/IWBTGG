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
            gm.spawnPositionX = GameObject.FindGameObjectWithTag("Respawn").transform.position.x;
            gm.spawnPositionY = GameObject.FindGameObjectWithTag("Respawn").transform.position.y;
            gm.spawnPositionZ = GameObject.FindGameObjectWithTag("Respawn").transform.position.z;
            Debug.Log("Save Spawn Point Position X:  " + gm.spawnPositionX);
            Debug.Log("Save Spawn Point Position X:  " + gm.spawnPositionY);
            Debug.Log("Save Spawn Point Position X:  " + gm.spawnPositionZ);
            gm.spawnPoint.SetPositionAndRotation(player.position, player.rotation);
            gm.save();
        }
    }
}

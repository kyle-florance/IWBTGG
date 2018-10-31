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

            gm.spawnPoint.SetPositionAndRotation(player.position, player.rotation);
            gm.save();
        }
    }
}

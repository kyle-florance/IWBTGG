using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSpawnPoint : MonoBehaviour {

    Transform player;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            //Debug.Log("Collision between Save Point and Bullet");
            player = GameObject.FindWithTag("Player").transform;

            GameMaster gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            gm.spawnPoint.SetPositionAndRotation(player.position, player.rotation);
        }
    }
}

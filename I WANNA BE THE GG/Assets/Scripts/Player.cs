using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public class PlayerStats
    {
        public int Damage = 1;
    }
    public PlayerStats playerStats = new PlayerStats();

    void Update()
    {
        if (Input.GetButtonDown("Respawn"))
        {
            this.respawn();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.die();
        }
    }
    public void die()
    {
        GameMaster.killPlayer(this);
    }
    public void respawn()
    {
        GameMaster.respawnPlayer(this);
    }


}

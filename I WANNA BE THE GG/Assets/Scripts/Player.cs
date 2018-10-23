using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead;
    public GameObject blood;


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
        if (other.gameObject.tag == "Enemy" && !isDead)
        {
            this.die();
            isDead = true;
        }
    }
    public void die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);

        GameMaster.killPlayer(this);
    }
    public void respawn()
    {
        GameMaster.respawnPlayer(this);
    }

}

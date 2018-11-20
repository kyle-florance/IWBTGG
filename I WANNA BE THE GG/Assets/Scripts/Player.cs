using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead;
    public GameObject blood;

    public static Player player;

    public class PlayerStats
    {
        public int Damage = 1;
    }
    public PlayerStats playerStats = new PlayerStats();

    void Awake()
    {
        if (player == null)
        {
            player = this;
            DontDestroyOnLoad(player);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

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

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Enemy" && !isDead)
        {
            Debug.Log("death");
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
        GameMaster.respawn(this);
    }


}

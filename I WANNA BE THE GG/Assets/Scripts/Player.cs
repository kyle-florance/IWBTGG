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

    public void die()
    {
        GameMaster.killPlayer(this);
    }
    public void respawn()
    {
        GameMaster.killPlayer(this);
    }


}

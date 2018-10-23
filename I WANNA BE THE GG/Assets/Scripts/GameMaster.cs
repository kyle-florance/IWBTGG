using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public GameObject blood;
    public AudioClip[] slams;
    //private AudioClip shootClip;

    // Use this for initialization
    void Start () {
        if (gm == null)
        {
            gm = this;
        }
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void respawnPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.RespawnPlayer();
    }
    public static void killPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine("WaitForKeyPress");   
    }
    private IEnumerator WaitForKeyPress()
    {
        Random.Range(0, slams.Length);

        while (!Input.GetButtonDown("Respawn"))
        {
            yield return null;
        }
        gm.RespawnPlayer();
    }
}

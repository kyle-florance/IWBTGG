using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;

    public AudioSource slams;
    public AudioClip[] audioClipArray;

    //private AudioClip shootClip;

    // Use this for initialization
    void Start () {
        if (gm == null)
        {
            gm = this;
        }
        slams = gameObject.GetComponent<AudioSource>();

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
        slams.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        slams.PlayOneShot(slams.clip);
        while (!Input.GetButtonDown("Respawn"))
        {
            yield return null;
        }
        slams.Stop();
        gm.RespawnPlayer();
    }
}

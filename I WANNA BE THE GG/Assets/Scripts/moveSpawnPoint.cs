using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveSpawnPoint : MonoBehaviour {

    Transform player;
    public Transform moon;
    bool rotating = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if(!rotating)
            {
                StartCoroutine("RotateMoon");
            }
            

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
    private IEnumerator RotateMoon()
    {
        rotating = true;
        float startRotation = moon.transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / 0.5f) % 360.0f;
            moon.transform.eulerAngles = new Vector3(moon.transform.eulerAngles.x, moon.transform.eulerAngles.y, zRotation);
            yield return null;
        }
        rotating = false;
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;

    public String SceneName;
    public float spawnPositionX;
    public float spawnPositionY;
    public float spawnPositionZ;
    public int deathCount = 0;
    public int respawnCount = 0;

    public AudioSource slams;
    public AudioClip[] audioClipArray;

    public Camera mainCamera;
    public Camera blackScreen;

    public Canvas GameOver;

    public Transform nextLocation;


    //private AudioClip shootClip;

    // Use this for initialization

   
    void Start () {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gm);
            slams = gameObject.GetComponent<AudioSource>();
            mainCamera.enabled = true;
            blackScreen.enabled = false;
            GameOver.gameObject.SetActive(false);
            SceneName = SceneManager.GetActiveScene().name;
            
        }
        else
        {
            
            DestroyImmediate(gameObject);
        }

    }

    public void RespawnPlayer()
    {
        if (SceneManager.GetActiveScene().name != SceneName)
        {
            load();
            SceneManager.LoadScene(SceneName);
            Vector3 spawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
            }
            Instantiate(playerPrefab, spawnPosition, spawnPoint.rotation);

        } else
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        
        mainCamera.enabled = true;
        blackScreen.enabled = false;
    }

    public static void respawnPlayer(Player player)
    {
        gm.respawnCount++;
        Destroy(player.gameObject);
        gm.StartCoroutine("RespawnDelay");
    }

    public static void killPlayer(Player player)
    {
        gm.deathCount++;
        Destroy(player.gameObject);        
        gm.StartCoroutine("WaitForKeyPress");   
    }
    
    private IEnumerator WaitForKeyPress()
    {
        GameOver.gameObject.SetActive(true);
        slams.clip = audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length)];
        slams.PlayOneShot(slams.clip);
        while (!Input.GetButtonDown("Respawn"))
        {
            yield return null;
        }
        slams.Stop();
        blackScreen.enabled = true;
        GameOver.gameObject.SetActive(false);
        mainCamera.enabled = false;
        yield return new WaitForSeconds(.05f);
        gm.RespawnPlayer();
    }

    private IEnumerator RespawnDelay()
    {

        blackScreen.enabled = true;
        mainCamera.enabled = false;
        yield return new WaitForSeconds(.05f);
        gm.RespawnPlayer();
    }

    // load player data
    public void load()
    {
        if(File.Exists(Application.persistentDataPath+"/saveFile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
            SaveFile data = (SaveFile)bf.Deserialize(file);
            file.Close();

            SceneName = data.SceneName;
            spawnPositionX = data.spawnPositionX;
            spawnPositionY = data.spawnPositionY;
            spawnPositionZ = data.spawnPositionZ;
            deathCount = data.deathCount;
            respawnCount = data.respawnCount;

            //Debug.Log("file loaded " + Application.persistentDataPath);
        } else
        {
            //Debug.Log("file does not exist " + Application.persistentDataPath);
        }
    }
    // save player data
    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile.dat");
        SaveFile data = new SaveFile();

        data.SceneName = SceneName;
        data.spawnPositionX = spawnPositionX;
        data.spawnPositionY = spawnPositionY;
        data.spawnPositionZ = spawnPositionZ;
        data.deathCount = deathCount;
        data.respawnCount = respawnCount;

        bf.Serialize(file, data);
        file.Close();

        //Debug.Log("file saved");
    }
    
}
[System.Serializable]
class SaveFile
{
    public String SceneName;
    public float spawnPositionX;
    public float spawnPositionY;
    public float spawnPositionZ;
    public int deathCount;
    public int respawnCount;
}

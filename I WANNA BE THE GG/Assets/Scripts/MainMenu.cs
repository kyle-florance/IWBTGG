using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public String FirstLevel;
    public Transform initialSpawn;

    public void LoadButton()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile.dat", FileMode.Open);
            SaveFile data = (SaveFile)bf.Deserialize(file);
            file.Close();

            SceneManager.LoadScene(data.SceneName);
            //Debug.Log("loaded Spawn Point Position X:  " + spawnPositionX);
            //Debug.Log("loaded Spawn Point Position Y:  " + spawnPositionY);
            GameMaster.gm.RespawnPlayer();
            //Debug.Log("file loaded " + Application.persistentDataPath);
        }
    }
    public void NewGame()
    {
        GameMaster.gm.SceneName = FirstLevel;

        try
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.sa");
            //Debug.Log("Deleted");
        } catch
        {
            Debug.Log("No save file to delete");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile.dat");
        SaveFile data = new SaveFile();

        data.SceneName = FirstLevel;
        data.spawnPositionX = initialSpawn.position.x;
        data.spawnPositionY = initialSpawn.position.y;
        data.spawnPositionZ = initialSpawn.position.z;
        data.deathCount = 0;
        data.respawnCount = 0;

        bf.Serialize(file, data);
        file.Close();
        
        
        //Debug.Log(GameObject.FindGameObjectWithTag("Respawn").transform.position);
        SceneManager.LoadScene(FirstLevel);
        GameObject.FindGameObjectWithTag("Respawn").transform.position = initialSpawn.transform.position;
        GameMaster.gm.RespawnPlayer();
    }
}

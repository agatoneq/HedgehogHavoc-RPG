using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Assets.Scripts.Player;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SaveManager : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save();
            Debug.Log("Saved");
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            Load();
            Debug.Log("Loaded");
        }
    }
    private void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath+"/"+ "SaveTest.dat", FileMode.Create);
            SaveData data = new SaveData();
            data.ActiveScene = SceneManager.GetActiveScene().buildIndex;
            SavePlayer(data);
            bf.Serialize(file, data);

            file.Close();
            Debug.Log("Saving");
        }
        catch (System.Exception)
        {
            Debug.Log("B³¹d przy zapisywaniu");

        }
    }
    private void SavePlayer(SaveData data)
    {
        player = Player.Instance;
        Vector3 position = GameObject.Find("PlayerCapsule").transform.position;
        data.MyPlayerData = new PlayerData(player.damage, player.maxhealth, 
            player.armor,player.attackRange,player.attackRate,player.currentHealth, position);
    }
    //zapisywanie ekwitunku i przedmiotów posiadanych przez gracza
    //zapisywanie ukoñczonych  przez gracza zadañ i zadañ aktywnych
    private void Load()
    {
        //try
       // {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
           
            file.Close();
            if (SceneManager.GetActiveScene().buildIndex != data.ActiveScene)
            {
                SceneManager.LoadScene(data.ActiveScene);
            }
            LoadPlayer(data);
            
            Debug.Log("Loading");
      // }
      // catch (System.Exception)
       // {
            Debug.Log("B³¹d przy wczytywaniu");

        //}
    }
    private void LoadPlayer(SaveData data)
    {
        player = Player.Instance;
        player.damage = data.MyPlayerData.damage;
        player.maxhealth = data.MyPlayerData.maxHealth;
        player.armor = data.MyPlayerData.armor;
        player.attackRange = data.MyPlayerData.attackRange;
        player.attackRate = data.MyPlayerData.attackRate;
        player.currentHealth = data.MyPlayerData.currentHealth;
        Transform playerCapsule = GameObject.Find("PlayerCapsule").transform;
        Transform capsule = playerCapsule.GetChild(1).transform;
        Debug.Log(data.MyPlayerData.x);
        Debug.Log(data.MyPlayerData.y);
        Debug.Log(data.MyPlayerData.z);
        playerCapsule.position = new Vector3(data.MyPlayerData.x, data.MyPlayerData.y, data.MyPlayerData.z);
        capsule.GetComponent<PlayerStats>().updateStats();
    }
    //wczytywanie ekwitunku i przedmiotów posiadanych przez gracza
    //wczytywanie ukoñczonych  przez gracza zadañ i zadañ aktywnych
}

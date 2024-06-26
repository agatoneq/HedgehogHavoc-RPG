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
        Debug.Log("�cie�ka do zapisu: "+ Application.persistentDataPath);
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
            Debug.LogErrorFormat("B��d przy zapisywaniu");

        }
    }
    private void SavePlayer(SaveData data)
    {
        player = Player.Instance;
        Vector3 position = GameObject.Find("PlayerCapsule").transform.position;
        data.MyPlayerData = new PlayerData(player.damage, player.maxhealth, 
            player.armor,player.attackRange,player.attackRate,player.currentHealth, position);
    }
    //zapisywanie ekwitunku i przedmiot�w posiadanych przez gracza
    //zapisywanie uko�czonych  przez gracza zada� i zada� aktywnych
    private void Load()
    {
       try
        {
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
        }
        catch (System.Exception)
        {
            Debug.LogErrorFormat("B��d przy wczytywaniu");

        }
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
        Transform playerCapsule;
        if (playerCapsule = GameObject.Find("PlayerCapsule").transform){
            PlayerStats stats;
            if(stats = playerCapsule.GetComponent<PlayerStats>())
            {
              //  stats.updateStats();
            }
            else
            {
                Debug.LogErrorFormat("brak PlayserStats w PlayerCapsule");
            }
            //nagle nie dzia�a zmiana pozycji
            playerCapsule.position = new Vector3(data.MyPlayerData.x, data.MyPlayerData.y, data.MyPlayerData.z);
        }
        else
        {
            Debug.LogErrorFormat("brak PlayerCapsule");
        }

    }
    //wczytywanie ekwitunku i przedmiot�w posiadanych przez gracza
    //wczytywanie uko�czonych  przez gracza zada� i zada� aktywnych
}

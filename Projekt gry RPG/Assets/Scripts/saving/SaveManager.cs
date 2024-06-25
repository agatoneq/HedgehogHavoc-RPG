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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath+"/"+ "SaveTest.dat", FileMode.Create);
            SaveData data = new SaveData();
            data.ActiveScene = SceneManager.GetActiveScene();
            SavePlayer(data);

            file.Close();
        }
        catch (System.Exception)
        {

            
        }
    }
    private void SavePlayer(SaveData data)
    {
        player = Player.Instance;
        Vector3 position = GameObject.Find("PlayerCapsule").transform.position;
        data.MyPlayerData = new PlayerData(player.damage, player.maxhealth, 
            player.armor,player.attackRange,player.attackRate,player.currentHealth, position);
    }
    private void Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
           
            file.Close();
            LoadPlayer(data);
            SceneManager.SetActiveScene(data.ActiveScene);
        }
        catch (System.Exception)
        {


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
        GameObject.Find("PlayerCapsule").transform.position = new Vector3(data.MyPlayerData.x, data.MyPlayerData.y, data.MyPlayerData.z);
    }
}

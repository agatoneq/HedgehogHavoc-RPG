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
        //try
        //{
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath+"/"+ "SaveTest.dat", FileMode.Create);
            SaveData data = new SaveData();
            data.ActiveScene = SceneManager.GetActiveScene().buildIndex;
            SavePlayer(data);
            SaveInventory(data);
            bf.Serialize(file, data);

            file.Close();
            Debug.Log("Saving");
        //}
        //catch (System.Exception)
        //{
            Debug.LogErrorFormat("B��d przy zapisywaniu");

        //}
    }
    private void SavePlayer(SaveData data)
    {
        player = Player.Instance;
        Vector3 position = GameObject.Find("PlayerCapsule").transform.position;
        data.MyPlayerData = new PlayerData(player.damage, player.maxhealth, 
            player.armor,player.attackRange,player.attackRate,player.currentHealth, position,
            player.quest, player.SkillPoint, player.Level, player.CurrentExp, player.NeededExp);
    }
    //zapisywanie ekwipunku i przedmiot�w posiadanych przez gracza
    private void SaveInventory(SaveData data)
    {
        player = Player.Instance;
        data.MyInventoryData = new InventoryData();
        foreach (Item i in player.Inventory.Items)
        {
            data.MyInventoryData.addItemsData(i.name, i.icon, i.isDefaultItem, i.Desc);
        }

    }
    private void SaveEquipment(SaveData data)
    {

    }
    public void Load()
    {
      // try
       // {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.persistentDataPath + "/" + "SaveTest.dat")) 
            {
                FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat", FileMode.Open);
                SaveData data = (SaveData)bf.Deserialize(file);

                file.Close();
                if (SceneManager.GetActiveScene().buildIndex != data.ActiveScene)
                {
                    SceneManager.LoadScene(data.ActiveScene);
                }
                LoadPlayer(data);
                LoadInventory(data);
                Debug.Log("Loading");
            }
            else
            {
                Debug.Log("No save file");
            }
       // }
        //catch (System.Exception)
        //{
            Debug.LogErrorFormat("B��d przy wczytywaniu");

        //}
    }
    private void LoadPlayer(SaveData data)
    {
        player = Player.Instance;
        player.PlayerLoad(data.MyPlayerData.damage, data.MyPlayerData.maxHealth,
            data.MyPlayerData.armor, data.MyPlayerData.attackRange, data.MyPlayerData.attackRate, data.MyPlayerData.currentHealth,
            data.MyPlayerData.quest, data.MyPlayerData.SkillPoint, 
            data.MyPlayerData.Level, data.MyPlayerData.CurrentExp, data.MyPlayerData.NeededExp);
        Transform playerCapsule;
        if (playerCapsule = GameObject.Find("PlayerCapsule").transform){
            PlayerStats stats;
            if(stats = playerCapsule.GetChild(1).transform.GetComponent<PlayerStats>())
            {
                stats.updateStats();
            }
            else
            {
                Debug.LogErrorFormat("brak PlayserStats w PlayerCapsule");
            }
            //nagle nie dzia�a zmiana pozycji
           // playerCapsule.position = new Vector3(data.MyPlayerData.x, data.MyPlayerData.y, data.MyPlayerData.z);
        }
        else
        {
            Debug.LogErrorFormat("brak PlayerCapsule");
        }

    }

    //wczytywanie ekwipunku i przedmiot�w posiadanych przez gracza
    private void LoadInventory(SaveData data)
    {
        player = Player.Instance;
        player.Inventory.ClearItemsFromInv();
        foreach(ItemData iD in data.MyInventoryData.items) 
        {
            Item item = new Item(iD.name, SpriteDeserializer.Deserialize(iD.icon) , iD.isDefaultItem, iD.Desc);
            player.Inventory.AddItemToInv(item);
        }
    }
    private void LoadEquipment(SaveData data)
    {

    }
}

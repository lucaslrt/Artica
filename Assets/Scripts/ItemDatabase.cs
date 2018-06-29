using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;
    private string jsonString;

    void Start() {
        Item item = new Item();
        if (Application.platform == RuntimePlatform.Android) {
            TextAsset file = Resources.Load("Items") as TextAsset;
            Debug.Log("Json path: " + (file).ToString());
            itemData = JsonMapper.ToObject((file).ToString());
        } else {
            itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        }

        ConstructItemDatabase();
        Debug.Log("ItemDatabase: title of 1st element = " + database[0].Title);
    }

    public Item FetchItemById(int id) {

        for (int i = 0; i < database.Count; i++) {
            if (database[i].Id == id) {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase() {
        for (int i = 0; i < itemData.Count; i++) {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["sound"].ToString()));
            Debug.Log("ConstructItemDatabase: item added = " + database[i].Title);
        }
    }
}

public class Item {

    public int Id { get; set; }
    public string Title { get; set; }
    public string Sound { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, string sound) {
        this.Id = id;
        this.Title = title;
        this.Sound = sound;
        this.Sprite = Resources.Load<Sprite>("Icons/" + title);
    }

    public Item() {
        this.Id = -1;
    }
}

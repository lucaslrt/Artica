using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour {
    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private void Start() {
        database = GetComponent<ItemDatabase>();
        slotAmount = 15;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject; 

        for(int i = 0; i < slotAmount; i++) {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            AddItem(i);
        }
    }

    public void AddItem(int id) {
        Item itemToAdd = database.FetchItemById(id);

        for(int i = 0; i < items.Count; i++) {
            if(items[i].Id == -1) {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd;
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.transform.position = Vector2.zero;

                break;
            } 
            else if (items[i].Id == id) {
                // Adicionar o som do item aqui.
                ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();

                break;
            }
        }
    }
}

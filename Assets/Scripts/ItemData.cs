using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Item item;
    // TODO: make sound;

    private Transform originalParent;
    private Vector2 currentPosition;

    public void OnBeginDrag(PointerEventData eventData) {
        if(item != null) {
            originalParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (item != null) {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        this.transform.SetParent(originalParent);
        currentPosition = this.transform.position;
        this.transform.position = originalParent.transform.position;
        CreateNewItemOnCurrentPosition();
    }

    private void CreateNewItemOnCurrentPosition() {

        GameObject newItem = (GameObject) Instantiate(Resources.Load("Prefabs/Item"));
        newItem.transform.SetParent(originalParent);
        newItem.GetComponent<ItemData>().item = this.item;
        newItem.GetComponent<Image>().sprite = this.item.Sprite;
        newItem.AddComponent<Rigidbody2D>();
        newItem.GetComponent<Rigidbody2D>().gravityScale = 0;
        newItem.AddComponent<BoxCollider2D>();

        newItem.transform.position = currentPosition;
    }
}

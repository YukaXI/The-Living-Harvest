using System;
using Project;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    
    private InventoryManager inventoryManager;
    
    private void Awake()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>(FindObjectsInactive.Include);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inventoryManager.AddItem(itemName, sprite);
            Destroy(gameObject);
        }
    }
}

using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project
{
    public class ItemSlot : MonoBehaviour
    {
        public string itemName;
        public int quantity;
        public Sprite itemSprite;
        [SerializeField] Sprite emptySprite;
        public bool isFull;
        
        [SerializeField]
        private TMP_Text quantityText;
        
        [SerializeField]
        private Image itemImage;
        

        public void AddItem(string itemName, int quantity, Sprite itemSprite)
        {
            this.itemName = itemName;
            this.quantity = quantity;
            this.itemSprite = itemSprite;
            isFull = true;
            
            itemImage.enabled = true;
            itemImage.sprite = itemSprite;
        }

        private void EmptySlot()
        {
            quantityText.enabled = false;
            itemImage.sprite = emptySprite;
        }
        
    }
}

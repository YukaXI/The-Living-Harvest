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
        public Sprite itemSprite;
        [SerializeField] Sprite emptySprite;
        public bool isFull;
        public bool _pickedUpBook = false;
        
       
        [SerializeField] private Image itemImage;
        
        [Header("Quest Items")]
        [SerializeField] private GameObject _book;
        [SerializeField] private GameObject _flour;
        [SerializeField] public GameObject _blueberryMuffin;

        public bool lastWalterTalk = false;
        
        

        public void AddItem(string itemName, Sprite itemSprite)
        {
            this.itemName = itemName;
            this.itemSprite = itemSprite;
            isFull = true;
            
            itemImage.enabled = true;
            itemImage.sprite = itemSprite;
        }

        public void ClearSlot()
        {
            itemSprite = null;
            isFull = false;

            if (itemImage)
            {
                itemImage.sprite = emptySprite;
            }
        }

        public void RemoveBook()
        {
            if (_flour == null) return;
                
            ClearSlot();
                    
            _flour.SetActive(true);
        }

        public void RemoveFlour()
        {
            ClearSlot();
            if (_blueberryMuffin)
            {
                _blueberryMuffin.SetActive(true);
            }
        }

        public void RemoveBlueberryMuffin()
        {
            ClearSlot();
        }
        
    }
}

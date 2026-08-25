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
        [SerializeField] private GameObject _flour;
        [SerializeField] private GameObject _blueberryMuffin;
        
        

        public void AddItem(string itemName, Sprite itemSprite)
        {
            this.itemName = itemName;
            this.itemSprite = itemSprite;
            isFull = true;
            
            itemImage.enabled = true;
            itemImage.sprite = itemSprite;
        }

        public void EmptySlot()
        {
            itemSprite = null;
            isFull = false;

            if (itemImage != null)
            {
                itemImage.sprite = emptySprite;

                if (_flour != null)
                {
                    _flour.SetActive(true);
                }

                else
                {
                    _blueberryMuffin.SetActive(true);
                }

               
            }
        }
        
    }
}

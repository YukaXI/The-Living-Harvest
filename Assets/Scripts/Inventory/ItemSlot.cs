using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        public string itemName;
        public int quantity;
        public Sprite itemSprite;
        public bool isFull;
        
        [SerializeField]
        private TMP_Text quantityText;
        
        [SerializeField]
        private Image itemImage;

        public GameObject selectedShader;
        public bool thisItemSelected;

        public void AddItem(string itemName, int quantity, Sprite itemSprite)
        {
            this.itemName = itemName;
            this.quantity = quantity;
            this.itemSprite = itemSprite;
            isFull = true;
            
            itemImage.enabled = true;
            itemImage.sprite = itemSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnLeftClick();
            }
            
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnRightClick();
            }
        }

        public void OnLeftClick()
        {
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }

        public void OnRightClick()
        {
            
        }
    }
}

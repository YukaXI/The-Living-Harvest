using UnityEngine;

namespace Project
{
    public class InventoryManager : MonoBehaviour
    {
        public ItemSlot[] itemSlot;
        
        
        public void AddItem(string itemName, int quantity, Sprite itemSprite)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false)
                {
                    itemSlot[i].AddItem(itemName, quantity, itemSprite);
                    return;
                }
            }
        }
    }
}

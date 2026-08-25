using UnityEngine;

namespace Project
{
    public class InventoryManager : MonoBehaviour
    {
        private NPC _npc;
        public ItemSlot[] itemSlot;



        public void AddItem(string itemName, Sprite itemSprite)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false)
                {
                    itemSlot[i].AddItem(itemName, itemSprite);
                    return;
                }
            }
        }

        public void RemoveItemByName(string nameToRemove)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] != null && itemSlot[i].isFull && itemSlot[i].itemName == nameToRemove)
                {
                    itemSlot[i].EmptySlot();
                }
            }
        }
    }
}


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

        public void RemoveBook()
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] != null && itemSlot[i].isFull && itemSlot[i].itemName == "Minzy's Buch")
                {
                    itemSlot[i].RemoveBook();
                    return;
                }
            }
        }
        
        public void RemoveFlour()
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] != null && itemSlot[i].isFull && itemSlot[i].itemName == "Mehl")
                {
                    itemSlot[i].RemoveFlour();
                    return;
                }
            }
        }
        
        public void RemoveBlueBerryMuffin()
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] != null && itemSlot[i].isFull && itemSlot[i].itemName == "BlaubeerMuffin")
                {
                    itemSlot[i].RemoveBlueberryMuffin();
                    return;
                }
            }
        }
    }
    
    //Qullen:https://www.youtube.com/watch?v=HInkDgCaf1w
}


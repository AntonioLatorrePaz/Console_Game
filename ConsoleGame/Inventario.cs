using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Inventario
    {
      public  List<SlotDoInventario> slots = new List<SlotDoInventario>(); // lista de slots

        public int GetItemIndex(Item item)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].item.GetType() == item.GetType()) //
                {
                    return i;
                }

            }
            return -1;

        }

        public void AdicionarItem(Item item)
        {
            int index = GetItemIndex(item);
            if (index >= 0)
            {
                SlotDoInventario inventario = slots[index];
                inventario.quantidade += 1;
            }

            else
            {
                SlotDoInventario slot = new SlotDoInventario(item,1);
                slots.Add(slot);
            }
        }

        public void RemoverItem(Item item)
        {
            int index = GetItemIndex(item);
            if (index >= 0)
            {
                SlotDoInventario slot = slots[index];
                if (slot.quantidade > 1)
                {
                    slot.quantidade -= 1;
                }
                else
                {
                    slots.Remove(slot);
                }
            }

        }
    }
    public class SlotDoInventario
    {
        public Item item;
        public int quantidade;
        public SlotDoInventario(Item item_, int quantidade_)
        {
            item = item_;
            quantidade = quantidade_;
        }
    }
}


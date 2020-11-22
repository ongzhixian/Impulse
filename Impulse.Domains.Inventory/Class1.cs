using System.Collections.Generic;

namespace Impulse.Domains.Inventory
{
    public interface IInventory<T>
    {
        // Singular operations
        void AddItem(T item);
        void UpdateItem(T item);
        void RemoveItem(T item);

        // Bulk operations
        //void AddItems(IList<InventoryItem> items);
        //void DeleteItems(IList<InventoryItem> items);
        //void UpdateItems(IList<InventoryItem> items);

    }

    public class Inventory<T> : IInventory<T>
    {
        public void AddItem(T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItem(T item)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateItem(T item)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SimpleInventoryItem
    {
        public long Id { get; set; }
    }
}

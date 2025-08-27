using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp
{
    public class ItemService
    {
        public List<Item> Items { get; set; }
        int itemId=0;
        public ItemService()
        {
            Items = new List<Item>();
        }
        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            var addNewItemMenu = actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("\nPlease select items assortment to Add, TypeId: 1-3 ");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }
            var operation = Console.ReadKey();
            return operation;
        }
        public int AddNewItem(char itemType)
        {
            Console.WriteLine();
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item item = new Item();
            item.Id = itemId++;
            item.TypeId = itemTypeId;
            Console.WriteLine();
            Console.WriteLine("Please enter serial number for new item:");
            var sn = Console.ReadLine();
            int itemSn;
            Int32.TryParse(sn, out itemSn);
            Console.WriteLine("Please enter name for new item:");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter price for new item:");
            var price = Console.ReadLine();
            int priceId;
            Int32.TryParse(price, out priceId);  
            item.Id = itemId;
            item.Sn = itemSn;
            item.Name = name;
            item.Price = priceId;
            Items.Add(item);
            return itemSn;
        }
        public int RemoveItemView()
        {
            Console.WriteLine("Please enter type serial number for item you want to remove:");
            var itemId = Console.ReadLine();
            int sn;
            Int32.TryParse(itemId.ToString(), out sn);
            return sn;
        }
        public void RemoveItem(int removeSn)
        {
            Item productToRemove = new Item();
            foreach (var item in Items)
            {
                if (item.Sn == removeSn)
                {
                    productToRemove = item;
                    break;
                }
            }
            Items.Remove(productToRemove);
        }
        public void ItemsByTypeIdView(int typeId)
        {
            List<Item> toShow = new List<Item>();
            foreach(var item in Items)
            {
                if (item.TypeId==typeId)
                {
                    toShow.Add(item);
                }
            }
            Console.WriteLine();
            Console.WriteLine(toShow.ToStringTable(new[] {"Id","TypeId","Serial Number", "Name","Price"}, a => a.Id,a => a.TypeId, a =>a.Sn, a=>a.Name, a=>a.Price));       
            }
        public void ItemsAllView()
        {
            List<Item> toShow = new List<Item>();
            foreach (var item in Items)
            {
                toShow.Add(item);
            }
            Console.WriteLine();
            Console.WriteLine(toShow.ToStringTable(new[] { "Id", "TypeId", "Serial Number", "Name", "Price" }, a => a.Id, a => a.TypeId, a => a.Sn, a => a.Name, a => a.Price));
        }

        public int ItemTypeSelectionView()
        {
            Console.WriteLine("Please enter number of asortments: /1 - AGD , /2 - RTV , /3 - Laptops to show details items:" );
            var itemId = Console.ReadLine();
            int sn;
            Int32.TryParse(itemId.ToString(), out sn);

            return sn;
        }
        public void ItemDetailViewbySn(int detailSn)
        {
            Item productToShow = new Item();
            foreach (var item in Items)
            {
                if (item.Sn == detailSn)
                {
                    productToShow = item;
                    break;
                }
            }
            Console.WriteLine($"Item ID: {productToShow.Id}");
            Console.WriteLine($"Item Serial Number: {productToShow.Sn}");
            Console.WriteLine($"Item Name: {productToShow.Name}");
            Console.WriteLine($"Item Price: {productToShow.Price}");
            Console.WriteLine($"Item TypeId 1-3: {productToShow.TypeId}");
        }

        public void ItemDetailViewbyId(int detailId)
        {
            Item productToShow = new Item();
            foreach (var item in Items)
            {
                if (item.Id == detailId)
                {
                    productToShow = item;
                    break;
                }
            }
            Console.WriteLine($"Item ID: {productToShow.Id}");
            Console.WriteLine($"Item Serial Number: {productToShow.Sn}");
            Console.WriteLine($"Item Name: {productToShow.Name}");
            Console.WriteLine($"Item Price: {productToShow.Price}");
            Console.WriteLine($"Item TypeId 1-3: {productToShow.TypeId}");
        }
        public int ItemDetailSelecionViewbySn()
        {
            Console.WriteLine("Please enter serial number item for item details you want to show:");
            var itemSn = Console.ReadLine();
            int sn;
            Int32.TryParse(itemSn.ToString(), out sn); 
            return sn;
        }
        public int ItemDetailSelecionViewbyId()
        {
            Console.WriteLine("Please enter serial number item for item details you want to show:");
            var itemId = Console.ReadLine();
            int id;
            Int32.TryParse(itemId.ToString(), out id); 
            return id;
        }
        public int ItemDetailSelecionViewbyIgd()
        {
            Console.WriteLine("Please enter serial number item for item details you want to show:");
            var itemId = Console.ReadLine();
            int id;
            Int32.TryParse(itemId.ToString(), out id);
            return id;
        }
    }
}

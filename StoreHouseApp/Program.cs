using ProjectApp;
using System;

namespace AppExercise
{
    class Program
    {
        public const string FILE_NAME = @"D:\ImportFile";
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            ItemService itemService = new ItemService();
            actionService = Initialize(actionService);
            Console.WriteLine("============================================");
            Console.WriteLine("Welcome to AGD>>>RTV>>>Electronics StoreApp!");
            Console.WriteLine("============================================");
            string input;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please let me now what you want to do:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id} {mainMenu[i].Name}");
                }
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var keyInfo = itemService.AddNewItemView(actionService);
                        var id = itemService.AddNewItem(keyInfo.KeyChar); 
                        break;
                    case "2":
                        var removeId = itemService.RemoveItemView();
                        itemService.RemoveItem(removeId);
                        break;
                    case "3":
                        var detailSn = itemService.ItemDetailSelecionViewbySn();
                        itemService.ItemDetailViewbySn(detailSn);
                        break;
                    case "4":
                        var detailId = itemService.ItemDetailSelecionViewbyId();
                        itemService.ItemDetailViewbyId(detailId);
                        break;
                    case "5":
                        var typeId = itemService.ItemTypeSelectionView();
                        itemService.ItemsByTypeIdView(typeId);
                        break;
                    case "6":
                        itemService.ItemsAllView();
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
        }
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add item", "Main");
            actionService.AddNewAction(2, "Remove item by Serial Number", "Main");
            actionService.AddNewAction(3, "Show details by Serial Number", "Main");
            actionService.AddNewAction(4, "Show details by ID", "Main");
            actionService.AddNewAction(5, "Show list, to show all items by TypeId press /1-AGD, /2-RTV, /3-Electronics", "Main");        
            actionService.AddNewAction(6, "Show all items", "Main");

            actionService.AddNewAction(1, "AGD", "AddNewItemMenu");
            actionService.AddNewAction(2, "RTV", "AddNewItemMenu");
            actionService.AddNewAction(3, "Electronics", "AddNewItemMenu");
            return actionService;
        }
    }
}


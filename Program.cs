public class Program
{
    static List<TodoList> myLists = new List<TodoList>();
    static void Main(string[] args)
    {
        bool NotQuit = true;
        while (NotQuit)
        {
            Console.WriteLine("1-Display All Lists");
            Console.WriteLine("2-Show Items");
            Console.WriteLine("3-Create new List");
            Console.WriteLine("4-Select list");
            Console.WriteLine("5-Quit");
            Console.Write("Enter a number to chose from the menu: ");
            int chosenMenu = Convert.ToInt16(Console.ReadLine());
            switch (chosenMenu)
            {
                case 1:
                    DisplayAllLists();
                    break;
                case 2:
                    ShowItems();
                    break;
                case 3:
                    CreateNewList();
                    break;
                case 4:
                    SelectList();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.WriteLine("====================");
            static void DisplayAllLists()
            {
                if (myLists.Count == 0)
                {
                    Console.WriteLine("No lists found.");
                }
                else
                {
                    Console.WriteLine("These are your list of todo list:");
                    foreach (TodoList list in myLists)
                    {
                        Console.WriteLine($"{list.id} - {list.name}");
                    }
                }
            }
            static void ShowItems()
            {
                Console.WriteLine("Enter the id of the list:");
                int id = int.Parse(Console.ReadLine());
                TodoList list = myLists.Find(l => l.id == id);
                if (list == null)
                {
                    Console.WriteLine("Invalid id");
                }
                else
                {
                    if (list.todoItems.Count == 0)
                    {
                        Console.WriteLine($"No items found for list {list.name}");
                    }
                    else
                    {
                        foreach (TodoItem item in list.todoItems)
                        {
                            Console.WriteLine($"{item.id} - {item.content} - {item.status}");
                        }
                    }
                }
            }
            static void CreateNewList()
            {
                Console.Write("Enter the name of the new list: ");
                string name = Console.ReadLine();
                int id;
                if (myLists.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = myLists[myLists.Count - 1].id + 1;
                }
                TodoList newList = new TodoList(id, name);
                myLists.Add(newList);
            }
            static void SelectList()
            {
                Console.Write("Enter the id of the list: ");
                int id = int.Parse(Console.ReadLine());
                TodoList list = myLists.Find(l => l.id == id);
                if (list == null)
                {
                    Console.WriteLine("Invalid id");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("1 - Display all Items");
                        Console.WriteLine("2 - Create New Item");
                        Console.WriteLine("3 - Delete Item");
                        Console.WriteLine("4 - Update Item");
                        Console.WriteLine("5 - Go back");
                        Console.Write("Pick an option: ");

                        int option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                DisplayItems(list);
                                break;
                            case 2:
                                CreateNewItem(list);
                                break;
                            case 3:
                                DeleteItem(list);
                                break;
                            case 4:
                                UpdateItem(list);
                                break;
                            case 5:
                                return;
                            default:
                                Console.WriteLine("Invalid input. Please try again.");
                                break;
                        }
                        Console.WriteLine("====================");
                    }
                }
                static void DisplayItems(TodoList list)
                {
                    if (list.todoItems.Count == 0)
                    {
                        Console.WriteLine($"No items found for list {list.name}");
                    }
                    else
                    {
                        foreach (TodoItem item in list.todoItems)
                        {
                            Console.WriteLine($"Item id:{item.id}  Content: {item.content} Status: {item.status}");
                        }
                    }
                }
                static void CreateNewItem(TodoList list)
                {
                    Console.Write("Enter the content for the new item: ");
                    string content = Console.ReadLine();
                    int id;
                    if (list.todoItems.Count == 0)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = list.todoItems[list.todoItems.Count - 1].id + 1;
                    }
                    TodoItem newItem = new TodoItem(id, content);
                    list.todoItems.Add(newItem);
                    Console.WriteLine($"You have added {newItem.content} to the list...");
                
                }

                static void DeleteItem(TodoList list)
                {
                    Console.Write("Enter the id of the item to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    TodoItem item = list.todoItems.Find(i => i.id == id);
                    if (item == null)
                    {
                        Console.WriteLine("Invalid id");
                    }
                    else
                    {
                        list.todoItems.Remove(item);
                        foreach (TodoItem i in list.todoItems)
                        {
                            Console.WriteLine($"New list is: Item id:{i.id}  Content: {i.content} Status: {i.status}");
                        }
                    }
                }

                static void UpdateItem(TodoList list)
                {
                    Console.Write("Enter the id of the item to update: ");
                    int id = int.Parse(Console.ReadLine());
                    TodoItem item = list.todoItems.Find(i => i.id == id);
                    if (item == null)
                    {
                        Console.WriteLine("Invalid id");
                    }
                    else
                    {
                        item.update(item.status);
                    }
                }
            }
        }

    }
}
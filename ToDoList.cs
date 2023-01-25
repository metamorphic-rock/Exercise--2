public class TodoList{
    public int id{private set; get;}
    public string name{set; get;}
    public List<TodoItem> todoItems{get; set;}
    public TodoList(int id, string name)
    {
        this.id=id;
        this.name=name;
        this.todoItems=new List<TodoItem>();
    }
    public void AddToDoItem(TodoItem toDoItem){
        this.todoItems.Add(toDoItem);
    }
    public void RemoveToDoItem(int id){
        if(todoItems.Count==0){
            Console.WriteLine("There is no item to remove");
        }
        TodoItem itemToRemove=todoItems.Find(i=>i.id==id);
        todoItems.Remove(itemToRemove);
    }
}
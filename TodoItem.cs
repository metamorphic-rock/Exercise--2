public class TodoItem
{
    public int id{private set; get;}
    public string content{private set; get;}
    public string status{private set; get;}
    public TodoItem(int id, string content){
        this.id=id;
        this.content=content;
        this.status="pending";
    }
    public bool update(string status){
        if(this.status=="pending"){
            this.status="active";
            return true;
        }else if(this.status=="active"){
            this.status="done";
            return true;
        }else if(this.status=="done"){
            return false;
        }
        return false;
    }

}
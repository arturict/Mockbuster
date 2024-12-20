namespace Mockbuster;
class user
{
    
    private string name;
    private List<item> borrowedItems;
    public user(string name)
    {
        this.name = name;
    }
    public void BorrowItem(item item)
    {
        borrowedItems.Add(item);
    }
    public void ReturnItem(item item)
    {
        borrowedItems.Remove(item);
    }
    
}
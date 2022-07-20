namespace ConsoleCircularTest.Model;

public class Invoice
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }



    //All navigations as virtual! get; protected set; ( for the eager loading )
    public virtual Customer Customer { get; protected set; }

    protected Invoice() { }

    public Invoice(Customer customer, string name)
    {
        Customer = customer; 
        Name = name; 
    }




    // -> do this for all other navigations properties as well  
    //  All navigations as virtual! get; protected set; ( for the eager loading )
    private List<WorkAchievement> _achievements = new();
    public virtual IEnumerable<WorkAchievement> Achievements => _achievements.AsReadOnly();


    public void AddAchievements(List<WorkAchievement> addAchievements)
    {      
        //Customer must be set if achtievement we are trying to set is not yet set. 
        addAchievements.ForEach(x => x.SetCustomer(this.Customer));
        _achievements.AddRange(addAchievements);
    }
    public void RemoveAchievements(List<WorkAchievement> removeAchievements)
    {
        removeAchievements.ForEach(achievement => _achievements.Remove(achievement));
    }
}
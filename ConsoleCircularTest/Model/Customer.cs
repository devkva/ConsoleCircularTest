using System.ComponentModel.DataAnnotations;

namespace ConsoleCircularTest.Model;

public class Customer
{
     
    public Guid Id { get; protected set; }
    public string name { get; protected set; }


    protected Customer() { }
    public Customer(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        name = firstName + " " + lastName;
    }


    // -> do this for all other navigations properties as well  
    //  All navigations as virtual! get; protected set; ( for the eager loading )
    private List<Invoice> _invoices = new();
    public virtual IEnumerable<Invoice> Invoices => _invoices.AsReadOnly();


    // -> do this for all other navigations properties as well  
    //  All navigations as virtual! get; protected set; ( for the eager loading )
    private List<WorkAchievement> _achievements = new();
    public virtual IEnumerable<WorkAchievement> Achievements => _achievements.AsReadOnly();


    public void AddInvoice(Invoice invoice)
    {
        _invoices.Add(invoice);
    }
    public void RemoveInvoice(Invoice invoice)
    {
        _invoices.Remove(invoice);
    }


    public void AddAchievements(List<WorkAchievement> addAchievements)
    {        
        _achievements.AddRange(addAchievements);
    }
    public void RemoveAchievements(List<WorkAchievement> removeAchievements)
    {       
        removeAchievements.ForEach(achievement => _achievements.Remove(achievement));
    }

}
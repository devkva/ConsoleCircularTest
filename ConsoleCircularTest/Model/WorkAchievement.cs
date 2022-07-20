using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCircularTest.Model;

public class WorkAchievement
{

    public int Id { get; protected set; }
    public string Name { get; protected set; }


    //All navigations as virtual! get; protected set; ( for the eager loading )
    public virtual Customer Customer { get; protected set; }
    public WorkAchievement(string name) {
        Name = name;
    }

    internal void SetCustomer(Customer customer)
    {
        Customer = customer;             
    }


}
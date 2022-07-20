// See https://aka.ms/new-console-template for more information
using ConsoleCircularTest;
using ConsoleCircularTest.Model;
using Microsoft.EntityFrameworkCore;

CirculareDb db = new CirculareDb();

db.Database.EnsureDeleted();
db.Database.EnsureCreated();


var cust1 = new Customer("koen", "vanneste");
var cust2 = new Customer("bart", "vanneste");


for (int i = 0; i < 5; i++)
{
    cust1.AddAchievements(new List<WorkAchievement>() { new WorkAchievement($"WorkItem{i}") });
    cust2.AddAchievements(new List<WorkAchievement>() { new WorkAchievement($"WorkItem{10+i}") });
   
}



for (int i = 0; i < 2; i++)
{
    var invoice = new Invoice(cust1, $"Invoice{i}"); 

    for (int j = 0; j < 3; j++)
    {
        var workhour = new WorkAchievement($"WorkItemInInvoice{i}");
        invoice.AddAchievements(new List<WorkAchievement>() { workhour });       
    }
    cust1.AddInvoice(invoice);
}


db.Customers.Add(cust1);
db.Customers.Add(cust2);

db.SaveChanges();





Console.WriteLine("Pres Enter to remove first work hour out first invoice ");
Console.ReadLine();

CirculareDb db1 = new CirculareDb();
var firstInvoice = db1.Invoices.FirstOrDefault();
var firstachievement = firstInvoice.Achievements.First();
firstInvoice.RemoveAchievements(new List<WorkAchievement>() { firstachievement });
db1.SaveChanges();



Console.WriteLine("Pres Enter to remove first invoice ");
Console.ReadLine();

//integratie testen hierop zullen niet gaan.. 
CirculareDb db2 = new CirculareDb();
var firstInvoice1 = db2.Invoices.FirstOrDefault();
db2.Invoices.Remove(firstInvoice1);
db2.SaveChanges();




Console.WriteLine("Press Enter to remove first achievement in list   ");
Console.ReadLine();
CirculareDb db4 = new CirculareDb();
var ach = db4.workAchievements.FirstOrDefault();


db4.workAchievements.Remove(ach);
db4.SaveChanges();



Console.WriteLine("Press Enter to removme first customer   ");
Console.ReadLine();


CirculareDb db3 = new CirculareDb();
var customer = db3.Customers.FirstOrDefault();
db3.Customers.Remove(customer);
db3.SaveChanges();

Console.WriteLine("Press Enter to removme Second customer   ");
Console.ReadLine();

customer = db3.Customers.FirstOrDefault();
db3.Customers.Remove(customer);
db3.SaveChanges();



Console.WriteLine("the end");
Console.ReadLine(); 
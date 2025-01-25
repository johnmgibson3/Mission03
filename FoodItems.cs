namespace Mission03;
using System;

public class FoodItems
{ 
    public string Name { get; set; }
    public string Category { get; set; }
    public string Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    public FoodItems(string name, string category, string quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    public override string ToString()
    {
        return $"Nadme: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate}";
    }
        
        
}
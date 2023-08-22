// See https://aka.ms/new-console-template for more information

using ObserverPatternExample;

var lisa = new PersonalData("Lisa")
{
    BillingAddress = new BillingAddress
    {
        Street = "742 Evergreen Terrace",
        City = "Springfield",
        State = "Oregon",
        Zip = "97403"
    },
    PhoneNumber = "(555)555-5555"
};

var visaCard = new CreditCard("Visa", lisa);
var discoverCard = new CreditCard("Discover", lisa);
var water = new Utility("Water", lisa);
var electric = new Utility("Electric", lisa);

Console.WriteLine();
Console.WriteLine($"Press any key to update {lisa.Name}'s address...");
Console.ReadKey(); 
Console.WriteLine();

var newBillingAddress = new BillingAddress
{
    Street = "1600 Pennsylvania Ave.",
    City = "Washington",
    State = "DC",
    Zip = "20500"
};

lisa.BillingAddress = newBillingAddress;

Console.WriteLine();
Console.WriteLine($"Press any key to update {lisa.Name}'s phone number...");
Console.ReadKey(); 
Console.WriteLine();

lisa.PhoneNumber = "(555)555-1234";

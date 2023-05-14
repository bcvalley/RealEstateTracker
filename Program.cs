using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

class Program
{
    static List<Building> builds = new List<Building>();
    static List<Manager> managers = new List<Manager>();

    static void Main(string[] args)
    {   
        //saves to txt
       // SaveBuildings();
        // SaveManagers();
        Menu();

        // AddProperty(builds);
       
        // TotalProfits(builds,managers);
    }

    static void LoadBuildings()
    {
        var lines = File.ReadAllLines("Props.txt");
        
        foreach (string s in lines)
        {
            var arr = s.Split(' ');
            builds.Add(new Building(int.Parse(arr[0]), arr[1], int.Parse(arr[2]), decimal.Parse(arr[3]), arr[4]));
        }
    }

    static void LoadManagers()
    {
        var manLines = File.ReadAllLines("Mans.txt");
        
        foreach (string s in manLines)
        {
            var arr = s.Split(' ');
            managers.Add(new Manager(arr[0], int.Parse(arr[1]), int.Parse(arr[2]), decimal.Parse(arr[3])));
        }
    }

    static void SaveBuildings()
    {
        using (var props = new StreamWriter("Props.txt"))
        {
            foreach (Building b in builds)
            {
                props.WriteLine($"{b.Price} {b.Type} {b.Rooms} {b.Cashflow} {b.Location}");
            }
        }
    }

    static void SaveManagers()
    {
        using (var mans = new StreamWriter("Mans.txt"))
        {
            foreach (Manager b in managers)
            {
                mans.WriteLine($"{b.Name} {b.Years} {b.Experience} {b.Salary}");
            }
        }
    }

    static void DisplayManagers()
    {
        System.Console.WriteLine("{0,-10}  {1,-10}  {2,-10}  {3,-10}","Name","Years","Experience","Salary");
        System.Console.WriteLine();
        foreach (Manager item in managers)
        {
            System.Console.WriteLine($"{item.Name,-10} {item.Years,-10} {item.Experience,-10} {item.Salary,-10}");
        }
        System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
    static void DisplayBuildings(List<Building> buildings)
    {
    Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4}", "Price", "Type", "Rooms", "Cashflow", "Location");
    System.Console.WriteLine();
    foreach (Building b in buildings)
    {
        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4}", b.Price, b.Type, b.Rooms, b.Cashflow, b.Location);
    }
    }
    static void TotalProfits(List<Building> building,List<Manager> managers){
        
        decimal Expenses = 0;
        decimal Cashflow = 0;
        decimal Networth = 0;
        
        foreach (Building item in building)
        {
            Networth += item.Price;
            Cashflow += item.Cashflow;


        }
        foreach (Manager item in managers)
        {
            Expenses += item.Salary;
        }
        Console.WriteLine($"Total Cashflow Per Month --> {Cashflow}");
        Console.WriteLine($"Total Expences Per Month --> {Expenses}");
        Console.WriteLine($"Total Networth Of Properties --> {Networth}");
        Console.WriteLine($"Total Profit Per Month --> {Cashflow-Expenses}");
        
        
    }

    static void AddProperty(List<Building> build){
        Console.WriteLine($"Please separate every field with a whitespace!");
        
        Console.WriteLine($"Price Type Rooms Cashflow Location");
        
            string input = Console.ReadLine();
            if(input == string.Empty){
                System.Console.WriteLine("This field cannot be empty!");
                AddProperty(build);
            }

            string[] arr = input.Split(' ');
            build.Add(new Building(int.Parse(arr[0]),arr[1],int.Parse(arr[2]),decimal.Parse(arr[3]),arr[4]));
        
        
    }
    static void Menu()
{
    Console.WriteLine("Choose from the options below:");
    Console.WriteLine("1. List all.");
    Console.WriteLine("2. Add new property.");
    Console.WriteLine("3. Add new Manager.");
    Console.WriteLine("4. Exit.");

    int choice = int.Parse(Console.ReadLine());
    if (choice == 1)
    {
        builds.Clear(); // Clear the builds list
        managers.Clear(); // Clear the managers list

        LoadBuildings();
        LoadManagers();
        DisplayManagers();
        DisplayBuildings(builds);
        TotalProfits(builds, managers);
        Menu();
    }
    else if (choice == 2)
    {
        AddProperty(builds);
        SaveBuildings();
        Console.WriteLine("Done!");
        Menu();
    }
    else if (choice == 3)
    {
        AddManager(managers);
        SaveManagers();
        Console.WriteLine("Done!");
        Menu();
    }
    else if (choice == 4 ){
        
        
        Environment.Exit(0);
        
        
    }
}

    static void AddManager(List<Manager> man){
        Console.WriteLine($"Please separate every field with a whitespace!");
        
        Console.WriteLine($"Name; Years; Experience; Salary;");
        
            string input = Console.ReadLine();
            if(input == string.Empty){
                System.Console.WriteLine("This field cannot be empty!");
                AddManager(man);
            }

            string[] arr = input.Split(' ');
            man.Add(new Manager(arr[0],int.Parse(arr[1]),int.Parse(arr[2]),decimal.Parse(arr[3])));
    }
}

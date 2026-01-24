using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Задание 1
        var objects = new List<ObjectInfo>
        {
            new ObjectInfo("Containment Cell A", 4),
            new ObjectInfo("Archive Vault", 1),
            new ObjectInfo("Bio Lab Sector", 3),
            new ObjectInfo("Observation Wing", 2)
        };

        var sortedObjects = objects.OrderBy(o => o.ThreatLevel).ToList();
        Console.WriteLine("Задание 1:");
        foreach (var obj in sortedObjects)
            Console.WriteLine($"{obj.Name} - уровень угрозы {obj.ThreatLevel}");


        // Задание 2
        var staff = new List<StaffMember>
        {
            new StaffMember("Dr. Shaw", 120, 15),
            new StaffMember("Agent Torres", 90, 22),
            new StaffMember("Researcher Hall", 150, 10)
        };

        var totalCosts = staff.Select(s => s.ShiftCost * s.Shifts).ToList();
        int maxCost = totalCosts.Max();

        Console.WriteLine("\nЗадание 2:");
        foreach (var cost in totalCosts)
            Console.WriteLine(cost);
        Console.WriteLine("Максимальная стоимость: " + maxCost);


        // Задание 3
        var personnel = new List<Person>
        {
            new Person("Dr. Klein", 2),
            new Person("Agent Brooks", 4),
            new Person("Technician Reed", 1)
        };

        var categorizedPersonnel = personnel.Select(p =>
            new PersonWithCategory(
                p.Name,
                p.Clearance,
                p.Clearance == 1 ? "Restricted" :
                p.Clearance <= 3 ? "Confidential" :
                "Top Secret"
            )
        ).ToList();

        Console.WriteLine("\nЗадание 3:");
        foreach (var p in categorizedPersonnel)
            Console.WriteLine($"{p.Name} - {p.Category}");


        // Задание 4
        var zones = new List<Zone>
        {
            new Zone("Sector-12", 8, 18),
            new Zone("Deep Storage", 0, 24),
            new Zone("Research Wing", 9, 17)
        };

        var dayZones = zones.Where(z => z.ActiveFrom <= 8 && z.ActiveTo >= 18).ToList();

        Console.WriteLine("\nЗадание 4:");
        foreach (var z in dayZones)
            Console.WriteLine(z.Name);


        // Задание 5
        var reports = new List<Report>
        {
            new Report("Dr. Moss", "Analysis completed. Reference: http://external-archive.net"),
            new Report("Agent Lee", "Incident resolved without escalation."),
            new Report("Dr. Patel", "Supplementary data available at https://secure-research.org"),
            new Report("Supervisor Kane", "No anomalies detected during inspection."),
            new Report("Researcher Bloom", "Extended observations uploaded to http://research-notes.lab")
        };

        var cleanedReports = reports
            .Where(r => r.Text.Contains("http://") || r.Text.Contains("https://"))
            .Select(r => new Report(r.Author, "[ДАННЫЕ УДАЛЕНЫ]"))
            .ToList();

        Console.WriteLine("\nЗадание 5:");
        foreach (var r in cleanedReports)
            Console.WriteLine($"{r.Author}: {r.Text}");


        // Задание 6
        var scpObjects = new List<SCPObject>
        {
            new SCPObject("SCP-096", "Euclid"),
            new SCPObject("SCP-173", "Euclid"),
            new SCPObject("SCP-055", "Keter"),
            new SCPObject("SCP-999", "Safe"),
            new SCPObject("SCP-3001", "Keter")
        };

        var dangerousScp = scpObjects.Where(s => s.Class != "Safe").ToList();

        Console.WriteLine("\nЗадание 6:");
        foreach (var s in dangerousScp)
            Console.WriteLine(s.Code);


        // Задание 7
        var incidents = new List<Incident>
        {
            new Incident(101, 4),
            new Incident(102, 12),
            new Incident(103, 7),
            new Incident(104, 20)
        };

        var topIncidents = incidents
            .OrderByDescending(i => i.StaffCount)
            .Take(3)
            .ToList();

        Console.WriteLine("\nЗадание 7:");
        foreach (var i in topIncidents)
            Console.WriteLine($"ID: {i.Id}, персонал: {i.StaffCount}");


        // Задание 8
        var protocols = new List<Protocol>
        {
            new Protocol("Lockdown", 5),
            new Protocol("Evacuation", 4),
            new Protocol("Data Wipe", 3),
            new Protocol("Routine Scan", 1)
        };

        var formattedProtocols = protocols
            .Select(p => $"Protocol {p.Name} - Criticality {p.Level}")
            .ToList();

        Console.WriteLine("\nЗадание 8:");
        foreach (var p in formattedProtocols)
            Console.WriteLine(p);


        // Задание 9
        var shifts = new List<int> { 6, 12, 8, 24, 10, 4 };

        var validShifts = shifts.Where(s => s >= 8 && s <= 12).ToList();

        Console.WriteLine("\nЗадание 9:");
        foreach (var s in validShifts)
            Console.WriteLine(s);


        // Задание 10
        var evaluations = new List<Evaluation>
        {
            new Evaluation("Agent Cole", 78),
            new Evaluation("Dr. Weiss", 92),
            new Evaluation("Technician Moore", 61),
            new Evaluation("Researcher Lin", 88)
        };

        var bestEmployee = evaluations.OrderByDescending(e => e.Score).First();

        Console.WriteLine("\nЗадание 10:");
        Console.WriteLine($"{bestEmployee.Name} - {bestEmployee.Score}");
    }
}


// ===== Классы =====

class ObjectInfo
{
    public string Name;
    public int ThreatLevel;

    public ObjectInfo(string name, int threatLevel)
    {
        Name = name;
        ThreatLevel = threatLevel;
    }
}

class StaffMember
{
    public string Name;
    public int ShiftCost;
    public int Shifts;

    public StaffMember(string name, int shiftCost, int shifts)
    {
        Name = name;
        ShiftCost = shiftCost;
        Shifts = shifts;
    }
}

class Person
{
    public string Name;
    public int Clearance;

    public Person(string name, int clearance)
    {
        Name = name;
        Clearance = clearance;
    }
}

class PersonWithCategory : Person
{
    public string Category;

    public PersonWithCategory(string name, int clearance, string category)
        : base(name, clearance)
    {
        Category = category;
    }
}

class Zone
{
    public string Name;
    public int ActiveFrom;
    public int ActiveTo;

    public Zone(string name, int from, int to)
    {
        Name = name;
        ActiveFrom = from;
        ActiveTo = to;
    }
}

class Report
{
    public string Author;
    public string Text;

    public Report(string author, string text)
    {
        Author = author;
        Text = text;
    }
}

class SCPObject
{
    public string Code;
    public string Class;

    public SCPObject(string code, string @class)
    {
        Code = code;
        Class = @class;
    }
}

class Incident
{
    public int Id;
    public int StaffCount;

    public Incident(int id, int staff)
    {
        Id = id;
        StaffCount = staff;
    }
}

class Protocol
{
    public string Name;
    public int Level;

    public Protocol(string name, int level)
    {
        Name = name;
        Level = level;
    }
}

class Evaluation
{
    public string Name;
    public int Score;

    public Evaluation(string name, int score)
    {
        Name = name;
        Score = score;
    }
}

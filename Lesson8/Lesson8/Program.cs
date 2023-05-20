// See https://aka.ms/new-console-template for more information




// 2. Show all meeting
// 1. Add meeting - without validation
// 0. Exit calendar

using System.Linq;
using System.Text;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

// meeting start time, duration, room, name

const string FileName = "meetings.txt";
const int MaximumRoomLenght = 25;
const int MaximumNameLenght = 50;


void Delete()
{
    
    // var fileContent2 = File.ReadAllLines(FileName);
    Console.WriteLine("Дата которую нужно удалить");
    string s = Console.ReadLine();
    string[] lines = File.ReadAllLines(FileName);
    

    File.WriteAllLines(FileName, lines.Skip(1));
    for (int i = 0; i < lines.Length; i++)
    {
        if (lines[i] == s) lines[i] = " ";
        break;
    }
    Console.WriteLine();
  



}

void ShowAll()
{
    Console.WriteLine($"{"Start time",20}"
        + $"{"Duration",20}"
        + $"{"Room",20}" +
        $"{"Name",20}");

    var fileContent = File.ReadAllLines(FileName);

    foreach (var line in fileContent)
    {
        var meetingContent = line.Split(",");

        Console.WriteLine($"{meetingContent[0],20}" +
              $"{meetingContent[1],20}" +
              $"{meetingContent[2],20}" +
              $"{meetingContent[3],20}");
    }

    //Console.WriteLine("Press any key to return to menu...");
    Console.ReadLine();
}

void ShowError(string error)
{
    Console.WriteLine(error);
    Console.ReadLine();
}

void AddMeeting() // meeting start time, duration, room, name
{
    Console.WriteLine("Start date:");
    var dateParsingResult = DateTime.TryParse(Console.ReadLine(), out var startTime);
    if (!dateParsingResult)
    {
        ShowError("Error! Invalid Start date");
        return;
    }
    
    

    Console.WriteLine("Duration in minutes: ");
    var durationParsingResult = int.TryParse(Console.ReadLine(), out var duration);
    string s1 = duration.ToString();
    string[] lines = File.ReadAllLines(FileName);
    
    if (!durationParsingResult)
    {
        ShowError("Error! Invalid meeting duration");
        return;
    }

    if (lines[0] == s1)
    {
        ShowError("Error!this time is already taken!");
        return;
    }
    

    //var a2 = File.ReadAllLines(FileName);
    // var b = duration;
    //  if (a = b)
    // {
    //      throw new ArgumentException("Invalid name");
    //  }

    Console.WriteLine("Room: ");
    var room = Console.ReadLine();
    if (string.IsNullOrEmpty(room))
    {
        ShowError("Error! Empty room");
        return;
    }

    if (room.Length > MaximumRoomLenght)
    {
        ShowError($"Error! Room should not be longer than {MaximumRoomLenght} symbols");
        return;
    }

    Console.WriteLine("Name: ");
    var name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        ShowError("Error! Empty name");
        return;
    }

    if (name.Length > MaximumNameLenght)
    {
        ShowError($"Error! Room should not be longer than {MaximumNameLenght} symbols");
        return;
    }

    File.AppendAllText(FileName, $"{startTime},{duration},{room},{name}" + Environment.NewLine);
}

void Exit()
{
    Environment.Exit(0);
}



void Menu()
{
    Console.Clear();
    Console.WriteLine("3. Show all meetings");
    Console.WriteLine("2. Add meeting");
    Console.WriteLine("1. Exit calendar");
    Console.WriteLine("0. Delete time");
}

while (true)
{
    Menu();
    var keyInfo = Console.ReadKey();
    switch (keyInfo.Key)
    {
        case ConsoleKey.D1:
            Exit();
            break;
        case ConsoleKey.D2:
            AddMeeting();
            break;
        case ConsoleKey.D3:
            ShowAll();
            break;
        case ConsoleKey.D0:
            Delete();
            break;
        default: break;
    }
}

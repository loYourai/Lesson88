// See https://aka.ms/new-console-template for more information




// 2. Show all meeting
// 1. Add meeting - without validation
// 0. Exit calendar

using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

// meeting start time, duration, room, name

const string FileName = "meetings.txt";
const int MaximumRoomLenght = 25;
const int MaximumNameLenght = 50;


    void ShowAll2()
    {
        
       List<String> temp = new List<String>();

    if (s.IndexOf(Console.ReadLine()) != -1)
    {
        StreamWriter file = new System.IO.StreamWriter("D:\\Beetroot\\Lesson88\\Lesson8\\Lesson8\\bin\\Debug\\net6.0");
        temp.ForEach(file.WriteLine);
        file.Close();
    }

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
              $"{meetingContent[3],20}" +
              $"{meetingContent[4],20}");
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
    if (!durationParsingResult)
    {
        ShowError("Error! Invalid meeting duration");
        return;
    }

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
            ShowAll2();
            break;
        default: break;
    }
}


using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello! This application will calculate the average gold per minute you've collected!");

	    // Read the input from the console
        Console.Write("Enter the amount of gold you have: ");
        int gold = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of hours you've played: ");
        float hours = float.Parse(Console.ReadLine());

        // Calculate the minutes and gold/minute
        float minutes = hours * 60;
        float goldPerMinute = gold / minutes;

        // Print the output
        Console.WriteLine("Gold: " + gold);
        Console.WriteLine("Hours played: " + hours);
        Console.WriteLine("Gold per minute: " + goldPerMinute);
    }
}

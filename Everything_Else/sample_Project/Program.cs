﻿namespace sample_Project;

class Program
{
    static void Main(string[] args) {
Console.WriteLine("What is your name?");
var name = Console.ReadLine();
var currentDate = DateTime.Now;
Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
Console.Write($"{Environment.NewLine}Press Enter to exit...");
Console.Read();
}
}
// See https://aka.ms/new-console-template for more information

using System;
using EventPatternStudy;

void OnNewNumber(object sender, NewNumberEventArgs args)
{
    Console.WriteLine($"{args.TimeStamp}: {args.EventNumber}. event occured");
    if (args.EventNumber % 5 == 0) args.Cancel = true;
}

EventProvider eventProvider = new();
eventProvider.NewNumber += OnNewNumber;
eventProvider.Start();

Console.ReadKey();
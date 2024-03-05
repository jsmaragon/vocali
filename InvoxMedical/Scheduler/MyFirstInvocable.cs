using Coravel.Invocable;
using System;
using System.Threading.Tasks;

public class MyFirstInvocable : IInvocable
{
    public Task Invoke()
    {
        Console.WriteLine("This is my first invocable!");
        return Task.CompletedTask;
    }
}

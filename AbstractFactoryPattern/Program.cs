using AbstractFactoryPattern.Enums;
using AbstractFactoryPattern.Factories;
using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Models.Windows;

namespace AbstractFactoryPattern;
public static class Program
{
    public static void Main()
    {
        var selectedOS = new Random().Next(0, 2) == 0 ? OS.Windows : OS.Mac;

        NaiveSolution(selectedOS);
        AFSolution(selectedOS);
    }

    public static bool IsWindows(OS os)
    {
        return os == OS.Windows;
    }

    public static void NaiveSolution(OS selectedOS)
    {
        if (selectedOS == OS.Windows)
        {
            var button = new WinButton();
            Console.WriteLine(button.Render());
        }

        // Some other code location

        if (selectedOS != OS.Windows) // Forgotten refactoring == Bug
        {
            var button = new WinCheckbox();
            Console.WriteLine(button.Render());
        }
    }

    public static void AFSolution(OS selectedOS)
    {
        IGuiFactory? factory;

        // Type of factory is defined in a single location

        if (IsWindows(selectedOS))
        {
            factory = new WinFactory();
        }
        else
        {
            factory = new MacFactory();
        }

        // After that, any location needs only to call the 'factory'

        var button = factory.CreateButton();
        var checkbox = factory.CreateCheckbox();

        Console.WriteLine(button.Render());
        Console.WriteLine(checkbox.Render());
    }
}

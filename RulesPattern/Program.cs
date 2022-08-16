using RulesPattern.Models;
using RulesPattern.Rules.Engine;
using RulesPattern.UseCases;

namespace RulesPattern;
public class Program
{
    public static void Main()
    {
        var customer = new Customer(
            null,
            new DateTime(1992, 8, 14),
            false,
            new DateTime(2020, 8, 14)
        );

        var naiveDiscount = new NaiveDiscountUseCase().Action(customer);
        var predicateDiscount = new PredicatesDiscountUseCase().Action(customer);
        var predicatedExtDiscount = new PredicateExtDiscountUseCase().Action(customer);
        var rulesDiscount = new RulesDiscountUseCase().Action(customer);

        var task = DiscountEngine.Action(customer);
        task.Wait();

        var rulesDiscountWorkflow = task.Result;

        Console.WriteLine(naiveDiscount);
        Console.WriteLine(predicateDiscount);
        Console.WriteLine(predicatedExtDiscount);
        Console.WriteLine(rulesDiscount);
        Console.WriteLine(rulesDiscountWorkflow);
    }
}

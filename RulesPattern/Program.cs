using RulesPattern.Models;
using RulesPattern.UseCases;

namespace RulesPattern;
public class Program
{
    public static void Main(string []args)
    {
        var customer = new Customer(
            null,
            new DateTime(1992, 4, 11),
            false
        );

        var naiveDiscount = new NaiveDiscountUseCase().Action(customer);
        var predicateDiscount = new PredicatesDiscountUseCase().Action(customer);
        var predicatedExtDiscount = new PredicateExtDiscountUseCase().Action(customer);
        var rulesDiscount = new RulesDiscountUseCase().Action(customer);

        Console.WriteLine(naiveDiscount);
        Console.WriteLine(predicateDiscount);
        Console.WriteLine(predicatedExtDiscount);
        Console.WriteLine(rulesDiscount);
    }
}

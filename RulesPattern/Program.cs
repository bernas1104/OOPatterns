using Newtonsoft.Json;
using RulesPattern.Models;
using RulesPattern.Persistence.Rules;
using RulesPattern.UseCases;

namespace RulesPattern;
public class Program
{
    public static void Main()
    {
        var customer = new Customer(
            null,
            new DateTime(1992, 8, 15),
            true,
            new DateTime(2012, 8, 14)
        );

        var naiveDiscount = new NaiveDiscountUseCase().Action(customer);
        var predicateDiscount = new PredicatesDiscountUseCase().Action(customer);
        var predicatedExtDiscount = new PredicateExtDiscountUseCase().Action(customer);
        var rulesDiscount = new RulesDiscountUseCase().Action(customer);
        // var rulesDiscountWorkflow = RunRulesEngine(customer);

        Console.WriteLine(naiveDiscount);
        Console.WriteLine(predicateDiscount);
        Console.WriteLine(predicatedExtDiscount);
        Console.WriteLine(rulesDiscount);
        // Console.WriteLine(rulesDiscountWorkflow);
    }

    public static decimal RunRulesEngine(Customer customer)
    {
        var discountWorkflow = DiscountRule.DiscountWorkflow;
        var workflows = new List<string>() { JsonConvert.SerializeObject(discountWorkflow) };

        var rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray(), null);
        var response = rulesEngine.ExecuteAllRulesAsync(
            "Discount Workflow Rules",
            customer
        ).AsTask();

        response.Wait();

        var result = response.Result;
        var discount = 0m;
        foreach (var item in result)
        {
            if (item.IsSuccess)
            {
                discount = Math.Max(
                    discount,
                    decimal.Parse(item.Rule.SuccessEvent)
                );
            }
        }

        return discount;
    }
}

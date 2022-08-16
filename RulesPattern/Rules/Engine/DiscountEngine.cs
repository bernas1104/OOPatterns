using Newtonsoft.Json;
using RulesPattern.Models;
using RulesPattern.Persistence.Rules;

namespace RulesPattern.Rules.Engine
{
    public class DiscountEngine
    {
        public static async Task<decimal> Action(Customer customer)
        {
            var discountWorkflow = DiscountRule.DiscountWorkflow;
            var workflows = new List<string>()
            {
                JsonConvert.SerializeObject(discountWorkflow)
            };

            var rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray(), null);
            var response = await rulesEngine.ExecuteAllRulesAsync(
                "Discount Workflow Rules",
                customer
            );

            var discount = 0m;
            foreach (var item in response)
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
}

using RulesEngine.Models;

namespace RulesPattern.Persistence.Rules
{
    public static class DiscountRule
    {
        public static Workflow DiscountWorkflow => new()
        {
            WorkflowName = "Discount Workflow Rules",
            Rules = DiscountRules,
            GlobalParams = new List<ScopedParam>()
            {
                new ScopedParam
                {
                    Name = "today",
                    Expression = "DateTime.Now"
                }
            }
        };

        public static List<Rule> DiscountRules => new()
        {
            new Rule
            {
                RuleName = "BirthdayDiscountRule",
                SuccessEvent = "0,10",
                ErrorMessage = "Birthday discount rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.DateOfBirth.Day == day AND input1.DateOfBirth.Month == month",
                LocalParams = new List<ScopedParam>
                {
                    new ScopedParam
                    {
                        Name = "day",
                        Expression = "DateTime.Now.Day"
                    },
                    new ScopedParam
                    {
                        Name = "month",
                        Expression = "DateTime.Now.Month"
                    }
                }
            },
            new Rule
            {
                RuleName = "Loyal1CustomerDiscountRule",
                SuccessEvent = "0,10 + birthdayRule.CalculateCustomerDiscount(input1)",
                ErrorMessage = "Loyal1CustomerDiscountRule rule not applied",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(1, today)"
            },
            new Rule
            {
                RuleName = "Loyal5CustomerDiscountRule",
                SuccessEvent = "0,12 + birthdayRule.CalculateCustomerDiscount(input1)",
                ErrorMessage = "Loyal1CustomerDiscountRule rule not applied",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(5, today)"
            },
            new Rule
            {
                RuleName = "Loyal10CustomerDiscountRule",
                SuccessEvent = "0,15 + birthdayRule.CalculateCustomerDiscount(input1)",
                ErrorMessage = "Loyal1CustomerDiscountRule rule not applied",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(10, today)"
            },
            new Rule
            {
                RuleName = "NewCustomerDiscountRule",
                SuccessEvent = "0,15",
                ErrorMessage = "New input1 discount rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "!input1.HasPurchasedBefore()"
            },
            new Rule
            {
                RuleName = "SeniorDiscountRule",
                SuccessEvent = "0,05",
                ErrorMessage = "Senior discount rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.IsSenior(null)"
            },
            new Rule
            {
                RuleName = "VeteranDiscountRule",
                SuccessEvent = "0,10",
                ErrorMessage = "Veteran discount rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.IsVeteran"
            }
        };
    }
}

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
                Expression = "input1.IsBirthday(null)",
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
                RuleName = "LoyalOneYearDiscountNoBirthdayRule",
                SuccessEvent = "0,10",
                ErrorMessage = "LoyalOneYearDiscountRule rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(1, today) AND !input1.IsBirthday(null)",
            },
            new Rule
            {
                RuleName = "LoyalFiveYearsDiscountNoBirthdayRule",
                SuccessEvent = "0,12",
                ErrorMessage = "LoyalFiveYearsDiscountRule rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(5, today) AND !input1.IsBirthday(null)",
            },
            new Rule
            {
                RuleName = "LoyalTenYearsDiscountNoBirthdayRule",
                SuccessEvent = "0,2",
                ErrorMessage = "LoyalTenYearsDiscountRule rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(10, today) AND !input1.IsBirthday(null)",
            },
            new Rule
            {
                RuleName = "LoyalOneYearDiscountBirthdayRule",
                SuccessEvent = "0,20",
                ErrorMessage = "LoyalOneYearDiscountRule rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(1, today) AND input1.IsBirthday(null)",
            },
            new Rule
            {
                RuleName = "LoyalFiveYearsDiscountBirthdayRule",
                SuccessEvent = "0,22",
                ErrorMessage = "LoyalFiveYearsDiscountRule rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(5, today) AND input1.IsBirthday(null)",
            },
            new Rule
            {
                RuleName = "LoyalTenYearsDiscountBirthdayRule",
                SuccessEvent = "0,3",
                ErrorMessage = "LoyalTenYearsDiscountRule rule not applied.",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "input1.HasBeenLoyalForYears(10, today) AND input1.IsBirthday(null)",
            },
            new Rule
            {
                RuleName = "NewCustomerDiscountRule",
                SuccessEvent = "0,15",
                ErrorMessage = "NewCustomerDiscountRule not applied.",
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

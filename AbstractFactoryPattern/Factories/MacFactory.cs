using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Models.Mac;

namespace AbstractFactoryPattern.Factories
{
    public class MacFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }
}

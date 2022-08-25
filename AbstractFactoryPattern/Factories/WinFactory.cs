using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Models.Windows;

namespace AbstractFactoryPattern.Factories
{
    public class WinFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WinCheckbox();
        }
    }
}

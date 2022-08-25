namespace AbstractFactoryPattern.Interfaces
{
    public interface IGuiFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
}

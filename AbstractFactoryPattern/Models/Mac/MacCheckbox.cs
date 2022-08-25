using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern.Models.Mac
{
    public class MacCheckbox : ICheckbox
    {
        public string Render()
        {
            return "I am a Mac Checkbox!";
        }
    }
}

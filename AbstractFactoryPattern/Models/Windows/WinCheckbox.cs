using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern.Models.Windows
{
    public class WinCheckbox : ICheckbox
    {
        public string Render()
        {
            return "I am a Windows Checkbox!";
        }
    }
}

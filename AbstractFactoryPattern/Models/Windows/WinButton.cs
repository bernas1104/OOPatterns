using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern.Models.Windows
{
    public class WinButton : IButton
    {
        public string Render()
        {
            return "I am a Windows Button!";
        }
    }
}

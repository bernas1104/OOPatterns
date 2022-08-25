using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern.Models.Mac
{
    public class MacButton : IButton
    {
        public string Render()
        {
            return "I am a Mac Button!";
        }
    }
}

using System.ComponentModel;

namespace MyArt.Domain.Enums
{
    public enum EType
    {
        [Description("Фотография")] Photo = 1,
        [Description("Скульптура")] Sculpture,
        [Description("Картина")] Picture
    }
}

using System.ComponentModel;

namespace MyArt.Domain.Enums
{
    public enum EType
    {
        [Description("Фотография")] Photo,
        [Description("Картина")] Sculpture,
        [Description("Скульптура")] Picture
    }
}

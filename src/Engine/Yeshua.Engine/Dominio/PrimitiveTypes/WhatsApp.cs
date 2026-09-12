using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public struct WhatsApp
    {
        private readonly Celular _value;
        private WhatsApp(Celular value) => _value = value;
        public static implicit operator WhatsApp(Celular value) => new WhatsApp(value);  
        public override string ToString() => _value.ToString();
    }
}

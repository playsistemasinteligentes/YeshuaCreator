namespace Dominio
{
    public struct Celular
    {
        private readonly string _value;
        private Celular(string value) => _value = value;
        public static implicit operator Celular(string value) => new Celular(value);
        public override string ToString() => _value;

    }
}

namespace Dominio
{
    public struct Celular
    {
        private readonly string _value;
        private Celular(string value) => new Celular(value);
        public static implicit operator Celular(string value) => new Celular(value);

    }
}
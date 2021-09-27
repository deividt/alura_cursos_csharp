namespace DesignPatterns2.Cap6
{
    public interface IMensagem
    {
        public IEnviador Enviador { get; set; }
        void Envia();

        string Formata();
    }
}
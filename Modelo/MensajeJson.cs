namespace CLINICA_API.Modelo
{
    public class MensajeJson
    {
        public string mensaje { get; set; }
        public Object objeto { get; set; }
        public MensajeJson(string mensaje, Object data)
        {
            this.mensaje = mensaje;
            this.objeto = data;
        }
    }
}

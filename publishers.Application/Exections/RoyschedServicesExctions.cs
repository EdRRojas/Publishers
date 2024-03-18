

namespace publishers.Application.Exections
{
    internal class RoyschedServicesExctions: Exception
    {
        public RoyschedServicesExctions(string message) : base (message) 
        {
            //Grabar log y enviar por correo a mis compañeros de grupo
        }
    }
}

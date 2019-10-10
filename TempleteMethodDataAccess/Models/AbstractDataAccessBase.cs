using System.Configuration;

namespace TempleteMethodDataAccess.Models
{
    public abstract class AbstractDataAccessBase
    {
        public SqlClient _client;

        public void Conectar()
        {
            _client = new SqlClient(ConfigurationManager.
                    ConnectionStrings["SQLConnection"].ConnectionString);
            _client.Open();
        }

        public abstract void Seleccionar();
        public abstract void Procesar();
        public abstract void Agregar(Amigo amigo);
        public abstract void ProcesarAmigo();

        public void Desconectar()
        {
            if (_client.Conecction.State==System.Data.ConnectionState.Open)
                _client.Close();
        }

        public void ObtenerAmigos()
        {
            Conectar();
            Seleccionar();
            Procesar();
            Desconectar();
        }

        public void AgregarAmigo(Amigo amigo)
        {
            Conectar();
            Agregar(amigo);
            ProcesarAmigo();
            Desconectar();
        }
    }
}

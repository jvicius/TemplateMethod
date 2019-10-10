using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TempleteMethodDataAccess.Models
{
    public class AmigosDataAccess : AbstractDataAccessBase
    {
        private List<Amigo> _amigos;
        private bool _result;

        public override void Seleccionar()
        {
            _amigos = new List<Amigo>();
            try
            {
                if (_client.Conecction.State == ConnectionState.Open)
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "getamigos",
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var amigo = new Amigo
                        {
                            idamigo = Convert.ToInt32(dataReader["idamigo"].ToString()),
                            nombre = dataReader["nombre"].ToString(),
                            fecnac = Convert.ToDateTime(dataReader["fecnac"].ToString()),
                            direccion = dataReader["direccion"].ToString(),
                            telefono = dataReader["telefono"].ToString()
                        };
                        _amigos.Add(amigo);
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        public override void Procesar()
        {
            Console.WriteLine("***********Amigos***********");
            foreach (var amigo in _amigos)
            {
                Console.WriteLine($"{amigo.idamigo} {amigo.nombre} {amigo.telefono} {amigo.direccion}");
            }
            Console.WriteLine("");
        }

        public override void Agregar(Amigo amigo)
        {
            _result = false;
            try
            {
                if (_client.Conecction.State == ConnectionState.Open)
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "addamigo",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@nombre", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.nombre
                    };

                    var par2 = new SqlParameter("@fecnac", SqlDbType.DateTime)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.fecnac
                    };

                    var par3 = new SqlParameter("@direccion", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.direccion
                    };

                    var par4 = new SqlParameter("@telefono", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = amigo.telefono
                    };

                    var par5 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);
                    command.Parameters.Add(par5);

                    command.ExecuteNonQuery();

                    _result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception)
            {
                _result = false;
            }
        }

        public override void ProcesarAmigo()
        {
            Console.WriteLine(_result ? "Operacion realzida correctamente" : "Operacion realzida con errores");
        }
    }
}

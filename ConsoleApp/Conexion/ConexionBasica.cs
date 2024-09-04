using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp.Conexion
{
    public class Peliculas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class ConexionBasica
    {
        private string string_conexion = "server=localhost;database=db_facturas;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;";

        public void ObtenerPeliculas()
        {
            var sql_conexion = new SqlConnection(this.string_conexion);
            sql_conexion.Open();

            var consulta = "SELECT [Id],[Nombre] FROM Peliculas";
            var adaptador = new SqlDataAdapter(new SqlCommand(consulta, sql_conexion));
            var set_de_datos = new DataSet();
            adaptador.Fill(set_de_datos);

            var lista_peliculas = new List<Peliculas>();
            foreach (var elemento in set_de_datos.Tables[0].AsEnumerable())
            {
                lista_peliculas.Add(new Peliculas()
                {
                    Id = Convert.ToInt32(elemento.ItemArray[0].ToString()),
                    Nombre = elemento.ItemArray[1].ToString(),
                });
            }
            
            sql_conexion.Close();
            
            foreach (var pelicula in lista_peliculas)
            {
                Console.WriteLine(pelicula.Id.ToString() + "|" + pelicula.Nombre);
            }
        }
    }
}

/*

CREATE DATABASE db_facturas
GO
USE db_facturas;
GO

CREATE TABLE [Peliculas]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Nombre] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED ([Id])
)
GO

SELECT * FROM Peliculas

INSERT INTO Peliculas ([Nombre]) VALUES ('Test 1');
INSERT INTO Peliculas ([Nombre]) VALUES ('Test 2');
INSERT INTO Peliculas ([Nombre]) VALUES ('Test 3');

*/
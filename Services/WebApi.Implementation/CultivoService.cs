using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApi.Interface;
using WebApi.Model;

namespace WebApi.Implementation;

public class CultivoService : ICultivoService
{
    private readonly IConfiguration _configuration;
    private string connectionString;
    public CultivoService(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration.GetConnectionString("DatabaseConnection");
    }
    public IEnumerable<CultivoEntities> GetAll()
    {
        var cultivos = new List<CultivoEntities>();
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(
                @"SELECT Id, Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha 
                FROM Cultivos", connection
            );

            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    cultivos.Add(new CultivoEntities
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        EstacionCrecimiento = reader["EstacionCrecimiento"].ToString(),
                        TiempoCrecimiento = (int)reader["TiempoCrecimiento"],
                        EstadoCrecimiento = reader["EstadoCrecimiento"].ToString(),
                        FrecuenciaRiego = Convert.ToInt32(reader["FrecuenciaRiego"]),
                        FertilizanteUsado = reader["FertilizanteUsado"] != DBNull.Value ? reader["FertilizanteUsado"].ToString() : null,
                        ValorVenta = (decimal)reader["ValorVenta"],
                        FechaSiembra = (DateTime)reader["FechaSiembra"],
                        FechaCosecha = reader["FechaCosecha"] != DBNull.Value ? (DateTime?)reader["FechaCosecha"] : null
                    });
                }
            }
        }
        return cultivos;
    }
    public CultivoEntities GetById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(
                @"SELECT Id, Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha
                FROM Cultivos
                WHERE Id = @Id", connection
            );

            command.Parameters.AddWithValue("@Id", id);

            CultivoEntities cultivo = null;
            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    cultivo = new CultivoEntities
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        EstacionCrecimiento = reader["EstacionCrecimiento"].ToString(),
                        TiempoCrecimiento = (int)reader["TiempoCrecimiento"],
                        EstadoCrecimiento = reader["EstadoCrecimiento"].ToString(),
                        FrecuenciaRiego = Convert.ToInt32(reader["FrecuenciaRiego"]),
                        FertilizanteUsado = reader["FertilizanteUsado"] != DBNull.Value ? reader["FertilizanteUsado"].ToString() : null,
                        ValorVenta = (decimal)reader["ValorVenta"],
                        FechaSiembra = (DateTime)reader["FechaSiembra"],
                        FechaCosecha = reader["FechaCosecha"] != DBNull.Value ? (DateTime?)reader["FechaCosecha"] : null
                    };
                }
            }

            return cultivo;
        }
    }
    public CultivoEntities Add(CultivoEntities cultivo)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var cmd = new SqlCommand(
                @"INSERT INTO Cultivos(
                Nombre, EstacionCrecimiento, TiempoCrecimiento, EstadoCrecimiento, FrecuenciaRiego, FertilizanteUsado, ValorVenta, FechaSiembra, FechaCosecha)
                VALUES (@Nombre, @EstacionCrecimiento, @TiempoCrecimiento, @EstadoCrecimiento, @FrecuenciaRiego, @FertilizanteUsado, @ValorVenta, @FechaSiembra, @FechaCosecha)",
                connection
            );

            cmd.Parameters.AddWithValue("@Id", cultivo.Id);
            cmd.Parameters.AddWithValue("@Nombre", cultivo.Nombre);
            cmd.Parameters.AddWithValue("@EstacionCrecimiento", cultivo.EstacionCrecimiento);
            cmd.Parameters.AddWithValue("@TiempoCrecimiento", cultivo.TiempoCrecimiento);
            cmd.Parameters.AddWithValue("@EstadoCrecimiento", cultivo.EstadoCrecimiento);
            cmd.Parameters.AddWithValue("@FrecuenciaRiego", cultivo.FrecuenciaRiego);
            cmd.Parameters.AddWithValue("@FertilizanteUsado", cultivo.FertilizanteUsado);
            cmd.Parameters.AddWithValue("@ValorVenta", cultivo.ValorVenta);
            cmd.Parameters.AddWithValue("@FechaSiembra", cultivo.FechaSiembra);
            cmd.Parameters.AddWithValue("@FechaCosecha", cultivo.FechaCosecha ?? (object)DBNull.Value);

            connection.Open();

            cmd.ExecuteNonQuery();
        }
        return cultivo;
    }

    public void Update(CultivoEntities cultivo)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var cmd = new SqlCommand(
                @"UPDATE Cultivos
                SET Nombre = @Nombre,
                EstacionCrecimiento = @EstacionCrecimiento,
                TiempoCrecimiento = @TiempoCrecimiento,
                EstadoCrecimiento = @EstadoCrecimiento,
                FrecuenciaRiego = @FrecuenciaRiego,
                FertilizanteUsado = @FertilizanteUsado,
                ValorVenta = @ValorVenta,
                FechaSiembra = @FechaSiembra,
                FechaCosecha = @FechaCosecha
                WHERE Id = @Id", connection
            );

            cmd.Parameters.AddWithValue("@Id", cultivo.Id);
            cmd.Parameters.AddWithValue("@Nombre", cultivo.Nombre);
            cmd.Parameters.AddWithValue("@EstacionCrecimiento", cultivo.EstacionCrecimiento);
            cmd.Parameters.AddWithValue("@TiempoCrecimiento", cultivo.TiempoCrecimiento);
            cmd.Parameters.AddWithValue("@EstadoCrecimiento", cultivo.EstadoCrecimiento);
            cmd.Parameters.AddWithValue("@FrecuenciaRiego", cultivo.FrecuenciaRiego);
            cmd.Parameters.AddWithValue("@FertilizanteUsado", (object)cultivo.FertilizanteUsado ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ValorVenta", cultivo.ValorVenta);
            cmd.Parameters.AddWithValue("@FechaSiembra", cultivo.FechaSiembra);
            cmd.Parameters.AddWithValue("@FechaCosecha", (object)cultivo.FechaCosecha ?? DBNull.Value);

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
         using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(
                @"DELETE FROM Cultivos
                WHERE Id = @Id", connection
            );

            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
       
    }

}

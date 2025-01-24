using Microsoft.Data.Sqlite;
public class ProductoRepository
{
    private string _cadenaDeConexion;
    public ProductoRepository(string cadenaDeConexion)
    {
        _cadenaDeConexion = cadenaDeConexion;
    }

    public bool AltaProducto(Producto producto)
    {
        // string query = "INSERT INTO Productos (idProducto, Descripcion, Precio)" +
        // "VALUES(@idProducto, @Descripcion, @Precio)";

        string query = "INSERT INTO Productos (Descripcion, Precio)" +
        "VALUES(@Descripcion, @Precio)";

        int cantidad_filas = 0;

        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            cantidad_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cantidad_filas > 0;

    }

    public bool UpdateProducto(int id, Producto producto)
    {
        string query = "UPDATE Productos SET Descripcion = @Descripcion WHERE idProducto = @id";
        int cant_filas = 0;
        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();

            SqliteCommand command = new SqliteCommand(query, conexion);

            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@id", id));
            
            cant_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cant_filas > 0;

    }

    public List<Producto> ListarProductosRegistrados()
    {
        string query = "SELECT idProducto, Descripcion, Precio FROM Productos";
        List<Producto> listaProductos = new List<Producto>(); //inicializo la lista vacia

        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listaProductos.Add(new Producto {
                        IdProducto = Convert.ToInt32(reader["idProducto"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToInt32(reader["Precio"])
                    });
                }
            }
            conexion.Close();
        }

        return listaProductos;
    }

    public Producto ObtenerProductoPorId(int id)
    {
        string query = "SELECT * FROM Productos WHERE idProducto=@idProducto";
        Producto producto = null;
        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@idProducto", id));

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    producto = new Producto
                    {
                        IdProducto = Convert.ToInt32(reader["idProducto"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToInt32(reader["Precio"])
                    };
                }
            }
            conexion.Close();
        }
        return producto;
    }

    public bool BorrarProductoPorId(int id)
    {
        string query = "DELETE FROM Productos WHERE idProducto = @idProducto";
        int cant_filas = 0;
        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@idProducto", id));
            cant_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cant_filas > 0;

    }
}
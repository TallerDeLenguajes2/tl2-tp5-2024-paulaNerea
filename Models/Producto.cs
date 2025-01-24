// public class Producto
// {
//     public int IdProducto { get; set; }
//     public string Descripcion { get; set; }
//     public int Precio { get; set; }

//     public Producto(int idProducto, string descripcion, int precio)
//     {
//         IdProducto = idProducto;
//         Descripcion = descripcion;
//         Precio = precio;
//     }
//     public Producto() { }
// }

public class Producto
{
    public int IdProducto { get; set; } // Se llenará automáticamente desde la DB
    public string Descripcion { get; set; }
    public int Precio { get; set; }

    public Producto() { }
}
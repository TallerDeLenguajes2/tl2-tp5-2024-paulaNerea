public class Presupuesto
{
    public int IdPresupuesto { get; set; }
    public string NombreDestinatario { get; set; }
    public List<PresupuestoDetalle> Detalle { get; set; }

    public Presupuesto(int idPresupuesto, string nombreDestinatario)
    {
        IdPresupuesto = idPresupuesto;
        NombreDestinatario = nombreDestinatario;
        Detalle = new List<PresupuestoDetalle>();
    }

    public float MontoPresupuesto()
    {
        float total = 0;
        foreach (var detalle in Detalle)
        {
            total += detalle.Cantidad * detalle.Producto.Precio;
        }

        return total;
    }
    public float MontoPresupuestoConIva()
    {
        float total = MontoPresupuesto();
        double iva = 0.21;

        return (float)(total * (iva + 1));

    }

    public int CantidadProductos()
    {
        int total = 0;
        foreach (var detalle in Detalle)
        {
            total += detalle.Cantidad;
        }
        return total;

    }
        
}
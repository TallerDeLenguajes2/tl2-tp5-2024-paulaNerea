using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_paulaNerea.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{

    private readonly ILogger<ProductoController> _logger;

    private readonly ProductoRepository _productoRepository;

    public ProductoController(ILogger<ProductoController> logger)
    {
        _logger = logger;
        _productoRepository=  new ProductoRepository("Data Source=Tienda.db;Cache=Shared");
    }

    [HttpPost("AgregarProducto")]
    public ActionResult AltaProducto([FromBody] Producto producto)
    {
        Producto nuevo = new Producto
        {
            Descripcion = producto.Descripcion, 
            Precio = producto.Precio
        };
        
        bool productoCreado = _productoRepository.AltaProducto(nuevo);
        if(!productoCreado) return BadRequest("No se puedo crear el nuevo producto");

        return Ok("Producto creado con éxito");
    }    

    [HttpPut("ActualizarNombreProducto/{id}")]
    public ActionResult<Producto> UpdateProducto(int id, [FromBody] Producto producto)
    {
        Producto buscado = _productoRepository.ObtenerProductoPorId(id);
        if(buscado is null) return BadRequest("No se encontró el producto con ese id");
    
        bool actualizado = _productoRepository.UpdateProducto(id, producto);
        if(!actualizado) return BadRequest("No se puedo actualizar el producto");

        return Ok("Producto actualizado con éxito");
    }

    [HttpGet("ListarProductos")]
    public ActionResult<IEnumerable<Producto>> GetProductos()
    {
        List<Producto> productos = _productoRepository.ListarProductosRegistrados();
        if (!productos.Any()) return NotFound ("No se encontraron productos");

        return Ok(productos);
    }

    [HttpDelete("EliminarProducto/{id}")]
    public ActionResult BajaProducto(int id)
    {
        bool productoBorrado= _productoRepository.BorrarProductoPorId(id);
        if (!productoBorrado) return BadRequest("No se pudo borrar el producto");
        return Ok("Producto borrado con éxito");
    }

}

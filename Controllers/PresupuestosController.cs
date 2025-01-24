using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_paulaNerea.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{

    private readonly ILogger<PresupuestosController> _logger;

    private readonly ProductoRepository _productoRepository;

    public PresupuestosController(ILogger<PresupuestosController> logger)
    {
        _logger = logger;
        _productoRepository=  new ProductoRepository("Data Source=Tienda.db;Cache=Shared");
    }

// ● POST /api/Presupuesto: Permite crear un Presupuesto.
// ● POST /api/Presupuesto/{id}/ProductoDetalle: Permite agregar un Producto existente
// y una cantidad al presupuesto.
// ● GET /api/presupuesto: Permite listar los presupuestos existentes.
// ● GET /api/Presupuesto/{id}: Permite agregar un Producto existente y una cantidad al
// presupuesto.


}
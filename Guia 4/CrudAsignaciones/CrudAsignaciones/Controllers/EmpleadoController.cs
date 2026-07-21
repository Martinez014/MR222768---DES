
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudAsignaciones.Models;
using CrudAsignaciones.Data;

public class EmpleadoController : Controller
{
    private readonly EmpresaDbContext _context;

    public EmpleadoController(EmpresaDbContext context)
    {
        _context = context;
    }

    // GET: EMPLEADOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Empleados.ToListAsync());
    }

    // GET: EMPLEADOS/Details/5
    public async Task<IActionResult> Details(int? empleadoid)
    {
        if (empleadoid == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleados
            .FirstOrDefaultAsync(m => m.EmpleadoId == empleadoid);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // GET: EMPLEADOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EMPLEADOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmpleadoId,Nombre,Apellido,FechaContratacion,Puesto")] Empleado empleado)
    {
        if (ModelState.IsValid)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(empleado);
    }

    // GET: EMPLEADOS/Edit/5
    public async Task<IActionResult> Edit(int? empleadoid)
    {
        if (empleadoid == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleados.FindAsync(empleadoid);
        if (empleado == null)
        {
            return NotFound();
        }
        return View(empleado);
    }

    // POST: EMPLEADOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? empleadoid, [Bind("EmpleadoId,Nombre,Apellido,FechaContratacion,Puesto")] Empleado empleado)
    {
        if (empleadoid != empleado.EmpleadoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(empleado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(empleado.EmpleadoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(empleado);
    }

    // GET: EMPLEADOS/Delete/5
    public async Task<IActionResult> Delete(int? empleadoid)
    {
        if (empleadoid == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleados
            .FirstOrDefaultAsync(m => m.EmpleadoId == empleadoid);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // POST: EMPLEADOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? empleadoid)
    {
        var empleado = await _context.Empleados.FindAsync(empleadoid);
        if (empleado != null)
        {
            _context.Empleados.Remove(empleado);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmpleadoExists(int? empleadoid)
    {
        return _context.Empleados.Any(e => e.EmpleadoId == empleadoid);
    }
}

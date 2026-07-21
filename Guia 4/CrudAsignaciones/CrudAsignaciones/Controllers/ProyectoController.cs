
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudAsignaciones.Models;
using CrudAsignaciones.Data;

public class ProyectoController : Controller
{
    private readonly EmpresaDbContext _context;

    public ProyectoController(EmpresaDbContext context)
    {
        _context = context;
    }

    // GET: PROYECTOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Proyectos.ToListAsync());
    }

    // GET: PROYECTOS/Details/5
    public async Task<IActionResult> Details(int? proyectoid)
    {
        if (proyectoid == null)
        {
            return NotFound();
        }

        var proyecto = await _context.Proyectos
            .FirstOrDefaultAsync(m => m.ProyectoId == proyectoid);
        if (proyecto == null)
        {
            return NotFound();
        }

        return View(proyecto);
    }

    // GET: PROYECTOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PROYECTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProyectoId,NombreProyecto,Descripcion,FechaInicio")] Proyecto proyecto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(proyecto);
    }

    // GET: PROYECTOS/Edit/5
    public async Task<IActionResult> Edit(int? proyectoid)
    {
        if (proyectoid == null)
        {
            return NotFound();
        }

        var proyecto = await _context.Proyectos.FindAsync(proyectoid);
        if (proyecto == null)
        {
            return NotFound();
        }
        return View(proyecto);
    }

    // POST: PROYECTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? proyectoid, [Bind("ProyectoId,NombreProyecto,Descripcion,FechaInicio")] Proyecto proyecto)
    {
        if (proyectoid != proyecto.ProyectoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(proyecto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(proyecto.ProyectoId))
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
        return View(proyecto);
    }

    // GET: PROYECTOS/Delete/5
    public async Task<IActionResult> Delete(int? proyectoid)
    {
        if (proyectoid == null)
        {
            return NotFound();
        }

        var proyecto = await _context.Proyectos
            .FirstOrDefaultAsync(m => m.ProyectoId == proyectoid);
        if (proyecto == null)
        {
            return NotFound();
        }

        return View(proyecto);
    }

    // POST: PROYECTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? proyectoid)
    {
        var proyecto = await _context.Proyectos.FindAsync(proyectoid);
        if (proyecto != null)
        {
            _context.Proyectos.Remove(proyecto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProyectoExists(int? proyectoid)
    {
        return _context.Proyectos.Any(e => e.ProyectoId == proyectoid);
    }
}

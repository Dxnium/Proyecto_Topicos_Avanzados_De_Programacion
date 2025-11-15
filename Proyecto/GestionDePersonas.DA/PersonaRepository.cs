
using GestionDePersonas.BL;
using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionDePersonas.DA
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DBContexto _context;

        public PersonaRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task Create(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var persona = await ObtenerPorId(id);
                if (persona != null)
                {
                    _context.Personas.Remove(persona);
                    await _context.SaveChangesAsync();
            }
        }

        public Task<Persona?> ObtenerPorCedula(int cedula)
        {
           return _context.Personas.FirstOrDefaultAsync(p => p.Cedula == cedula);
        }

        public async Task<Persona?> ObtenerPorId(int id)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Persona>> Read()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task Update(int id, Persona persona)
        {
            var laPersonaAModificar = await ObtenerPorId(id);
            if (laPersonaAModificar != null)
            {
                laPersonaAModificar.Cedula = persona.Cedula;
                laPersonaAModificar.Nombre = persona.Nombre;
                laPersonaAModificar.Edad = persona.Edad;
                laPersonaAModificar.Telefono = persona.Telefono;
                laPersonaAModificar.salario = persona.salario;
                _context.Personas.Update(laPersonaAModificar);
                await _context.SaveChangesAsync();
            }
        }
    }
}

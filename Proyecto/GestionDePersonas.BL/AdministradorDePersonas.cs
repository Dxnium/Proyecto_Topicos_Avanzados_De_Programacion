using GestionDePersonas.BL.ReglasDeNegocio;
using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public class AdministradorDePersonas : IAdministradorDePersonas
    {
        private readonly IPersonaRepository personaRepository;

        public AdministradorDePersonas(IPersonaRepository personaRepository)
        {
            this.personaRepository = personaRepository;
        }

        public async Task Create(Persona persona)
        {
            if (!ReglasDePersona.LaPersonaEsValida(persona))
            {
                throw new ArgumentException("La persona no es válida.");
            }

            var existente = await personaRepository.ObtenerPorCedula(persona.Cedula);

            if (existente != null)
            {
                throw new ArgumentException("La cédula ya está registrada en la base de datos.");
            }

             await personaRepository.Create(persona);
        }

        public async Task Delete(int id)
        {
            if (!ReglasDePersona.ElIdEsValido(id))
            {
                throw new ArgumentException("El id no es valido.");
            }
            await personaRepository.Delete(id);
        }

        public async Task<Persona?> ObtenerPorCedula(int cedula)
        {
            if (!ReglasDePersona.LacedulaEsValidaMayor(cedula))
            {
                throw new ArgumentException("La cedula no es valida.");
            }

            return await personaRepository.ObtenerPorCedula(cedula);
        }

        public async Task<Persona?> ObtenerPorId(int id)
        {
            if (!ReglasDePersona.ElIdEsValido(id))
            {
                throw new ArgumentException("El id no es valido.");
            }

            return await personaRepository.ObtenerPorId(id);
        }

        public async Task<IEnumerable<Persona>> Read()
        {
           return await personaRepository.Read();
        }

        public async Task Update(int id, Persona persona)
        {

            if (!ReglasDePersona.ElIdEsValido(id))
                throw new ArgumentException("El ID no es válido.");

           
            if (!ReglasDePersona.LaPersonaEsValida(persona))
                throw new ArgumentException("Los datos de la persona no son válidos.");

           
            var personaExistente = await personaRepository.ObtenerPorId(id);

            if (personaExistente == null)
                throw new ArgumentException("La persona no existe.");

            var personaConCedula = await personaRepository.ObtenerPorCedula(persona.Cedula);

            if (personaConCedula != null && personaConCedula.Id != id)
            {
                throw new ArgumentException("La cédula ya está registrada en otra persona.");
            }

            await personaRepository.Update(id, persona);   
        }
    }
}

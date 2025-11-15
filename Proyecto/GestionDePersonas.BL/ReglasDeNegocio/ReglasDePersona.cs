
using GestionDePersonas.Model;

namespace GestionDePersonas.BL.ReglasDeNegocio
{
    public class ReglasDePersona
    {
        public static bool LaPersonaEsValida(Persona persona)
        {
            return    LaCedulaEsValida(persona) &&
                      ElNombreEsValido(persona) &&
                      LaEdadEsValida(persona) &&
                      TelefonoEsValido(persona) &&
                      SalarioEsValido(persona);
        }

        public static bool LaCedulaEsValida(Persona persona)
        {
            return persona.Cedula > 0;
        }

        public static bool ElNombreEsValido(Persona persona)
        {
            return !string.IsNullOrEmpty(persona.Nombre) && persona.Nombre.Length >= 3 && persona.Nombre.Length <= 50;
        }

        public static bool LaEdadEsValida(Persona persona)
        {
            return persona.Edad >= 0 && persona.Edad <= 120;
        }

        public static bool TelefonoEsValido(Persona persona)
        {
            return persona.Telefono >= 1000000 && persona.Telefono <= 999999999;
        }

        public static bool SalarioEsValido(Persona persona)
        {
            return persona.salario >= 0;
        }
        public static bool ElIdEsValido(int id)
        {
            return id > 0;
        }

        public static bool LacedulaEsValidaMayor (int cedula)
        {
            return cedula > 0;
        }
    }
}

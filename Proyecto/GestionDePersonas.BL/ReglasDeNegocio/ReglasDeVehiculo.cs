using GestionDePersonas.Model;

namespace GestionDePersonas.BL.ReglasDeNegocio
{
    public class ReglasDeVehiculo
    {
        public static bool ElVehiculoEsValido(Vehiculo vehiculo)
        {
            return
            LaPlacaEsValida(vehiculo) &&
            LaMarcaEsValida(vehiculo) &&
            ElModeloEsValido(vehiculo) &&
            ElAnioEsValido(vehiculo);
        }

        public static bool LaPlacaEsValida(Vehiculo vehiculo)
        {
            return !string.IsNullOrEmpty(vehiculo.Placa) &&
                   vehiculo.Placa.Length <= 6;
        }

        public static bool LaMarcaEsValida(Vehiculo vehiculo)
        {
            return !string.IsNullOrEmpty(vehiculo.Marca) &&
                   vehiculo.Marca.Length >= 2 &&
                   vehiculo.Marca.Length <= 50;
        }

        public static bool ElModeloEsValido(Vehiculo vehiculo)
        {
            return !string.IsNullOrEmpty(vehiculo.Modelo) &&
                   vehiculo.Modelo.Length >= 2 &&
                   vehiculo.Modelo.Length <= 50;
        }

        public static bool ElAnioEsValido(Vehiculo vehiculo)
        {
            return vehiculo.Anio >= 1900 && vehiculo.Anio <= DateTime.Now.Year + 1;
        }

        public static bool ElIdEsValido(int id)
        {
            return id > 0;
        }
    }

}

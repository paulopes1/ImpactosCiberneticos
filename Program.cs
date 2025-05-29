using System;
using ImpactoCiberneticoFalhasEnergia.Services;

namespace ImpactoCiberneticoFalhasEnergia
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();
            sistema.Iniciar();
        }
    }
}

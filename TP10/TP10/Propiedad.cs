using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP10
{
    class Property
    {
        int _Id;
        string _TipoDePropiedad;
        string _TipoDeOperacion;
        float _Tamanio;
        int _CantidadDeBanios;
        int _CantidadDeHabitaciones;
        string _Domicilio;
        float _Precio;
        bool _Estado;//true=activo false=inactivo
        //float _ValorDelInmueble;

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string TipoDePropiedad
        {
            get
            {
                return _TipoDePropiedad;
            }

            set
            {
                _TipoDePropiedad = value;
            }
        }

        public string TipoDeOperacion
        {
            get
            {
                return _TipoDeOperacion;
            }

            set
            {
                _TipoDeOperacion = value;
            }
        }

        public float Tamanio
        {
            get
            {
                return _Tamanio;
            }

            set
            {
                _Tamanio = value;
            }
        }

        public int CantidadDeBanios
        {
            get
            {
                return _CantidadDeBanios;
            }

            set
            {
                _CantidadDeBanios = value;
            }
        }

        public int CantidadDeHabitaciones
        {
            get
            {
                return _CantidadDeHabitaciones;
            }

            set
            {
                _CantidadDeHabitaciones = value;
            }
        }

        public string Domicilio
        {
            get
            {
                return _Domicilio;
            }

            set
            {
                _Domicilio = value;
            }
        }

        public float Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

        public bool Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public void ShowProperty()
        {
            Console.WriteLine("\n\n* Inmueble (Id "+_Id+") :");
            Console.WriteLine("    Tipo de propiedad: " + _TipoDePropiedad);
            Console.WriteLine("    Tipo de operacion: " + _TipoDeOperacion);
            Console.WriteLine("    Tamaño: " + _Tamanio + "m2");
            Console.WriteLine("    Cantidad de baños: " + _CantidadDeBanios);
            Console.WriteLine("    Cantidad de habitaciones: " + _CantidadDeHabitaciones);
            Console.WriteLine("    Domicilio: " + _Domicilio);
            Console.WriteLine("    Precio: $" + _Precio);
            if (_Estado)
            {
                Console.WriteLine("    Estado: Activo ");
            }
            else
            {
                Console.WriteLine("    Estado: Inactivo ");
            }
            
            Console.WriteLine("    Valor del Inmueble: $" + ValorDelInmueble());

        }

        double ValorDelInmueble()
        {
            double PrecioFinal = 0;
            if (_TipoDeOperacion == "Venta")
            {
                PrecioFinal = _Precio + (_Precio * 0.21) + (_Precio * 0.10) + 10000;
            }

            if (_TipoDeOperacion == "Alquiler")
            {
                PrecioFinal = (_Precio * 0.02) + (_Precio * 0.5);
            }

            return PrecioFinal;
        }

        public string ConcatenarDatos()
        {
            string aux;
            if (_Estado)
            {
                aux = "Activo";
            }
            else
            {
                aux = "Inactivo";
            }
            return _Id + ";" + _TipoDePropiedad + ";" + _TipoDeOperacion + ";" + _Tamanio + ";" + _CantidadDeBanios + ";" + _CantidadDeHabitaciones + ";" + _Domicilio + ";" + _Precio + ";" + aux+";"+ ValorDelInmueble();
        }
    }
}

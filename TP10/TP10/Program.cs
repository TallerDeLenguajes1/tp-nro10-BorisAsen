using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP10
{
    public enum TipoDeOperacion { Venta, Alquiler };
    public enum TipoDePropiedad { Departamento, Casa, Duplex, Penthouse, Terreno };
    public enum Calles { SanJuan, Santiago, Mendoza, AvRoca, AvIndependencia, Suipacha };

    class Program
    {
        static void Main(string[] args)
        {
            //Crear lista de inmuebles
            List<Property> Properties = new List<Property>();

            //Cargar los datos de los inmuebles en la lista
            Console.WriteLine(" Propiedades Cargadas desde csv: ");
            string CsvFile = "propiedades.csv";
            PropertiesFromCsvToList(CsvFile, Properties);

            //Mostar todos las propiedades por pantalla
            ShowProperties(Properties);

            //Guardar la nueva lista en un csv
            string CsvFileToSave = "propiedades guardadas.csv";
            SaveListInCsv(Properties, CsvFileToSave);

            //Listar los discos y solicitar la unidad en la que se hara el bk
            Console.WriteLine("\nA continuacion se enlistaran los discos disponobles para el backup:");
            string bkDest = SelectBackUpPath();
            BackUp(Properties, bkDest);
            Console.ReadKey();

        }

        public static void BackUp(List<Property> Properties, string nkDest)
        {
            string BackUpPath = nkDest+@"\Backup";
            string fileNumber = "";

            if (!Directory.Exists(BackUpPath))
            {
                Directory.CreateDirectory(BackUpPath);
            }
            else
            {
                string[] availableFiles = Directory.GetFiles(BackUpPath);
                fileNumber = Convert.ToString(availableFiles.Length);
            }

            string BackUpFile = BackUpPath + @"\backup" + fileNumber+".bk";

            FileStream bk = File.Create(BackUpFile);
            using (StreamWriter bkWriter = new StreamWriter(bk))
            {
                string line;
                foreach (Property prop in Properties)
                {
                    line = prop.ConcatenarDatos();
                    bkWriter.WriteLine(line);
                }
                bkWriter.Close();
            }

            Console.WriteLine("\nArchivo de backup creado: "+BackUpFile);
        }


        public static string SelectBackUpPath()
        {
            int i = 1;
            string[] availableDisks = Environment.GetLogicalDrives();
            Console.WriteLine();
            foreach (string drive in availableDisks)
            {
                Console.WriteLine("   " + i + ") " + drive);
                i++;
            }

            Console.Write("\nIngrese el numero correspondiente al disco elegido: ");
            int nro = Convert.ToInt16(Console.ReadLine());
            string selectedDirectory = @availableDisks[nro - 1];
            Console.WriteLine("\nOpcion seleccionada: " + selectedDirectory);

            return selectedDirectory;
        }

        public static void PropertiesFromCsvToList(string CsvFile, List<Property> Properties)
        {
            string[] content=null;
            try
            {
                content = File.ReadAllLines(CsvFile);
            }
            catch (Exception error)
            {
                Console.WriteLine("\n¡Hubo un error!\n");
                Console.WriteLine(error.Message);   
            }
            
            Property new_p;

            foreach (string line in content)
            {
                new_p = NewProperty(line);
                Properties.Add(new_p);
            }
        }

        public static Random rand = new Random();

        public static Property NewProperty(string line)
        {
            string[] lineContent = line.Split(';');


            Property new_p = new Property();

            int _Id = rand.Next(100);
            string _TipoDePropiedad  = lineContent[1];
            //string _TipoDePropiedad = Enum.GetName(typeof(TipoDePropiedad), rand.Next(5)); //Del 0 al 4
            string _TipoDeOperacion = Enum.GetName(typeof(TipoDeOperacion), rand.Next(2)); //Del 0 al 4;
            float _Tamanio = rand.Next(1001)+1;
            int _CantidadDeBanios = rand.Next(5)+1;//1 al 5
            int _CantidadDeHabitaciones = rand.Next(10) + 1;//1 al 10;
            string _Domicilio = lineContent[0];
            //string _Domicilio = Enum.GetName(typeof(Calles), rand.Next(5)) +" "+ Convert.ToString(rand.Next(1001));
            int _Precio = rand.Next(2000000);
            bool BoolAux;
            if (rand.Next(2)==1)
            {
                BoolAux = true;
            }
            else
            {
                BoolAux = false;
            }
            bool _Estado = BoolAux;

            new_p.Id = _Id;
            new_p.TipoDePropiedad = _TipoDePropiedad;
            new_p.TipoDeOperacion = _TipoDeOperacion;
            new_p.Tamanio = _Tamanio;
            new_p.CantidadDeBanios = _CantidadDeBanios;
            new_p.CantidadDeHabitaciones = _CantidadDeHabitaciones;
            new_p.Domicilio = _Domicilio;
            new_p.Precio = _Precio;
            new_p.Estado = _Estado;

            return new_p;

        }

        public static void ShowProperties(List<Property> Properties)
        {
            foreach (Property pro in Properties)
            {
                pro.ShowProperty();
            }
        }

        public static void SaveListInCsv(List<Property> Properties, string CsvFileToSave)
        {
            //StreamWriter file = File.CreateText(CsvFileToSave);
            string line;

            using (StreamWriter file = File.CreateText(CsvFileToSave))
            {
                foreach (Property prop in Properties)
                {
                    line = prop.ConcatenarDatos();
                    file.WriteLine(line);
                }
                file.Close();
            }

            

            
        }
    }
}

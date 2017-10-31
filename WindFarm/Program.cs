using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindFarm
{
    class Program
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
        //public static WindFarm windfarm;

        static void Main(string[] args)
        {

            WindFarm windfarm = LoadExistingWindFarm();
           // WindFarm windfarm = MakeNewWindFarm();

            //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(windfarm.GetType());
            //System.IO.FileStream file = System.IO.File.Create(path);
            //writer.Serialize(file, windfarm);
            //file.Close();

            windfarm.DisplayState();
            
            Console.ReadKey();
        }

        public static WindFarm MakeNewWindFarm()
        {
            WindFarm windfarm = new WindFarm();
            windfarm.Country = "Fr2";
            windfarm.Name = "Test2";
            windfarm.WTGNumber = 2;
            windfarm.WindFarmDefine();
            return windfarm;
        }
        public static WindFarm LoadExistingWindFarm()
        {
            WindFarm windfarm = WindFarm.Load(path);
            
            SerializeWindFarmClass.XMLWriter.path = path;
            SerializeWindFarmClass.XMLWriter.ClassToSerialized = windfarm;
            SerializeWindFarmClass.XMLWriter.WriteXML();
            return windfarm;
        }

    }

    public class WindFarm
    {
        private List<Windturbine> windTurbines = new List<Windturbine>();

        public string Name { get; set; }
        public string Country { get; set; }
        public long WTGNumber { get; set; }
        
        public List<Windturbine> WindTurbines
        {
            get { return windTurbines; }
            set { windTurbines = value; }
        }

        public void WindFarmDefine()
        {
            for (int i = 0;i < this.WTGNumber; i++)
            {
                windTurbines.Add(new Windturbine());
                windTurbines[i].HubHeight = 100;
                windTurbines[i].RotorDiameter= 150;
                windTurbines[i].Name = "V100";
                windTurbines[i].Make= "Vestas";
            }
        }

        public void DisplayState()
        {
            Console.WriteLine(this.Country + this.Name);
        }
        
        public static WindFarm Load(string path)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(WindFarm));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            try
            {
                return (WindFarm)reader.Deserialize(file);
            }
            finally
            {
                file.Close();
            }
        }


    }
}

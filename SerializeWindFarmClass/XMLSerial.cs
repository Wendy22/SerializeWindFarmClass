using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeWindFarmClass
{
    public static class XMLWriter
    {
        private static object classToBeSerialized;      //instance of class needed to be serialized
        public static Object ClassToSerialized
        {
            get { return classToBeSerialized; }
            set { classToBeSerialized = value; }
        }

        public static string path{ get; set; }

        public static void WriteXML()
        {

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(classToBeSerialized.GetType());

            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, classToBeSerialized);
            file.Close();
        }

        //public object ReadXML()
        //{
        //    System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(this.ClassToSerialized.GetType());
        //    System.IO.StreamReader file = new System.IO.StreamReader(path);
            //this.ClassToSerialized.GetType() test = (this.ClassToSerialized.GetType())reader.Deserialize(file);
        //    return (this.classToBeSerialized.GetType())
        //    file.Close();            
        //    Console.ReadKey();
        //}

    }
}

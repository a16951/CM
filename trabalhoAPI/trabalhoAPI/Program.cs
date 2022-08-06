using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace trabalhoAPI
{
    //CLiente
    class Program
    {

        enum FileType
        {
            TXT,
            JPG,
            PNG

        }

        [Serializable]
        class Pdu
        {
            public header h = new header();
            public FileContent u = new FileContent();
        }


        class header
        {
            public FileType fileType;
            public string filename;
        }


        class FileContent
        {
            public FileStream fd;

        }



        static void Main(string[] args)
        {
            Pdu p = new Pdu();
            p.h.fileType = FileType.TXT;
            p.h.filename = "Users.txt";

            //BinaryReader reader = new BinaryReader(File.Open(@"C:\Users\joao\Desktop\TrabalhoCM\WebApplication1\User.txt", FileMode.Open));
            //FileStream fo = new FileStream(@"C:\Users\joao\Desktop\TrabalhoCM\WebApplication1\User.txt", FileMode.Open);


            MemoryStream ms = new MemoryStream();
            using(BsonWriter Writer = new BsonWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(Writer, reader);
            }

            string data = Convert.ToBase64String(reader.ToArray());
           
        }

    }
}

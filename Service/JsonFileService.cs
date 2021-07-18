using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5.Model;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WpfApp5.Service
{
   public class JsonFileService : IService
    {
        public List<Movie> Open(string filename)
        {
            var movies = new List<Movie>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Movie>));
            using (FileStream fs=new FileStream(filename,FileMode.OpenOrCreate))
            {
                movies = jsonFormatter.ReadObject(fs) as List<Movie>;
            }
            return movies;
        }

        public void Save(string filename, List<Movie> movies)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Movie>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(stream: fs, graph: movies);
            }
        }
    }
}

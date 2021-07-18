using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Model
{
    public class Movie
    {
        public Movie(string name, DateTime year, string genre, float imdb)
        {
            Name = name;
            Year = year;
            Genre = genre;
            Imdb = imdb;
        }

        public string Name  { get; set; }
        public DateTime Year { get; set; }
        public string Genre  { get; set; }
        
        public float Imdb  { get; set; }
        public Movie()
        {

        }
    }
}

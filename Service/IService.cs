using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5.Model;

namespace WpfApp5.Service
{
    public interface IService
    {
        List<Movie> Open(string filename);
        void Save(string filename, List<Movie> movies);
    }
}

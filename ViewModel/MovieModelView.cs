using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5.Model;
using WpfApp5.Service;
using WpfApp5.Service.Command;

namespace WpfApp5.ViewModel
{
    class MovieModelView : INotifyPropertyChanged
    {
        private Movie selectedMovie;
        private int selectedMovieIndex;
        private IService _fileService;
        public ObservableCollection<Movie> Movies { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public MovieModelView(IService fileService)
        {
            _fileService = fileService;
            Movies = new ObservableCollection<Movie>
            {
                new Movie("Harry Potter",new DateTime(2018,10,10),"Fantasy",9),
                 new Movie("Kill Bill",new DateTime(2018,10,10),"Action",9),
                  new Movie("Focus",new DateTime(2018,10,10),"Action",9)

            };
        }
        protected virtual void OnPropertyChanged(string propertyName = null) {

            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));

        }
        public int SelectedMovieIndex {

            get => selectedMovieIndex;
            set => selectedMovieIndex = value;
        
        }
        public Movie SelectedMovie
        {

            get => selectedMovie;
            set
            {
                selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        private RelyCommand _saveCommand;

      

        public RelyCommand SaveCommand {

            get {

                return _saveCommand ?? (_saveCommand = new RelyCommand(obj =>

                    _fileService.Save("movies.json", Movies.Select(m=> new Movie
                    {
                        Name = m.Name,
                        Year = m.Year,
                        Genre = m.Genre,
                     
                        Imdb = m.Imdb,
                      
                       
                    }).ToList())
                ));
                   
            
            }
        
        
        
        }
        private RelyCommand _openCommand;

        public RelyCommand OpenCommand
        {

            get
            {

                return _openCommand ?? (_openCommand = new RelyCommand(obj =>
               {
                   var movies = _fileService.Open("movies.json");
                   Movies.Clear();
                   foreach (var item in movies)
                   {
                       movies.Add(item);

                   }

               }));
               
            }



        }
        private RelyCommand _addCommand;

        public RelyCommand AddCommand
        {

            get
            {

                return _openCommand ?? (_addCommand = new RelyCommand(obj =>
                {
                    Movie movie = new Movie();
                    Movies.Add(movie);
                    SelectedMovie = movie;

                }));

            }



        }
        private RelyCommand _removeCommand;

        public RelyCommand RemoveCommand
        {

            get
            {

                return _removeCommand ?? (_removeCommand = new RelyCommand(obj =>
                {
                    Movie movie = obj as Movie;
                    if (movie != null) {

                        Movies.Remove(movie);
                    }

                    SelectedMovie = Movies[0];
                }));

            }



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMovie
{
    interface FilmDao
    {
        List<Film> getAllFilm();
        Film getFilm(int id);
        void updateFilm(Film film);
        void deleteFilm(Film film);
        void addFilm(Film f);
    }
}

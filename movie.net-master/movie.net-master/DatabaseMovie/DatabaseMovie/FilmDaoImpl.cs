using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMovie
{
    class FilmDaoImpl : FilmDao
    {
        List<Film> lesFilms;
        Model1Container ctx;
        public FilmDaoImpl()
        {
            ctx = new Model1Container();
            lesFilms = ctx.FilmSet.ToList();
            if (lesFilms.LongCount() <= 0)
            {
                Film test = new Film();
                test.Titre = "test1";
                lesFilms.Add(test);
            }
        }

        public void deleteFilm(Film film)
        {
            ctx.FilmSet.Remove(film);
            lesFilms.Remove(film);
            ctx.SaveChanges();
        }

        public List<Film> getAllFilm()
        {
            return lesFilms;
        }

        public Film getFilm(int id)
        {
            return ctx.FilmSet.ElementAt(id);
        }

        public void updateFilm(Film film)
        {
            lesFilms[film.Id].Titre = film.Titre;
            ctx.Entry(film).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void addFilm(Film f)
        {
            int stateSaveChange;
            var films = ctx.Set<Film>();
            films.Add(f);
            Console.WriteLine("Film add :" + f.Titre);
            ctx.FilmSet.Add(f);
            //ctx.Entry(f).State = System.Data.Entity.EntityState.Added;
            try
            {
                ctx.SaveChanges();
                stateSaveChange = ctx.SaveChanges();
                Console.WriteLine("stateSaveChange : " + stateSaveChange);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine(" ****** Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine(" ****** Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
        }
    }
}

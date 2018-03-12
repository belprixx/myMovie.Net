using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMovie
{
    public class Facade
    {
        private static Facade instance;
        UtilisateurDaoImpl utilisateur;
        FilmDaoImpl film;
        AvisDaoImpl avis;

        private Facade() {
            utilisateur = new UtilisateurDaoImpl();
            film = new FilmDaoImpl();
            avis = new AvisDaoImpl();
        }

        public static Facade Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Facade();
                }
                return instance;
            }
        }

        public void methodAddUtilisateur(Utilisateur u)
        {
            utilisateur.addUtilisateur(u);
        }

        public void methodAddFilm(Film f)
        {
            film.addFilm(f);
        }

        public List<Utilisateur> methodGetAllUtilisateur()
        {
            return utilisateur.getAllUtilisateur();
        }

        public List<Film> methodGetAllFilm()
        {
            return film.getAllFilm();
        }
    }
}

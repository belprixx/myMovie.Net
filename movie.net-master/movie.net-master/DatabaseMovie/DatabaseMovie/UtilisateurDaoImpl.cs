using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMovie
{
    class UtilisateurDaoImpl : UtilisateurDao
    {
        List<Utilisateur> lesUtilisateurs;
        Model1Container ctx;
        public UtilisateurDaoImpl()
        {
            ctx = new Model1Container();
            lesUtilisateurs = ctx.UtilisateurSet.ToList();
            if (lesUtilisateurs.LongCount() <= 0)
            {
                Utilisateur test = new Utilisateur();
                test.login = "test1";
                lesUtilisateurs.Add(test);
            }
        }

        public void deleteUtilisateur(Utilisateur utilisateur)
        {
            ctx.UtilisateurSet.Remove(utilisateur);
            lesUtilisateurs.Remove(utilisateur);
            ctx.SaveChanges();
        }

        public List<Utilisateur> getAllUtilisateur()
        {
            lesUtilisateurs = ctx.UtilisateurSet.ToList();
            return lesUtilisateurs;
        }

        public Utilisateur getUtilisateur(int id)
        {
            return ctx.UtilisateurSet.ElementAt(id);
        }

        public void updateUtilisateur(Utilisateur utilisateur)
        {
            lesUtilisateurs[utilisateur.Id].login = utilisateur.login;
            ctx.Entry(utilisateur).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void addUtilisateur(Utilisateur u)
        {
            int stateSaveChange;
            List<Utilisateur> testListUtilisateur = getAllUtilisateur();
            Console.WriteLine("User add :" + u.login);
            lesUtilisateurs.Add(u);
            ctx.UtilisateurSet.Add(u);
            ctx.Entry(u).State = System.Data.Entity.EntityState.Added;
            try
            {
                stateSaveChange = ctx.SaveChanges();
                Console.WriteLine("stateSaveChange : " + stateSaveChange);
            } catch (DbEntityValidationException e)
            {
                foreach(var eve in e.EntityValidationErrors)
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

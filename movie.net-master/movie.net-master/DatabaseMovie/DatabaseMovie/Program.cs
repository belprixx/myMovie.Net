using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1Container ctx = new Model1Container();

            Utilisateur user = new Utilisateur();
            user.login = "Admin";

            //ctx.UtilisateurSet.Add(user);
            //ctx.SaveChanges();
        }
    }
}

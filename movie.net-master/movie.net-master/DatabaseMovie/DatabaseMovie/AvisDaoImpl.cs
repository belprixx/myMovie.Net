using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMovie
{
    class AvisDaoImpl : AvisDao
    {
        List<Avis> lesAvis;
        Model1Container ctx;
        public AvisDaoImpl()
        {
            ctx = new Model1Container();
            lesAvis = ctx.AvisSet.ToList();
            if (lesAvis.LongCount() <= 0)
            {
                Avis test = new Avis();
                test.Commentaire = "test1";
                lesAvis.Add(test);
            }
        }

        public void deleteAvis(Avis avis)
        {
            ctx.AvisSet.Remove(avis);
            lesAvis.Remove(avis);
            ctx.SaveChanges();
        }

        public List<Avis> getAllAvis()
        {
            return lesAvis;
        }

        public Avis getAvis(int id)
        {
            return ctx.AvisSet.ElementAt(id);
        }

        public void updateAvis(Avis avis)
        {
            lesAvis[avis.Id].Commentaire = avis.Commentaire;
            ctx.Entry(avis).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}

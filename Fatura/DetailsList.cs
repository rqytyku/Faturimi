using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatura
{
    public class DetailsList
    {
        //Lista e faturavee per nje date
        public IList<Fatura> FaturaPerNjeDateTeCaktuar(DateTime dataeFatures)
        { 
            StoreManagmentEntities context = new StoreManagmentEntities();
            return context.Faturas.Where(x=>x.OrderDate == dataeFatures).ToList();
        }


        //Lista e te gjitha faturave
        public IList<Fatura> ListaFaturave()
        {
            StoreManagmentEntities context = new StoreManagmentEntities();
            return context.Faturas.ToList();
        }
        public Fatura FaturaDetails(int ID )
        {
            StoreManagmentEntities context = new StoreManagmentEntities();
            return context.Faturas.Where(x => x.Fatura_ID == ID).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fatura
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            DetailsList details = new DetailsList();

            var listaefaturave = details.ListaFaturave();


           

            // Shtimi dhe ruajtja ne Database
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("A doni te shtoni nje fature te re? Po/Jo");
            string answer = Console.ReadLine();
            if (answer == "Po")
            {
                var context = new StoreManagmentEntities();
                var invoice = new Fatura()
                {

                    ProductID = 102,
                    CustomerID = 1,
                    OrderDate = DateTime.Now

                };
                context.Faturas.Add(invoice);
                context.SaveChanges();

                Console.WriteLine("Fatura u ruajt me sukses");
            }
            else
                Console.WriteLine("Ju vendoset te mos shtoni fature te re.");
                Console.WriteLine("-----------------------------------------");

            //Listimi i faturave

            if (listaefaturave.Any())
            {
                foreach (var item in listaefaturave)
                {
                    Console.WriteLine($"IdFature: {item.Fatura_ID}");
                    //Console.WriteLine($"Emer produkt: {item.Produkt.Product_Name}");
                }
            }
            else
            {
                Console.WriteLine("Nuk u gjet asnje fature");
            }
            // Detajet e fatures
            Console.WriteLine("Jep nr e fatures");

            int id = Convert.ToInt32(Console.ReadLine());
           
            var fatura = details.FaturaDetails(id);

            try
            {
                Console.WriteLine($"Detajet e fatures:");
                Console.WriteLine($"ID e fatures: {fatura.Fatura_ID}");
                Console.WriteLine($"ID e konsumatorit: {fatura.CustomerID}");
                Console.WriteLine($"ID e produkutit: {fatura.ProductID}");
                Console.WriteLine($"Produktit: {fatura.Produkt.Product_Name}");
                Console.WriteLine($"Shuma: {fatura.Produkt.Cost}");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(" Fatura nuk ekziston");
                throw (ex);
            }
            

            ////////////////////// Shtimi dhe ruajtja ne Database
            ////////////////////Console.WriteLine("-----------------------------------------");
            ////////////////////var context = new StoreManagmentEntities();
            ////////////////////var invoice = new Fatura()
            ////////////////////{
            ////////////////////    Fatura_ID = 1005,
            ////////////////////    OrderDate = DateTime.Now,
            ////////////////////    Total = 250,
                
            ////////////////////    ProductID = 102
            ////////////////////};
            ////////////////////context.Faturas.Add(invoice);
            ////////////////////context.SaveChanges();
            ////////////////////Console.WriteLine($"Fatura e re: {invoice.Fatura_ID}");
            ////////////////////Console.ReadKey();
        }
    }
}

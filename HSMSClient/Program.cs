using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HSMSWebService;

namespace HSMSClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Opcije: ");
            Console.WriteLine("     0 - preuzmi sve akcije");
            Console.WriteLine("     1-3 prioritet akcija");
            Console.Write("Vas izbor: ");
            
            int priority = Int32.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Povezivanje sa servisom...");
            Console.WriteLine();
            HSMSServiceClient service = new HSMSServiceClient();
            HSMS[] array;

            if (priority == 0)
            {
                array = service.GetAllActions();
            }
            else
            {
                array = service.GetActionsByPriority(priority);
            }

            string header = string.Format("{0,-5}{1,-60}{2,-10}{3,-15}{4,-40}{5,15}","ID","AKCIJA","BROJ","CENA SMS-a","ORGANIZACIJA","PRIORITET");
            Console.WriteLine("===================================================================================================================================================");
            Console.WriteLine(header);
            Console.WriteLine("===================================================================================================================================================");
            Console.WriteLine();

            foreach(HSMSWebService.HSMS h in array) 
            {
                string row = string.Format("{0,-5}{1,-60}{2,-10}{3,-15}{4,-40}{5,15}", h.ID, h.Desc, h.Number, h.Price, h.Organisation, h.Priority);
                Console.WriteLine(row);
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------");
            }

            service.Close();
            Console.ReadLine();
        }
    }
}

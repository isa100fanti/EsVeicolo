using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsBolloAuto
{
    class GestioneVeicolo
    {
        /* app deve consentire:
             * -aggiungere veicolo lista
             * -rimuovere veic lista
             * -calcolare costo bollo
             * 
             * costo bollo: 
             * -EURO 1 2,90e fino a 100kw e 4,35euro oltre
             * -EURO 2 2,80 fino a 100kw e 4,20 oltre
             * -EURO 3 2,70e fino a 100kw e 4,05 oltre
             * -EURO 4 o > 2,58e fino a 100kw e 3,87 oltre
             * 
             * stampa a video e su file i dettagli veicolo + costo bollo
             * gestire imput da utente
             */

        //ANTONIA
        internal static Veicolo InserisciVeicolo()
        {
            Veicolo veicolo = new Veicolo();

            try
            {
                bool success;
                Console.WriteLine("aggiungi un veicolo");
                Console.WriteLine("aggiungi marca, kw, tipo euro(1,2,3,4 o +), prezzo");
                veicolo.TipoEuro = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("aggiungi la marca");
                veicolo.Marca = Console.ReadLine();
                Console.WriteLine("aggiungi i kw");
                //ho creato un metodo apposta per verificare la conversione da string a int!perchè ho due val int
                veicolo.Kw = VerificaInputIntero();
                Console.WriteLine("aggiungi l'anno di immatricolazione");
                veicolo.AnnoImmatricolazione = VerificaInputIntero();
                Console.WriteLine("il prezzo del veicolo");
                success = Double.TryParse(Console.ReadLine(), out double costo);
                while (!success)
                {
                    Console.WriteLine("inserisci un valore corretto");
                    costo = Convert.ToDouble(Console.ReadLine());
                }

                veicolo.Prezzo = costo;
                
                //Esempio con gli ENUM
                //int[] values = new int[] { 0, 1, 2, 3 };
                //foreach(int enumValue in values)
                //{
                //    Console.WriteLine(Enum.GetName(typeof(TipoEuro), enumValue));
                //}
                //success = Enum.TryParse(Console.ReadLine(), out TipoEuro tipo);
                //veicolo.TipoEuro = tipo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return veicolo;
        }

        //funzione per evitare di ripetere le conversioni col tryparse!
        public static int VerificaInputIntero()
        {
            bool success = Int32.TryParse(Console.ReadLine(), out int value); //value generico
            while (!success)
            {
                Console.WriteLine("inserisci un valore corretto");
                success = Int32.TryParse(Console.ReadLine(), out value);

            }
            return value; //ho generalizzato il controllo di input sugli interi!
        }

    //MIO
    public static void AggiungiVeicolo(ArrayList lista)
        {
            Veicolo v = new Veicolo();

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                "listaVeicolo.txt");
            try
            {
                using(StreamWriter writer = File.CreateText(path))
                {
                   
                    Console.WriteLine("aggiungi un veicolo");
                    Console.WriteLine("aggiungi marca, kw, tipo euro(1,2,3,4 o +), prezzo");
                    string veicolo = Console.ReadLine();
                    Console.WriteLine("aggiungi la marca");
                    v.Marca = Console.ReadLine();
                    Console.WriteLine("aggiungi i kw");
                    v.Kw = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("indica se è euro 1,2,3,4 o superiore");
                    v.TipoEuro = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("il prezzo del veicolo");
                    v.Prezzo = Convert.ToDouble(Console.ReadLine());
                    
                    lista.Add(v);
                    Console.WriteLine("veicolo aggiunto!");

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

        public static void EliminaVeicolo(ArrayList lista)
        {
            Veicolo v = new Veicolo();
            int r = 0;
            Console.WriteLine("scegli la posizione da eliminare");
            
            foreach(Veicolo item in lista)
            {
                r = Convert.ToInt32(Console.ReadLine());
                lista.RemoveAt(r);
            }

            


        }

        public static void StampaVeicolo(ArrayList lista)
        {
            foreach (Veicolo veicolo in lista)
            {
                Console.WriteLine(veicolo);
            }
        }

        public static Veicolo CercaVeicolo(ArrayList veicoli)
        {
            Console.WriteLine("cerca il veicolo inserendo marca e anno immatricolazione");
            string marca = Console.ReadLine();
            int anno = VerificaInputIntero();
            
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                "listaVeicolo.txt");
         foreach(Veicolo veicolo in veicoli)
            {
                if(veicolo.Marca == marca && veicolo.AnnoImmatricolazione == anno)
                {
                    return veicolo;
                }else
                {
                    Console.WriteLine("non l'ho trovato,ritenta");
                    
                }

            }
            return null;
        }


    }
}

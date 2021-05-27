using System;
using System.Collections;

namespace Week2.EsBolloAuto
{
    class Program
    {
        static void Main(string[] args)
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
            ArrayList veicoli = new ArrayList();
            int opzione = Program.Menu();
            while (opzione != 5)
            {
                Program.Scelta(opzione,veicoli);

                opzione = Program.Menu();
            }
                
        }

        public static int Menu()
        {
            Console.WriteLine("Ciao!cosa vuoi fare?");
            Console.WriteLine("1- aggiungi un veicolo");
            Console.WriteLine("2-rimuovi un veicolo");
            Console.WriteLine("3- stampa un veicolo");

            Console.WriteLine("4- calcola costo bollo veicolo");
            Console.WriteLine("5-esci");
            int scelta =0;
            try
            {
                scelta = Convert.ToInt32(Console.ReadLine());
            }catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n inserisci un valore valido!");
                
            }


            return scelta;
        }

        public static void Scelta(int opzione, ArrayList veicoli)
        {
            switch(opzione)
            {
                case 1:
                    GestioneVeicolo.AggiungiVeicolo(veicoli);
                    //posso anche ottenere il veicolo 
                    //Veicolo veicolodaaggiungere =GestioneVeicolo.AggiungiVeicolo();
                    //veicoli.Add(veicolodaaggiungere)
                    break;
                case 2://per cancellare da file
                    GestioneVeicolo.EliminaVeicolo(veicoli);
                    
                    //oppure: lo cerco prima (con l'indice),lo trovo e lo cancello
                    //Veicolo veicolodacancellare =GestioneVeicolo.CercaVeicolo();
                    //try{
                    //veicoli.Remove(veicolodacancellare)
                    //}

                    break;
                case 3:
                    GestioneVeicolo.StampaVeicolo(veicoli);
                    
                    break;
                case 4://calcola bollo
                    VeicoliIO.StampaSuFile(veicoli);
                    break;
                case 5:
                    Console.WriteLine("esci");
                    break;
                default:
                    Console.WriteLine("non conosco il comando");
                    break;
            }

        }
        
        //public static string InserisciVeicolo()
        //{
        //    Console.WriteLine("aggiungi un veicolo");
        //    Console.WriteLine("aggiungi marca, kw, tipo euro(1,2,3,4 o +), prezzo");
        //    string veicolo = Console.ReadLine();
        //    //Console.WriteLine("aggiungi la marca");
        //    //v.Marca = Console.ReadLine();
        //    //Console.WriteLine("aggiungi i kw");
        //    //v.Kw = Convert.ToInt32(Console.ReadLine());
        //    //Console.WriteLine("indica se è euro 1,2,3,4 o superiore");
        //    //v.TipoEuro = Convert.ToInt32(Console.ReadLine());
        //    //Console.WriteLine("il prezzo del veicolo");
        //    //v.Prezzo = Convert.ToDouble(Console.ReadLine());




        //    return veicolo;
        //}


    }
}

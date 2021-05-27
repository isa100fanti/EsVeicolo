using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsBolloAuto
{
    class Veicolo
    {
        public string Marca { get; set; }
        public int Kw { get; set; }
        public int TipoEuro { get; set; }
        public int AnnoImm { get; set; }
        public double Prezzo { get; set; }
        
        public int AnnoImmatricolazione { get; set; }
        public double Bollo {  get { return CostoBollo(); } }
        //chiama il get di bollo!e calcola in automatico il costo
        public double CostoBollo()
        {
            double costo = 0;
            if(TipoEuro ==1)
            {
                if (Kw <= 100)
                    costo = 2.90;
                else
                    costo = 4.35;
            }
            else if (TipoEuro == 2)
            {
                if (Kw <= 100)
                    costo = 2.80;
                else
                    costo = 4.20;
            }
            else if (TipoEuro == 3)
            {
                if (Kw <= 100)
                    costo = 2.70;
                else
                    costo = 4.05;
            }
            else if (TipoEuro >= 4)
            {
                if (Kw <= 100)
                    costo = 2.58;
                else
                    costo = 3.87;
            }
            
            return costo;
        }

        public override string ToString()
        {
            return $"Marca {Marca}, Kw: {Kw}, Euro {TipoEuro}," +
                $" Prezzo {Prezzo} euro, Costo Bollo {Bollo} ";
        }

    }
}

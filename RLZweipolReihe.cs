/*
 Eigene RLZweipol Klase zur Dimensionierung / Erstellung eines RLZweipols


 */

//entweder "using Praktikum;" einbinden als Bibliothek oder
//"namespace Praktikum" verwenden um die Spulenklasse verwenden zu können
namespace Praktikum //hier wurde der namepace verwendet
{
    internal class RLZweipolReihe
    {
        //Felder -> Private Variablen
        //Felder in Private!
        private double f;
        private double r;
        private Spule sp; //Membervariable

        //Properties in Public
        public double F
        {
            get => f; //Lesezugriff

            set //Schreibzugriff und Eingabeüberprüfung mit Exceptions
            {
                if (value < 0) f = (value * (-1));
                else f = value;

                if (value == 0) f = 1;
                else f = value;
            }
        }

        public double R
        {
            get => r; //Lesezugriff

            set //Schreibzugriff
            {
                if (value < 0) r = (value * (-1));
                else r = value;

                if (value == 0) r = 1;
                else r = value;

            }
        }

        public Spule Sp //Property in Public, auf diese soll zugegriffen werden
        {
            get => sp; //Lesezugriff

            set //Schreibzugriff
            {
                sp = value;
            }
        }

        /// <summary>
        /// Allgemeiner, Parametrisierter Konstruktor
        /// </summary>
        /// <param name="r"></param>
        /// <param name="l"></param>
        /// <param name="bauForm"></param>
        /// <param name="f"></param>
        public RLZweipolReihe(double r, double l, string bauForm, double f) //Wegen dieser Vorgabe ist der default Konstruktor wichtig!
        {
            F = f;
            R = r;
            Sp = new Spule(l, bauForm); //nur möglich über den Default Konstruktor, der Allggemeine wird hier nicht verwendet
            //da ansonsten die 2 anderen Parameter von Spule auch initialisiert werden müssten
        }

        //Methoden

        public double GetKreisFrequenz()
        {
            double w;
            w = 2 * (Math.PI) * f;
            return w; 
        }

        public double GetZBetrag()
        {
            double ZBetrag;
            double buffer;

            //Holen der Werte aus den anderen Methoden
            double ZReal = GetZReal();
            double ZImag = GetZImag();

            //Berechnung des Betrages
            buffer = (ZReal * ZReal) + (ZImag * ZImag);
            ZBetrag = Math.Sqrt(buffer);

            return ZBetrag;
        }

        public double GetZImag()
        {
            double ZImag;
            ZImag = 1 / (2 * (Math.PI) * f * sp.Induktivitaet);

            return ZImag;
        }

        public double GetZReal()
        {
            double ZReal;

            ZReal = r;

            return ZReal;
        }

    }
}

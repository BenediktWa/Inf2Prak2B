/*
 Praktikum 2 der Gruppe 2B
Hier folgen Konsolenausgaben!, welche nicht in den anderen Klassen zur wiederverwendbarkeit erfolgen dürfen
 */

namespace Praktikum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Deklaration der Variablen für das Einlesen von Daten eines RL-
            //Reihen-Zweipols
            //Variablen: r, l, f, buffer (für Eingabeüberprüfung numerischer
            //Eingaben), eingabe;
            string buffer;
            string eingabe;
            string bau;
            double r, l, f;
            bool ok; //Für Tryparse
            RLZweipolReihe z = null; //RLZweipolReihe Variable für die spätere Erzeugung

            Console.WriteLine("Einen neuen Zweipol erzeugen [j/n]?");
            eingabe = Console.ReadLine();

            while (eingabe.ToLower().Trim() == "j")
            {
                Console.Clear();
                //Benutzer-Interaktion
                //Ausgabe: "Einen neuen RL-Zweipol erzeugen"
                Console.WriteLine("\n*** Einen neuen RL-Zweipol erzeugen ***");

                do
                {
                    Console.Write("\nZweipol-Widerstand R [Ohm]: ");
                    buffer = Console.ReadLine();
                    buffer.Replace('.', ',');
                    ok = double.TryParse(buffer, out r); //Wenn umgewandelt werden kann in double dann true, wenn nicht dann false
                } while (!ok);

                do
                {
                    Console.Write("\nZweipol-Spulen-Induktivitaet [mH]: ");
                    buffer = Console.ReadLine();
                    buffer = buffer.Replace('.', ','); //macht aus einem Punkt ein Komma, da anonsten bei 0.88 -> 88,0 kommt
                    ok = double.TryParse(buffer, out l);
                } while (!ok);

                do
                {
                    Console.Write("\n\nZweipol-Frequenz f [Hz]: ");
                    buffer = Console.ReadLine();
                    buffer = buffer.Replace('.', ',');
                    ok = double.TryParse(buffer, out f);
                } while (!ok);

                do
                {
                    Console.Write("\n\nSpulen-Bauform: ");
                    bau = Console.ReadLine();
                    if (bau.Length < 1 || bau == "")
                    {
                        ok = false;
                    }
                    else
                    {
                        ok = true;
                    }

                } while (!ok);

                z = new RLZweipolReihe(r, l, bau, f);

                PrintData(z);

                Console.WriteLine("Einen neuen Zweipol erzeugen [j/n]? ");
                eingabe = Console.ReadLine();
                //Achtung: Induktivität wird in Milli-Henry eingegeben und muss
                //beim Anlegen der Objekt-Variable in Henry umgewandelt werden!!
                //Eingaben mit do-while-Schleifen zur Überprüfung der
                //numerischen Eingaben.
                //Anlegen einer Objektvariablen der Klasse RLZweiPolReihe
                //Aufruf der statischen Methode  ausgabe()
                //Abfrage, ob Erzeugung eines RL-Zweipols wiederholt werden soll
            }//while
            return;

        }//Main

        public static void PrintData(RLZweipolReihe z)
        {

            //Variablen für die Einheiten
            string Ohm = "Ohm";
            string mH = "mH";
            string fre = "1/s";

            //Ausgabe Kopfzeile
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("            Bauelementewerte            ");
            Console.WriteLine("----------------------------------------");

            //Ausgabe der Werte des Objektes inklusive Formatierung und ausgebende Stellen
            Console.WriteLine("Widerstandswert__:{0,20:F2}{1,4}", z.R, Ohm);
            Console.WriteLine("Induktivitätwert :{0,20:F2}{1,4}", (z.Sp.Induktivitaet), mH); //Ausgabe Member
            Console.WriteLine("Kreisfrequenz____:{0,20:F2}{1,4}", (z.GetKreisFrequenz()), fre); //Methode der Klasse (return)
            Console.WriteLine();

            //Ausgabe Kopfzeile
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("   Komplexer Widerstand des Zweipols    ");
            Console.WriteLine("----------------------------------------");

            //Ausgabe der Werte des Objektes inklusive Formatierung und ausgebende Stellen
            Console.WriteLine("Betrag :{0,28:F2}{1,4}", (z.GetZBetrag()), Ohm);//Methode der Klasse (return)
            Console.WriteLine("Re-Teil:{0,28:F2}{1,4}", (z.GetZReal()), Ohm);//Methode der Klasse (return)
            Console.WriteLine("Im-Teil:{0,28:F2}{1,4}", (z.GetZImag()), Ohm);//Methode der Klasse (return)
            Console.WriteLine();


        }

    }//Program

}//Namespace

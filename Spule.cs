/*
 Eigene Spulenklasse
Programmiert für Praktikum 1B, nun weitere Verwendung

Autor: Benedikt Walessa
Letzte Änderung: 28.06.23
*/

using System;

namespace Praktikum
{
    internal class Spule
    {
        //Private Variablen auf welche nicht zugegriffen werden kann
        //Felder der Spule
        private string bauform;
        private double induktivitaet;
        private double relPermeabilitaet;
        private int windungszahl;


        //Properties
        public string Bauform
        {
            get => bauform; //Leezugriff

            set //Schreibzugrif und Gleichzeitig Kontrolle, hier werden die Exceptions geworfen!
            {
                if (value != null && value.Length > 0)
                {
                    bauform = value;
                }
            }
        }

        public double Induktivitaet
        {
            get => induktivitaet; //Lesezugriff

            set //Schreibzugriff
            {
                if (value < 0)
                {
                    induktivitaet = (value * (-1));
                }
                else induktivitaet = value;

                if (value == 0)
                {
                    induktivitaet = 1;
                }
                else induktivitaet = value;

            }
        }

        public double RelPermeabilitaet
        {
            get => relPermeabilitaet;

            set
            {
                relPermeabilitaet = value;
            }
        }

        public int Windungszahl
        {
            get => windungszahl;

            set
            {
                windungszahl = value;
            }
        }

        /// <summary>
        /// Konstruktor ist in Public und trägt den Selben Namen wie die Klase
        /// Dieser ist ein allgemeiner und parametrisierter Konstruktor
        /// </summary>
        /// <param name="ind"></param>
        /// <param name="bf"></param>
        /// <param name="permrel"></param>
        /// <param name="windzahl"></param>
        public Spule(double ind, string bf, double permrel, int windzahl)
        {
            //Objekt wird zuerst initialisiert über die Property (Bauform) und dann in die Variable (bauform) eingefügt
            //So ist es möglich die Eingabe zu übeerprüen
            Bauform = bf;
            Induktivitaet = ind;
            RelPermeabilitaet = permrel;
            Windungszahl = windzahl;
        }

        /// <summary>
        /// Default Konstruktor
        /// </summary>
        /// <param name="ind"></param>
        /// <param name="bf"></param>
        public Spule(double ind, string bf)
        {
            //Induktivität und Bauform werden bei erzeugung von RLZweipol angefordert
            Bauform = bf;
            Induktivitaet = ind;
            //Durch die Deault initialisierung hier müssen später nur 2 Parameter initialisiert weerden im RLZweipol
            RelPermeabilitaet = 1;
            Windungszahl = 1;

        }


        //Hier würden Methoden der Klasse folgen

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Implementacja_interfejsow
{
    class Pracownik
    {
        private string _nazwisko;
        private DateTime _dataZatrudnienia;
        private decimal _wynagrodzenie;

        public string Nazwisko {
            get => _nazwisko;  
            set => _nazwisko = value.Trim(); 
        }

        public DateTime DataZatrudnienia {
            get => _dataZatrudnienia;
            set
            {
                DateTime thisDay = DateTime.Today;
                if (value <= thisDay) _dataZatrudnienia = value; else throw new ArgumentException();
            }
        }

        public decimal Wynagrodzenie {
            get => _wynagrodzenie;
            set => _wynagrodzenie = (value < 0) ? 0 : value;
        }

        public int CzasZatrudnienia => (DateTime.Now - DataZatrudnienia).Days / 30;

        public Pracownik(string nazwisko, DateTime dataZatrudnienia, decimal wynagrodzenie)
        {
            Nazwisko = nazwisko;
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }

        public Pracownik()
        {
            DateTime thisDay = DateTime.Today;

            _nazwisko = "Anonim";
            _dataZatrudnienia = thisDay;
            _wynagrodzenie = 0;
        }

        public override string ToString() => $"({Nazwisko}, {DataZatrudnienia:d MMM yyyy}, ({CzasZatrudnienia}) {Wynagrodzenie} PLN)";
    }
}

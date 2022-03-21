using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Implementacja_interfejsow
{
    class Pracownik : IEquatable<Pracownik>
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

        public override bool Equals(object value)
        {
            // Is null?
            if (Object.ReferenceEquals(null, value))
            {
                return false;
            }

            // Is the same object?
            if (Object.ReferenceEquals(this, value))
            {
                return true;
            }

            // Is the same type?
            if (value.GetType() != this.GetType())
            {
                return false;
            }

            return IsEqual((Pracownik)value);
        }
        public bool Equals(Pracownik pracownik)
        {
            // Is null?
            if (Object.ReferenceEquals(null, pracownik))
            {
                return false;
            }

            // Is the same object?
            if (Object.ReferenceEquals(this, pracownik))
            {
                return true;
            }

            return IsEqual(pracownik);
        }

        private bool IsEqual(Pracownik pracownik)
        {
            // A pure implementation of value equality that avoids the routine checks above
            // We use String.Equals to really drive home our fear of an improperly overridden "=="
            return String.Equals(Nazwisko, pracownik.Nazwisko)
                && String.Equals(DataZatrudnienia, pracownik.DataZatrudnienia)
                && String.Equals(Wynagrodzenie, pracownik.Wynagrodzenie);
        }
    }

   
}

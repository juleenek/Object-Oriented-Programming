﻿using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PojazdyLib.Powietrzne
{
    public class HangGlider : AirVehicle // Lotnia
    {
        private FuelType fuelType = FuelType.none;
        private int enginePower = 0;
        public new bool HasAnEngine => false;
        public new FuelType FuelType { get => fuelType; }
        public new int EnginePower { get => enginePower; }
        public HangGlider()
        {
        }
        public override string ToString() =>
            $"Pojazd: Lotnia \n" +
            $"Typ pojazdu: {VehicleType} \n" +
            $"Aktualne środowisko: {Environment} \n" +
            $"Aktualny stan: {State} \n" +
            $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
            $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
            $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
            $"Czy posiada silnik: {HasAnEngine} \n";
    }
}

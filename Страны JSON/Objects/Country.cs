﻿using System.Collections.Generic;

namespace Страны_JSON
{
    internal class Country
    {
        public string Name { get; set; }
        public string[] TopLevelDOmain { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string[] CallingCodes { get; set; }
        public string Capital { get; set; }
        public string[] AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public int Population { get; set; }
        public double[] Latlng { get; set; }
        public string Demonym { get; set; }
        public double? Area { get; set; }
        public string Gini { get; set; }
        public string[] Timezones { get; set; }
        public string[] Borders { get; set; }
        public string NativeName { get; set; }
        public string NumericCode { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Language> Languages { get; set; }
        public Translation Translations { get; set; }
        public string Flag { get; set; }
        public List<RegionalBlock> RegionalBlocks { get; set; }
        public string Cioc { get; set; }
    }
}
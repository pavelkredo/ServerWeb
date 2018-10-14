using System.Collections.Generic;

namespace Страны_JSON
{
    internal class RegionalBlock
    {
        public string Acronym { get; set; }
        public string Name { get; set; }
        public List<RegionalBlock> OtherAcronyms { get; set; }
        public string[] OtherNames { get; set; }
    }
}
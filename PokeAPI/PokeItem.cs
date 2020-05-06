using System;
using System.Collections.Generic;
using System.Text;

namespace PokeAPI
{
    class PokeItem
    {

        public PokeItem(string name)
        {
            Name = name;
        }
        //Your Properties are auto-implemented.
        public string Name { get; set; }
    }
}

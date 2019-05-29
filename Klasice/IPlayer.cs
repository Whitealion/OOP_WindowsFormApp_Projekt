using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Klasice
{
    //public enum PlayerPosition
    //{
    //    Goalie,
    //    Defender,
    //    Midfield,
    //    Forward
    //}

    public interface IPlayer : IEnumerable
    {
        string Name { get; set; }
        bool Captain { get; set; }
        string Shirt_Number { get; set; }
        string Position { get; set; }
        bool Favourite { get; set; }

        string FormatForFile();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Klasice
{
    public static class Data
    {
        public enum Language
        {
            English,
            Hrvatski
        }

        public class Team : IEnumerable
        {
            public string Id { get; set; }
            public string Country { get; set; }
            public string Alternate_Name { get; set; }
            public string Fifa_Code { get; set; }
            public string Group_Id { get; set; }
            public string Group_Letter { get; set; }
            public string FormattedName
            {
                get
                {
                    return $"{Country} ({Fifa_Code})";
                }
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }

            public override string ToString()
            {
                return $"{Id}|{Country}|{Alternate_Name}|{Fifa_Code}|{Group_Id}|{Group_Letter}";
            }
        }

        public class Player : IEnumerable
        {
            //WIP

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }
        }
    }
}

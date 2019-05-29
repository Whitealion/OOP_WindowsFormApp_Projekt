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

        public class Weather
        {
            public int Humidity { get; set; }
            public int Temp_Celsius { get; set; }
            public int Temp_Farenheit { get; set; }
            public int Wind_Speed { get; set; }
            public string Description { get; set; }
        }

        public class TeamPerMatch
        {
            public string Country { get; set; }
            public string Code { get; set; }
            public int Goals { get; set; }
            public int Penalties { get; set; }
        }

        public class TeamEvent
        {
            public int Id { get; set; }
            public string Type_Of_Event { get; set; }
            public string Player { get; set; }
            public string Time { get; set; }
        }

        public class Player : IPlayer
        {
            public string Name { get; set; }
            public bool Captain { get; set; }
            public string Shirt_Number { get; set; }
            public string Position { get; set; }
            public bool Favourite { get; set; }

            public string FormatForFile()
            {
                return $"{Name}|{Captain}|{Shirt_Number}|{Position}";
            }

            public override string ToString()
            {
                return $"{Name} | {Shirt_Number} | {Position}\n" +
                    $"Captain: {Captain.ToString()}";
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }
        }

        public class TeamStatistics
        {
            public string Country { get; set; }
            public int Attempts_On_Goal { get; set; }
            public int On_Target { get; set; }
            public int Off_Target { get; set; }
            public int Blocked { get; set; }
            public int Woodwork { get; set; }
            public int Corners { get; set; }
            public int Offsides { get; set; }
            public int Ball_Possession { get; set; }
            public int Pass_Accuracy { get; set; }
            public int Num_Passes { get; set; }
            public int Passes_Completed { get; set; }
            public int Distance_covered { get; set; }
            public int Balls_Recovered { get; set; }
            public int Tackles { get; set; }
            public int Clearences { get; set; }
            public int Yellow_Cards { get; set; }
            public int Red_Cards { get; set; }
            public int Fouls_Comitted { get; set; }
            public string Tactics { get; set; }
            public Player[] Starting_Eleven { get; set; }
            public Player[] Substitutes { get; set; }
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

            public string FormatForFile()
            {
                return $"{Id}|{Country}|{Alternate_Name}|{Fifa_Code}|{Group_Id}|{Group_Letter}";
            }
        }

        public class Match
        {
            public string Venue { get; set; }
            public string Location { get; set; }
            public string Status { get; set; }
            public string Fifa_Id { get; set; }
            public Weather Weather { get; set; }
            public int Attendance { get; set; }
            public string[] Officials { get; set; }
            public string Stage_Name { get; set; }
            public string Home_Team_Country { get; set; }
            public string Away_Team_country { get; set; }
            public DateTime dateTime { get; set; }
            public string Winner { get; set; }
            public string Winner_Code { get; set; }
            public TeamPerMatch Home_Team { get; set; }
            public TeamPerMatch Away_Team { get; set; }
            public TeamEvent[] Home_Team_Events { get; set; }
            public TeamEvent[] Away_Team_Events { get; set; }
            public TeamStatistics Home_Team_Statistics { get; set; }
            public TeamStatistics Away_Team_Statistics { get; set; }
        }
        
        //public class Player : IPlayer
        //{
        //    public string Name { get; set; }
        //    public bool Captain { get; set; }
        //    public string Shirt_Number { get; set; }
        //    public string Position { get; set; }

        //    public IEnumerator GetEnumerator()
        //    {
        //        return (IEnumerator)this;
        //    }

        //    public string FormatForFile()
        //    {
        //        return $"{Name}|{Captain}|{Shirt_Number}|{Position}";
        //    }
        //}

    }
}

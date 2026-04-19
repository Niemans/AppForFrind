using ForJakub.core;
using ForJakub.gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static ForJakub.gateway.CsvGameColumnNames;

namespace ForJakub.gateway
{
    internal class CsvGameColumnNames : INames<Names>
    {
        private static readonly Dictionary<Names, string> friendlyNames = new()
        {
            { Names.GameID, "Game GameID" },
            { Names.Time, "Game Time" },
            { Names.Comment, "Comment" },

            { Names.PlayerID, "Player GameID" },
            { Names.PlayerName, "Player Name" },
            { Names.PlayerCurrentPoints, "Player Current Points" },

            { Names.PointsGain, "Points Gain" },
            { Names.PlayerPlacement, "Player Placement" },
        };



        public static string GetFieldName(Names enumName) => enumName.ToString();

        public static string GetFriendlyName(Names enumName) => friendlyNames[enumName];

        public static List<string> GetFriendlyNames() => friendlyNames.Select(kv => kv.Value).ToList();

        public static List<string> GetFieldNames() => friendlyNames.Select(kv => kv.Key.ToString()).ToList();

        public enum Names
        {
            GameID,
            Time,
            Comment,

            PlayerID,
            PlayerName,
            PlayerCurrentPoints,
            
            PointsGain,
            PlayerPlacement,
        }
    }
}

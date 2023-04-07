using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DestinyMauiApp.DestinyData
{
    public class CommonDataClasses
    {
        public class DisplayProperty
        {
            public string description;
            public string name;
            public bool hasIcon;
            public string icon;
        }
        public class BackgroundColor
        {
            public int colorHash;
            public int red;
            public int green;
            public int blue;
            public int alpha;
        }
        public class Action
        {
            public string verbName;
            public string verbDescription;
            public bool isPositive;
            public int requiredCooldownSeconds;
        }
    }

    public class CommonDataClassHelperMethods
    {
        public static bool LoadDisplayProperties(ref Utf8JsonReader reader, ref CommonDataClasses.DisplayProperty properityItem)
        {
            // Second item is the display properties object
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    // Done here
                    return true;
                }
                else if (reader.TokenType == JsonTokenType.StartObject)
                {
                    continue;
                }

                string keyValueStr = reader.GetString();
                if (keyValueStr == "description")
                {
                    reader.Read();
                    properityItem.description = reader.GetString();
                }
                else if (keyValueStr == "name")
                {
                    reader.Read();
                    properityItem.name = reader.GetString();
                }
                else if (keyValueStr == "hasIcon")
                {
                    reader.Read();
                    properityItem.hasIcon = reader.GetBoolean();
                }
                else if (keyValueStr == "icon")
                {
                    reader.Read();
                    properityItem.icon = reader.GetString();
                }
            }

            return false;
        }

        public static bool LoadBackgroundColor(ref Utf8JsonReader reader, ref CommonDataClasses.BackgroundColor colorItem)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return true;
                }
                else if (reader.TokenType == JsonTokenType.StartObject)
                {
                    continue;
                }

                string keyValueStr = reader.GetString();
                if (keyValueStr == "colorHash")
                {
                    reader.Read();
                    colorItem.colorHash = reader.GetInt32();
                }
                else if (keyValueStr == "red")
                {
                    reader.Read();
                    colorItem.red = reader.GetInt32();
                }
                else if (keyValueStr == "green")
                {
                    reader.Read();
                    colorItem.green = reader.GetInt32();
                }
                else if (keyValueStr == "blue")
                {
                    reader.Read();
                    colorItem.blue = reader.GetInt32();
                }
                else if (keyValueStr == "alpha")
                {
                    reader.Read();
                    colorItem.alpha = reader.GetInt32();
                }
            }

            return false;
        }

        public static bool LoadAction(ref Utf8JsonReader reader, ref CommonDataClasses.Action actionItem)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return true;
                }
                else if (reader.TokenType == JsonTokenType.StartObject)
                {
                    continue;
                }

                string keyValueStr = reader.GetString();
                if (keyValueStr == "verbName")
                {
                    reader.Read();
                    actionItem.verbName = reader.GetString();
                }
                else if(keyValueStr == "verbDescription")
                {
                    reader.Read();
                    actionItem.verbDescription = reader.GetString();
                }
                else if(keyValueStr == "isPositive")
                {
                    reader.Read();
                    actionItem.isPositive = reader.GetBoolean();
                }
            }

            return false;
        }
    }
}

using Microsoft.Maui.Media;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DestinyMauiApp.DestinyData
{
    public class DestinyAchievements
    {
        private class Achievement
        {
            public CommonDataClasses.DisplayProperty displayProperty;
            public int acccumulatorThreshold;
            public int platformIndex;
            public Int64 hash;
            public int index;
            public bool redacted;
            public bool blacklisted;

            public Achievement()
            {
                displayProperty = new CommonDataClasses.DisplayProperty();
            }
        }

        private Dictionary<string, Achievement> m_Achivements = new();

        public DestinyAchievements()
        {
            InitializeFromJson();
        }

        public string GetNameOfAchievement(string key)
        {
            if(m_Achivements.ContainsKey(key))
            {
                return m_Achivements[key].displayProperty.name;
            }

            return "Invalid Key";
        }

        private bool InitializeFromJson()
        {
            string dataFileName = "C:\\Users\\nmdil\\source\\repos\\DestinyLocalTracker\\DestinyWindows\\DestinyMauiApp\\DestinyMauiApp\\DestinyData\\data\\DestinyAchievementDefinition.json";
            var readOnlySpan = new ReadOnlySpan<byte>(File.ReadAllBytes(dataFileName));

            Utf8JsonReader localJsonReader = new Utf8JsonReader(readOnlySpan);

            int startObjectCount = 0;
            string objectKey = "bad";
            string startObjectStr = "invalid";
            Achievement tempAchivement = null;
            bool foundTheEnd = false;
            while (localJsonReader.Read())
            {
                if (localJsonReader.TokenType == JsonTokenType.EndObject)
                {
                    if(foundTheEnd)
                    {
                        break;
                    }
                    if(tempAchivement != null)
                    {
                        m_Achivements.Add(objectKey, tempAchivement);
                    }

                    startObjectCount = 0;
                    foundTheEnd = true;
                    continue;
                }

                foundTheEnd = false;

                if (localJsonReader.TokenType == JsonTokenType.StartObject)
                {
                    startObjectCount++;
                    
                    localJsonReader.Read();
                    startObjectStr = localJsonReader.GetString();
                }
                else if(localJsonReader.TokenType == JsonTokenType.PropertyName)
                {
                    startObjectStr = localJsonReader.GetString();
                }

                // First Item is the Key for this Object
                if(startObjectCount == 1)
                {
                    objectKey = startObjectStr;
                    tempAchivement = new();
                }
                else if(startObjectStr == "displayProperties")
                {
                    if(!CommonDataClassHelperMethods.LoadDisplayProperties(ref localJsonReader, ref tempAchivement.displayProperty))
                    {
                        //TODO: Failed to load display properties. 
                        return false;
                    }
                }
                else if (startObjectStr == "acccumulatorThreshold")
                {
                    localJsonReader.Read();
                    tempAchivement.acccumulatorThreshold = localJsonReader.GetInt32();
                }
                else if (startObjectStr == "platformIndex")
                {
                    localJsonReader.Read();
                    tempAchivement.platformIndex = localJsonReader.GetInt32();
                }
                else if(startObjectStr == "hash")
                {
                    localJsonReader.Read();
                    tempAchivement.hash = localJsonReader.GetInt64();
                }
                else if(startObjectStr == "index")
                {
                    localJsonReader.Read();
                    tempAchivement.index = localJsonReader.GetInt32();
                }
                else if(startObjectStr == "redacted")
                {
                    localJsonReader.Read();
                    tempAchivement.redacted = localJsonReader.GetBoolean();
                }
                else if(startObjectStr == "blacklisted")
                {
                    localJsonReader.Read();
                    tempAchivement.blacklisted = localJsonReader.GetBoolean();
                }
            } // End of While loop

            return true;
        }

    }
}

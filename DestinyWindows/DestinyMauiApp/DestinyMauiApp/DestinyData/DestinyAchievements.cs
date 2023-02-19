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

                    startObjectCount = 1;
                    foundTheEnd = true;
                    continue;
                }

                foundTheEnd = false;

                if (localJsonReader.TokenType == JsonTokenType.StartObject)
                {
                    startObjectCount++;
                    continue;
                }

                // First Item is the Key for this Object
                if(startObjectCount == 1)
                {
                    objectKey = localJsonReader.GetString();
                    tempAchivement = new();
                }
                else if(startObjectCount == 2)
                {
                    // Second item is the display properties object
                    while(localJsonReader.Read())
                    {
                        if(localJsonReader.TokenType == JsonTokenType.EndObject)
                        {
                            // Done here
                            startObjectCount++;
                            break;
                        }
                        else if (localJsonReader.TokenType == JsonTokenType.StartObject)
                        {
                            continue;
                        }

                        string keyValueStr = localJsonReader.GetString();
                        if(keyValueStr == "description")
                        {
                            localJsonReader.Read();
                            tempAchivement.displayProperty.description = localJsonReader.GetString(); 
                        }
                        else if( keyValueStr == "name")
                        {
                            localJsonReader.Read();
                            tempAchivement.displayProperty.name = localJsonReader.GetString();
                        }
                        else if(keyValueStr == "hasIcon")
                        {
                            localJsonReader.Read();
                            tempAchivement.displayProperty.hasIcon = localJsonReader.GetBoolean();
                        }
                        else if(keyValueStr == "icon")
                        {
                            localJsonReader.Read();
                            tempAchivement.displayProperty.icon = localJsonReader.GetString();
                        }
                    }
                }
                else if (localJsonReader.GetString() == "acccumulatorThreshold")
                {
                    localJsonReader.Read();
                    tempAchivement.acccumulatorThreshold = localJsonReader.GetInt32();
                }
                else if (localJsonReader.GetString() == "platformIndex")
                {
                    localJsonReader.Read();
                    tempAchivement.platformIndex = localJsonReader.GetInt32();
                }
                else if(localJsonReader.GetString() == "hash")
                {
                    localJsonReader.Read();
                    tempAchivement.hash = localJsonReader.GetInt64();
                }
                else if(localJsonReader.GetString() == "index")
                {
                    localJsonReader.Read();
                    tempAchivement.index = localJsonReader.GetInt32();
                }
                else if(localJsonReader.GetString() == "redacted")
                {
                    localJsonReader.Read();
                    tempAchivement.redacted = localJsonReader.GetBoolean();
                }
                else if(localJsonReader.GetString() == "blacklisted")
                {
                    localJsonReader.Read();
                    tempAchivement.blacklisted = localJsonReader.GetBoolean();
                }
            } // End of While loop

            return true;
        }

    }
}

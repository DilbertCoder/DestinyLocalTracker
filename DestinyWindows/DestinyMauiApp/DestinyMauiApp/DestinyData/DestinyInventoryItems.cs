using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DestinyMauiApp.DestinyData
{
    public class DestinyInventoryItems
    {
        private class InventoryItem
        {
            public CommonDataClasses.DisplayProperty displayProperty;
            public List<string> tooltipNotifications;
            public BackgroundColor backgroundColor;
            public string screenshot;
            public string itemTypeDisplayName;
            public string flavorText;
            public string uiItemDisplayStyle;
            public string itemTypeAndTierDisplayName;
            public string displaySource;

            public InventoryItem()
            {
                displayProperty= new CommonDataClasses.DisplayProperty();
                backgroundColor= new BackgroundColor();
            }
        }

        private class BackgroundColor
        {
            public int colorHash;
            public int red;
            public int green;
            public int blue;
            public int alpha;
        }

        private class Action
        {
            public string verbName;
        }

        public DestinyInventoryItems()
        {
            InitializeFromJson();
        }

        private bool InitializeFromJson()
        {
            string dataFileName = "C:\\Users\\nmdil\\source\\repos\\DestinyLocalTracker\\DestinyWindows\\DestinyMauiApp\\DestinyMauiApp\\DestinyData\\data\\DestinyInventoryItemDefinition.json";
            var readOnlySpan = new ReadOnlySpan<byte>(File.ReadAllBytes(dataFileName));

            Utf8JsonReader localJsonReader = new Utf8JsonReader(readOnlySpan);

            bool foundTheEnd = false;
            int startObjectCount = 0;
            string objectKey = "bad";
            InventoryItem tempItem = null;
            while (localJsonReader.Read())
            {
                if (localJsonReader.TokenType == JsonTokenType.EndObject)
                {
                    if (foundTheEnd)
                    {
                        break;
                    }
                    
                    foundTheEnd = true;
                    continue;
                }

                foundTheEnd = false;

                if (localJsonReader.TokenType == JsonTokenType.StartObject)
                {
                    startObjectCount++;
                    continue;
                }

                if(startObjectCount == 1) 
                {
                    objectKey = localJsonReader.GetString();
                    tempItem = new InventoryItem();
                }
                else if (startObjectCount == 2)
                {
                    // Second item is the display properties object
                    while (localJsonReader.Read())
                    {
                        if (localJsonReader.TokenType == JsonTokenType.EndObject)
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
                        if (keyValueStr == "description")
                        {
                            localJsonReader.Read();
                            tempItem.displayProperty.description = localJsonReader.GetString();
                        }
                        else if (keyValueStr == "name")
                        {
                            localJsonReader.Read();
                            tempItem.displayProperty.name = localJsonReader.GetString();
                        }
                        else if (keyValueStr == "hasIcon")
                        {
                            localJsonReader.Read();
                            tempItem.displayProperty.hasIcon = localJsonReader.GetBoolean();
                        }
                        else if (keyValueStr == "icon")
                        {
                            localJsonReader.Read();
                            tempItem.displayProperty.icon = localJsonReader.GetString();
                        }
                    }
                }
                else if (startObjectCount == 3)
                {
                    while (localJsonReader.Read())
                    {
                        if (localJsonReader.TokenType == JsonTokenType.EndObject)
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
                        if (keyValueStr == "colorHash")
                        {
                            localJsonReader.Read();
                            tempItem.backgroundColor.colorHash = localJsonReader.GetInt32();
                        }
                        else if (keyValueStr == "red")
                        {
                            localJsonReader.Read();
                            tempItem.backgroundColor.red = localJsonReader.GetInt32();
                        }
                        else if (keyValueStr == "green")
                        {
                            localJsonReader.Read();
                            tempItem.backgroundColor.green = localJsonReader.GetInt32();
                        }
                        else if (keyValueStr == "blue")
                        {
                            localJsonReader.Read();
                            tempItem.backgroundColor.blue = localJsonReader.GetInt32();
                        }
                        else if (keyValueStr == "alpha")
                        {
                            localJsonReader.Read();
                            tempItem.backgroundColor.alpha = localJsonReader.GetInt32();
                        }
                    }
                }

            }
            
            return false;
        }
    }
}

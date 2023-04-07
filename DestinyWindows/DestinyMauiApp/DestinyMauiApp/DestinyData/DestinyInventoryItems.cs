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
            public CommonDataClasses.BackgroundColor backgroundColor;
            public string screenshot;
            public string itemTypeDisplayName;
            public string flavorText;
            public string uiItemDisplayStyle;
            public string itemTypeAndTierDisplayName;
            public string displaySource;

            public InventoryItem()
            {
                displayProperty= new CommonDataClasses.DisplayProperty();
                backgroundColor= new CommonDataClasses.BackgroundColor();
            }
        }

        private Dictionary<string, InventoryItem> m_InventoryItems = new();

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
            string startObjectStr = "invalid";
            InventoryItem tempItem = null;
            while (localJsonReader.Read())
            {
                if (localJsonReader.TokenType == JsonTokenType.EndObject)
                {
                    if (foundTheEnd)
                    {
                        break;
                    }

                    if (tempItem != null)
                    {
                        m_InventoryItems.Add(objectKey, tempItem);
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
                else if (localJsonReader.TokenType == JsonTokenType.PropertyName)
                {
                    startObjectStr = localJsonReader.GetString();
                }

                // The first object after a start is the key
                if (startObjectCount == 1) 
                {
                    objectKey = startObjectStr;
                    tempItem = new InventoryItem();
                }
                else if (startObjectStr == "displayProperties")
                {
                    if (!CommonDataClassHelperMethods.LoadDisplayProperties(ref localJsonReader, ref tempItem.displayProperty))
                    { 
                        return false;
                    }
                }
                else if (startObjectStr == "backgroundColor")
                {
                    if(!CommonDataClassHelperMethods.LoadBackgroundColor(ref localJsonReader, ref tempItem.backgroundColor))
                    {
                        return false;
                    }
                }
                else if(startObjectStr == "screenshot")
                {
                    localJsonReader.Read();
                    tempItem.screenshot = localJsonReader.GetString();
                }
                else if(startObjectStr == "itemTypeDisplayName")
                {
                    localJsonReader.Read();
                    tempItem.itemTypeDisplayName = localJsonReader.GetString();
                }
                else if(startObjectStr == "flavorText")
                {
                    localJsonReader.Read();
                    tempItem.flavorText = localJsonReader.GetString();
                }
                else if(startObjectStr == "uiItemDisplayStyle")
                {
                    localJsonReader.Read();
                    tempItem.uiItemDisplayStyle = localJsonReader.GetString();
                }
                else if(startObjectStr == "itemTypeAndTierDisplayName")
                {
                    localJsonReader.Read();
                    tempItem.itemTypeAndTierDisplayName = localJsonReader.GetString();
                }
                else if(startObjectStr == "displaySource")
                {
                    localJsonReader.Read();
                    tempItem.displaySource = localJsonReader.GetString();
                }
                else if(startObjectStr == "action")
                {
                    localJsonReader.Read();
                    // TODO
                }

            }
            
            return false;
        }
    }
}

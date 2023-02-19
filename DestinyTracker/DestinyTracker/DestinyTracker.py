# Base file for the project with the Main
import json

# Local Imports
import DestinyApi.basedestinyapi
import DestinyApi.destinyApiEnums
import DestinyApi.Models.DestinyDataModelInterface

#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
def main():
    localApi = DestinyApi.basedestinyapi.BaseDestinyApi()
    localDataModel = DestinyApi.Models.DestinyDataModelInterface.DestinyDataModelInterface

    #See if we need to update the manifest files
    localApi.UpdateManifestContent()

    #load the manifest data files
    #localDataModel.InitializeFromJsonFiles()
        



    #destinyClassObj = DestinyApi.Models.DestinyClassModel.DestinyClassModel()

    #This file as all the items in it along with weapons. You can take and item and cross refence the bucketTypeHash value to figure out if the item is a weapon. 
    #this sounds like a database job. 
    #with open("C:/Users/nmdil/source/repos/DestinyLocalTracker/DestinyTracker/DestinyInventoryItemDefinition-4d6ea585-75c4-46c4-96c1-ec25b3db2f05.json",encoding="utf_8", mode= "r") as inputJsonFile:
    #    destinyItemInventory = json.load(inputJsonFile)
    #    with open("Weapons.json",encoding="utf_8",mode="w") as testJsonFile:
    #        json.dump(destinyItemInventory['2221264583'], testJsonFile, indent=4)
    #        json.dump(destinyItemInventory['1937552980'], testJsonFile, indent=4)
            
    with open("playerData.txt", "w") as testOutputFile:
        json.dump(localApi.SearchForPlayer("DarthDilbert", 1996), testOutputFile, indent=4)

    with open("playerProfile.txt", "w") as profileOutputFile:
        json.dump(localApi.GetPlayerProfile(membershiptype=3, membershipId=4611686018485481455, componetItems="Characters"), profileOutputFile, indent=4)

    #with open("clanInformation.txt", "w") as profileOutputFile:
    #    json.dump(localApi.SearchForClanByName(clanName="Touched by a SIVA"), profileOutputFile, indent=4)
    
#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
if __name__ == "__main__":
    main()

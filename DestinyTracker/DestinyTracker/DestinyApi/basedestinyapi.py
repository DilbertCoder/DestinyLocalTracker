import json
import os
import requests
import shutil
from urllib.parse import urljoin

#Local imports
import DestinyApi.destinywebinterface

#--------------------------------------------------------------------------
# API Path String
#--------------------------------------------------------------------------
getBungieApplicationListApiStr = "App/FirstParty/"
getSearchByDestinyName = "Destiny2/SearchDestinyPlayerByBungieName/-1/"
getThemes = "GroupV2/GetAvailableThemes/"
getContentType = "Content/GetContentType/300/"
getDestinyManifest = "Destiny2/Manifest/"

JSON_RESPONSE_KEY = "Response"

MANIFEST_BASE = "Models\\DataFiles"
MANIFEST_BASE_FILE_PATH = "Models\\DataFiles\\CurrentManifest.json"

class BaseDestinyApi(object):
    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def __init__(self) -> None:
        self.localWebInterface = DestinyApi.destinywebinterface.DestinyWebInterface()
        self.workingDirectory = os.path.dirname(__file__)
        self.currentManifestVersion = None
        manifestFile = os.path.join(self.workingDirectory, MANIFEST_BASE_FILE_PATH)
        if os.path.exists(manifestFile):
            with open(manifestFile, encoding="utf_8", mode="r") as currentManifestFile:
                manifestObj = json.load(currentManifestFile)
                self.currentManifestVersion = manifestObj['version']


    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def UpdateManifestContent(self):
        destinyManifestPath = "Destiny2/Manifest/"
        reponseJsonObj = self.localWebInterface.GetRequestNoParameters(destinyManifestPath)
        manifestJsonObj = reponseJsonObj[JSON_RESPONSE_KEY]
        if self.currentManifestVersion != manifestJsonObj['version']:
            #At some point will need to keep this 
            self.currentManifestVersion = manifestJsonObj['version']
            
            #Now lets go get the other files
            manifestFileList = manifestJsonObj['jsonWorldComponentContentPaths']['en']

            for jsonKey in manifestFileList:
                fileUrl = urljoin(self.localWebInterface.GetBaseApiUrl(), manifestFileList[jsonKey])
                finalFilePath = os.path.join(self.workingDirectory, "{}\\{}.json".format(MANIFEST_BASE, jsonKey))
                fileRequestOutput = requests.get(fileUrl)
                with open(finalFilePath, encoding="utf_8", mode="w") as outputFile:
                    print(f"Pulling Update for {jsonKey}")
                    outputFile.write(fileRequestOutput.content.decode())

            #Save the current Manifest over the old one
            manifestFile = os.path.join(self.workingDirectory, MANIFEST_BASE_FILE_PATH)
            with open(manifestFile, encoding="utf_8", mode="w") as outputManifestFile:
                json.dump(manifestJsonObj, outputManifestFile)

            return True
        else:
            print("Manifest already up to date")
            return False

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def SearchForPlayer(self, playerName: str, playerNumber: int) -> json:
        destinyNameJson = {"displayName": playerName, "displayNameCode": playerNumber}
        return self.localWebInterface.PostRequestToApi(apiPath=getSearchByDestinyName, jsonData=destinyNameJson)

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetPlayerProfile(self, membershiptype: int, membershipId: int, componetItems: str):
        getProfileApiPath = f"Destiny2/{membershiptype}/Profile/{membershipId}/"
        componentParams = {'components': componetItems}
        return self.localWebInterface.GetRequestWithParameters(apiPath=getProfileApiPath, apiParams=componentParams)

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetHistoricalStats(self, membershiptype: int, membershipId: int, characterId: int):
        getHistroicalStateApiPath = f"Destiny2/{membershiptype}/Account/{membershipId}/Character/{characterId}/Stats/"

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetActivityHistory(self, membershiptype: int, membershipId: int, characterId: int):
        getActivityHistoryApiPath = f"Destiny2/{membershiptype}/Account/{membershipId}/Character/{characterId}/Stats/Activities/"

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def SearchForClanByName(self, clanName: str):
        searchForClanByName = f"GroupV2/Name/{clanName}/1/"
        return self.localWebInterface.GetRequestNoParameters(apiPath=searchForClanByName)

    #--------------------------------------------------------------------------
    # Call to App.GetBungieApplications
    #--------------------------------------------------------------------------
    def GetBungieApplicationList(self) -> json:
        apiResultJson = self.localWebInterface.GetRequestNoParameters(apiPath=getContentType)
        #apiResultJson = self.localWebInterface.GetRequestNoParameters(apiPath=getDestinyManifest)
        return apiResultJson





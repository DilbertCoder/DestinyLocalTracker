import json

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

class BaseDestinyApi(object):
    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    localWebInterface = DestinyApi.destinywebinterface.DestinyWebInterface()

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def __init__(self) -> None:
        print("TODO any initial stuff")

    #--------------------------------------------------------------------------
    # Call to App.GetBungieApplications
    #--------------------------------------------------------------------------
    def GetBungieApplicationList(self) -> json:
        #destinyNameJson = {"displayName": "DarthDilbert", "displayNameCode": 1996}
        #apiResultJson = self.localWebInterface.PostRequestToApi(apiPath=getSearchByDestinyName, jsonData=destinyNameJson)
        apiResultJson = self.localWebInterface.GetRequestNoParameters(apiPath=getContentType)
        #apiResultJson = self.localWebInterface.GetRequestNoParameters(apiPath=getDestinyManifest)
        return apiResultJson





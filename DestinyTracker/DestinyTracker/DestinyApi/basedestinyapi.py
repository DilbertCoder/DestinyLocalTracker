
#Local imports
import DestinyApi.destinywebinterface

#--------------------------------------------------------------------------
# API Path String
#--------------------------------------------------------------------------
getBungieApplicationListApiStr = "App/FirstParty/"

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
    def GetBungieApplicationList(self):
        apiResultJson = self.localWebInterface.GetRequestNoParameters(DestinyApi.basedestinyapi.getBungieApplicationListApiStr, "")
        return apiResultJson





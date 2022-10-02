# System imports
import requests
import json
from urllib.parse import urljoin

class DestinyWebInterface(object):
    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def __init__(self) -> None:
        self.apiAuthenticationToken = None
        self.destinyApiBaseUrl = "https://www.bungie.net"
        self.destinyApiBasePath = "/Platform/"
        self.apiXKeyheader = {'x-api-key' : '18c9bc642c824e84a683e096fb560371'}

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetBaseApiUrl(self):
        return self.destinyApiBaseUrl

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def LoginToDestinyApi(self):
        print("TODO")

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetRequestNoParameters(self, apiPath) -> json:
        completeApiPath = self.destinyApiBasePath + apiPath
        completeHttpUrl = urljoin(self.destinyApiBaseUrl, completeApiPath)
        apiGetResult = requests.get(url=completeHttpUrl, headers=self.apiXKeyheader)
        return apiGetResult.json()

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetRequestWithParameters(self, apiPath, apiParams) -> json:
        completeApiPath = self.destinyApiBasePath + apiPath
        completeHttpUrl = urljoin(self.destinyApiBaseUrl, completeApiPath)
        apiGetResult = requests.get(url=completeHttpUrl, headers=self.apiXKeyheader, params=apiParams)
        return apiGetResult.json()

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def PostRequestToApi(self, apiPath, jsonData: json) -> json:
        completeApiPath = self.destinyApiBasePath + apiPath
        completeHttpUrl = urljoin(self.destinyApiBaseUrl, completeApiPath)
        apiPostResult = requests.post(url=completeHttpUrl, headers=self.apiXKeyheader, data=json.dumps(jsonData))
        return apiPostResult.json()



    






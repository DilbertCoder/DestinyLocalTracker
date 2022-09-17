# System imports
import requests
import json
import string
from urllib.parse import urljoin

class DestinyWebInterface(object):
    apiAuthenticationToken = None
    destinyApiBaseUrl = "https://www.bungie.net/"
    destinyApiBasePath = "Platform/"
    apiXKeyheader = {'x-api-key' : ''}

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def __init__(self) -> None:
        print("TODO any initial stuff")

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def LoginToDestinyApi(self):
        print("TODO")

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetRequestNoParameters(self, apiPath, apiKey) -> json:
        apiHeader = {'x-api-key' : apiKey}
        completeApiPath = self.destinyApiBasePath + apiPath
        completeHttpUrl = urljoin(self.destinyApiBaseUrl, completeApiPath)
        apiGetResult = requests.get(url=completeHttpUrl, headers=apiHeader)
        return apiGetResult.json()


    






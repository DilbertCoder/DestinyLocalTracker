# System imports
import requests

class DestinyWebInterface:
    apiAuthenticationToken = None
    destinyApiBaseUrl = "https://api.publicapis.org/entries"

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
    def TestRequest(self):
        testOutput = requests.get(url=self.destinyApiBaseUrl, verify=True)
        return testOutput.json()

    






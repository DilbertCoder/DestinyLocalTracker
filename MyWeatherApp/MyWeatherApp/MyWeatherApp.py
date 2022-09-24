#System Imports
import json
import requests
from urllib.parse import urljoin


#Member Variables
nwsBaseUrl = "https://api.weather.gov"
nwsStationApi = "stations"
nwsAlertsApi = "alerts/active"
nwsApiAgentHeader = {'User-Agent': 'My New App', 'From': 'nmdilbert@msn.com' }

#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
def main():
    completeHttpUrl = urljoin(nwsBaseUrl, nwsAlertsApi)
    #area = {'area': 'FL'}
    #apiGetResult = requests.get(url=completeHttpUrl, headers=nwsApiAgentHeader, params=area)
    #print(apiGetResult.json())

    stationParam = {'state': 'FL', 'limit': '1'}
    completeStationHttpUrl = urljoin(nwsBaseUrl, nwsStationApi)
    apiGetStationRet = requests.get(url=completeStationHttpUrl, headers=nwsApiAgentHeader, params=stationParam )
    print(apiGetStationRet.json())
    print("TODO")

#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
if __name__ == "__main__":
    main()

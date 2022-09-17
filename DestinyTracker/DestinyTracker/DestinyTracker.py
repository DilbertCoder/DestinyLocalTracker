# Base file for the project with the Main
import json

# Local Imports
import DestinyApi.basedestinyapi

#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
def main():
    localApi = DestinyApi.basedestinyapi.BaseDestinyApi()
    
    print(localApi.GetBungieApplicationList())
    
#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
if __name__ == "__main__":
    main()

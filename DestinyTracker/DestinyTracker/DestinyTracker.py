# Base file for the project with the Main

# Local Imports
import DestinyApi.destinywebinterface

def main():
    print("Hello World")
    tempItem = DestinyApi.destinywebinterface.DestinyWebInterface()
    print(tempItem.TestRequest())


if __name__ == "__main__":
    main()

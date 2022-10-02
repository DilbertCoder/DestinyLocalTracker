#Class to hold the class information from DestinyClassDefinition-4d6ea585-75c4-46c4-96c1-ec25b3db2f05.json file
import json

DESTINY_CLASS_CLASS_JSON_KEY = 'classType'
DESTINY_CLASS_DISPALY_JSON_KEY = 'displayProperties'
DESTINY_CLASS_HASH_JSON_KEY = 'hash'


#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
class DestinyClass(object):
    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def __init__(self, classId):
        self.classId = classId
        self.classType = None
        self.displayStr = None
        self.hash = None

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def parseJson(self, inputJsonObj: json):
        self.classType = inputJsonObj[DESTINY_CLASS_CLASS_JSON_KEY]
        self.displayStr = inputJsonObj[DESTINY_CLASS_DISPALY_JSON_KEY]['name']
        self.hash = inputJsonObj[DESTINY_CLASS_HASH_JSON_KEY]

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def CheckClassHash(self, hashToCheck):
        if self.hash == hashToCheck:
            return True
        else:
            return False

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetClassDisplayString(self):
        return self.displayStr

#--------------------------------------------------------------------------
#--------------------------------------------------------------------------
class DestinyClassModel(object):
    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def __init__(self) -> None:
        self.classList = list()

        with open("C:/Users/nmdil/source/repos/DestinyLocalTracker/DestinyTracker/DestinyTracker/DestinyApi/Models/DataFiles/DestinyClassDefinition-4d6ea585-75c4-46c4-96c1-ec25b3db2f05.json", encoding="utf_8", mode="r") as inputJsonFile:
            inputJsonObj = json.load(inputJsonFile)

            for jsonKey in inputJsonObj:
                newDestinyClass = DestinyClass(jsonKey)
                newDestinyClass.parseJson(inputJsonObj[jsonKey])
                self.classList.append(newDestinyClass)

    #--------------------------------------------------------------------------
    #--------------------------------------------------------------------------
    def GetDisplayString(self, hash):
        for classObj in self.classList:
            if classObj.CheckClassHash(hash):
                return classObj.GetClassDisplayString()

        return None


                





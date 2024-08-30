local specID = PlayerUtil.GetCurrentSpecID()

-- last selected configID or fall back to default spec config
local configID = C_ClassTalents.GetLastSelectedSavedConfigID(specID) or C_ClassTalents.GetActiveConfigID()

local configInfo = C_Traits.GetConfigInfo(configID)
local treeID = configInfo.treeIDs[1]

local nodes = C_Traits.GetTreeNodes(treeID)

for _, nodeID in ipairs(nodes) do
    local nodeInfo = C_Traits.GetNodeInfo(configID, nodeID)
    local entryID = nodeInfo.activeEntry and nodeInfo.activeEntry.entryID and nodeInfo.activeEntry.entryID
    local entryInfo = entryID and C_Traits.GetEntryInfo(configID, entryID)
    local definitionInfo = entryInfo and entryInfo.definitionID and C_Traits.GetDefinitionInfo(entryInfo.definitionID)

    if definitionInfo ~= nil then
        local talentName = TalentUtil.GetTalentName(definitionInfo.overrideName, definitionInfo.spellID)
        print(string.format("定义ID：%d NodeID: %d %s %d/%d 法术ID：%d",entryInfo.definitionID, nodeID, talentName, nodeInfo.currentRank, nodeInfo.maxRanks,definitionInfo.spellID))
    end
end
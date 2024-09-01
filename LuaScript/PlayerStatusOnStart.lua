-- Desc: This script is used to get player status on start

--- 初始化姓名板数据
function aura_env:initializeDataLists()
    aura_env.nameplateList = {}
    aura_env.playerBuffDataList = {}
end

aura_env:initializeDataLists()

--- 初始化敌对Debuff数据
function aura_env:initializeEnemyDebuffData()
    aura_env.enemyDebuffList = {
        ["keys"] = { 118, 122, 212792, 449700, 210824, 453912, 453599 },
        ["watchKeys"] = { 449700, 210824, 453912, 453599 },
        [118] = "变形术",
        [122] = "冰霜新星",
        [212792] = "冰锥术",
        [449700] = "引力失效",
        [210824] = "大法师之触",
        [453912] = "大法师的火花",
        [453599] = "奥术衰竭",
    }
end

function aura_env:initializePlayerBuffData()
    aura_env.playerBuffList = {
        ["keys"] = { 1459, 210126, 449400, 448604, 451049, 384455, 116267, 449322, 383997, 458388, 453601, 451073, 461531, 263725, 383783, 384267, 365362, 448659, 451038, 235450, 110960, 45438 },
        ["watchKeys"] = { 1459, 210126, 449400, 448604, 451049, 384455, 116267, 449322, 383997, 458388, 453601, 451073, 263725, 383783, 384267, 365362, 451038, 235450, 110960, 45438 },
        [1459] = "奥术智慧",
        [210126] = "奥术魔宠",
        [449400] = "法术火焰宝珠",
        [448604] = "法术火焰宝珠",
        [451049] = "力量的重担",
        [384455] = "奥术祥和",
        [116267] = "咒术洪流",
        [449322] = "法力涌流",
        [383997] = "奥术迅疾",
        [458388] = "以太调谐",
        [453601] = "以太调谐",
        [451073] = "白炽耀焰",
        [461531] = "清晰头脑",
        [263725] = "节能施法",
        [383783] = "虚空精准",
        [384267] = "风暴虹吸",
        [365362] = "奥术涌动",
        [448659] = "奥术凤凰",
        [451038] = "奥术之魂",
        [235450] = "棱光护体",
        [110960] = "强效隐形",
        [45438] = "寒冰屏障",
    }
end

aura_env:initializeEnemyDebuffData()
aura_env:initializePlayerBuffData()

--- 将数字转换为字节
---@param num number 待转换的数字
---@return number, number, number, number, number, number 高位字节1, 高位字节2, 高位字节3, 低位字节1, 低位字节2, 低位字节3
function aura_env:intToBytes(num)
    local byte1, byte2, byte3, byte4, byte5, byte6
    byte1 = bit.band(num, 0xFF0000000000)
    byte2 = bit.band(num, 0x00FF00000000)
    byte3 = bit.band(num, 0x0000FF000000)
    byte4 = bit.band(num, 0x000000FF0000)
    byte5 = bit.band(num, 0x00000000FF00)
    byte6 = bit.band(num, 0x0000000000FF)
    return bit.rshift(byte1, 40), bit.rshift(byte2, 32), bit.rshift(byte3, 24), bit.rshift(byte4, 16), bit.rshift(byte5, 8), byte6
end

--- 将数字转换为短字节
---@param num number 待转换的数字
---@return number, number, number 字节位1, 字节位2, 字节位3
function aura_env:intToShortBytes(num)
    local byte1, byte2, byte3
    byte1 = bit.band(num, 0x000000FF0000)
    byte2 = bit.band(num, 0x00000000FF00)
    byte3 = bit.band(num, 0x0000000000FF)
    return bit.rshift(byte1, 16), bit.rshift(byte2, 8), byte3
end

--- 将字节转换为布尔值
---@param bool1 boolean 字节位1
---@param bool2 boolean 字节位2
---@param bool3 boolean 字节位3
---@param bool4 boolean 字节位4
---@param bool5 boolean 字节位5
---@param bool6 boolean 字节位6
---@param bool7 boolean 字节位7
---@param bool8 boolean 字节位8
---@return number 字节
function aura_env:boolToByte(bool1, bool2, bool3, bool4, bool5, bool6, bool7, bool8)
    local byte = 0
    if bool1 then
        byte = bit.bor(byte, 0x80)
    end
    if bool2 then
        byte = bit.bor(byte, 0x40)
    end
    if bool3 then
        byte = bit.bor(byte, 0x20)
    end
    if bool4 then
        byte = bit.bor(byte, 0x10)
    end
    if bool5 then
        byte = bit.bor(byte, 0x08)
    end
    if bool6 then
        byte = bit.bor(byte, 0x04)
    end
    if bool7 then
        byte = bit.bor(byte, 0x02)
    end
    if bool8 then
        byte = bit.bor(byte, 0x01)
    end
    return byte
end

--- 设置材质颜色
---@param textureName string 材质名称
---@param redByte number 红色分量
---@param greenByte number 绿色分量
---@param blueByte number 蓝色分量
function aura_env:setTextureColor(textureName, redByte, greenByte, blueByte)
    local texture = WeakAuras.GetRegion(textureName)
    texture.Color(1, redByte / 255, greenByte / 255, blueByte / 255)
end

--- 获取材质颜色
---@param textureName string 材质名称
---@return number, number, number, number 红色分量, 绿色分量, 蓝色分量, 透明度
function aura_env:getTextureColor(textureName)
    local texture = WeakAuras.GetRegion(textureName)
    local r, g, b, a = texture.GetColor()
    return r * 255, g * 255, b * 255, a * 255
end

--- 读取当前时间信息
---@return void
function aura_env:readCurrentTime()
    aura_env.currentTime = GetTime()
    aura_env.currentMilliSeconds = aura_env.currentTime * 1000
end

--- 读取玩家是否存活信息
---@return boolean 玩家是否存活
function aura_env:readPlayerAlive()
    aura_env.playerIsAlive = UnitIsDeadOrGhost("player") == false
    return aura_env.playerIsAlive
end

--- 读取玩家是否在战斗状态
---@return boolean 玩家是否在战斗状态
function aura_env:readPlayerInCombat()
    aura_env.playerIsInCombat = UnitAffectingCombat("player")
    return aura_env.playerIsInCombat
end

--- 读取玩家是否在坐骑上
---@return boolean 玩家是否在坐骑上
function aura_env:readPlayerMounted()
    aura_env.playerIsMounted = IsMounted()
    return aura_env.playerIsMounted
end

--- 读取玩家是否在载具上
---@return boolean 玩家是否在载具上
function aura_env:readPlayerInVehicle()
    aura_env.playerIsInVehicle = UnitInVehicle("player")
    return aura_env.playerIsInVehicle
end

--- 读取玩家是否在跳跃状态
---@return boolean 玩家是否在跳跃状态
function aura_env:readPlayerJumping()
    aura_env.playerIsJumping = IsFalling()
    return aura_env.playerIsJumping
end

--- 读取玩家是否在移动
---@return boolean 玩家是否正在移动
function aura_env:readPlayerMoving()
    local speed, _, _, _ = GetUnitSpeed("player")
    if speed and speed > 0
    then
        aura_env.playerIsMoving = true
    else
        aura_env.playerIsMoving = false
    end
    return aura_env.playerIsMoving
end

--- 读取玩家施法信息
---@return boolean 玩家是否在施法
function aura_env:readPlayerCastingInfo()
    local name, text, texture, startTime, endTime, isTradeSkill, castID, notInterruptible, spellID = UnitCastingInfo("player")
    if name then
        aura_env.playerIsCasting = true
        aura_env.playerCastingName = name
        aura_env.playerCastingText = text
        aura_env.playerCastingTexture = texture
        aura_env.playerCastingStartTime = startTime
        aura_env.playerCastingEndTime = endTime
        aura_env.playerCastingIsTradeSkill = isTradeSkill
        aura_env.playerCastingCastID = castID
        aura_env.playerCastingNotInterruptible = notInterruptible
        aura_env.playerCastingSpellID = spellID
    else
        aura_env.playerIsCasting = false
    end
    return aura_env.playerIsCasting
end

--- 读取玩家引导信息
---@return boolean 玩家是否在引导
function aura_env:readPlayerChannelInfo()
    local name, text, texture, startTime, endTime, isTradeSkill, notInterruptible, spellID = UnitChannelInfo("player")
    if name then
        aura_env.playerIsChanneling = true
        aura_env.playerChannelingName = name
        aura_env.playerChannelingText = text
        aura_env.playerChannelingTexture = texture
        aura_env.playerChannelingStartTime = startTime
        aura_env.playerChannelingEndTime = endTime
        aura_env.playerChannelingIsTradeSkill = isTradeSkill
        aura_env.playerChannelingNotInterruptible = notInterruptible
        aura_env.playerChannelingSpellID = spellID
    else
        aura_env.playerIsChanneling = false
    end
    return aura_env.playerIsChanneling
end

--- 读取玩家生命值信息
---@return void
function aura_env:readPlayerHealth()
    aura_env.playerHealth = UnitHealth("player")
    aura_env.playerMaxHealth = UnitHealthMax("player")
    aura_env.playerHealthPercent = aura_env.playerHealth / aura_env.playerMaxHealth
end

--- 读取玩家能量信息
---@return void
function aura_env:readPlayerPower()
    aura_env.playerPower = UnitPower("player")
    aura_env.playerPowerMax = UnitPowerMax("player")
    aura_env.playerPowerPercent = aura_env.playerPower / aura_env.playerPowerMax
end

--- 读取玩家GCD
---@return void
function aura_env:readPlayerGCD()
    local coolDown = C_Spell.GetSpellCooldown(61304)
    if coolDown["startTime"] == 0 then
        aura_env.playerGCD = 0
    else
        aura_env.playerGCD = coolDown["startTime"] + coolDown["duration"] - aura_env.currentTime
        aura_env.playerGCD = aura_env.playerGCD * 1000
    end
end

function aura_env:readPlayerClassAndSpec()
    aura_env.playerClassId = select(3, UnitClass("player"))
    aura_env.playerSpecId = GetSpecialization()
end

--- 读取所有玩家数据
---@return void
function aura_env:readAllPlayerData()
    aura_env:readCurrentTime()
    aura_env:readPlayerAlive()
    aura_env:readPlayerInCombat()
    aura_env:readPlayerMounted()
    aura_env:readPlayerInVehicle()
    aura_env:readPlayerJumping()
    aura_env:readPlayerMoving()
    aura_env:readPlayerCastingInfo()
    aura_env:readPlayerChannelInfo()
    aura_env:readPlayerHealth()
    aura_env:readPlayerPower()
    aura_env:readPlayerGCD()
    aura_env:readPlayerClassAndSpec()
end

--- 获取玩家状态1
---@return number 玩家状态1
function aura_env:getPlayerStatus1()
    local playerAlive = aura_env.playerIsAlive
    local playerInCombat = aura_env.playerIsInCombat
    local playerMounted = aura_env.playerIsMounted
    local playerInVehicle = aura_env.playerIsInVehicle
    local playerJumping = aura_env.playerIsJumping
    local playerMoving = aura_env.playerIsMoving
    local playerIsCasting = aura_env.playerIsCasting
    local playerIsChanneling = aura_env.playerIsChanneling
    local playerStatus = aura_env:boolToByte(playerAlive, playerInCombat, playerMounted, playerInVehicle, playerJumping, playerMoving, playerIsCasting, playerIsChanneling)
    return playerStatus
end

function aura_env:updatePlayerStatusToTexture()
    local playerStatus1 = aura_env:getPlayerStatus1()
    aura_env:setTextureColor("玩家当前状态", playerStatus1, 0, 0)
    --local r, g, b, a = aura_env:getTextureColor("玩家当前状态")
    --print(r, g, b, a)
end

--- 更新时间到材质
---@return void
function aura_env:updateTimeToTexture()
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(aura_env.currentMilliSeconds)
    aura_env:setTextureColor("当前时间高位", byte1, byte2, byte3)
    aura_env:setTextureColor("当前时间低位", byte4, byte5, byte6)
end

--- 获取玩家当前生命值Byte串
---@return number, number, number, number, number, number 玩家当前生命值Byte串
function aura_env:getPlayerHealthBytes()
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(aura_env.playerHealth)
    return byte1, byte2, byte3, byte4, byte5, byte6
end

--- 获取玩家最大生命值Byte串
---@return number, number, number, number, number, number 玩家最大生命值Byte串
function aura_env:getPlayerMaxHealthBytes()
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(aura_env.playerMaxHealth)
    return byte1, byte2, byte3, byte4, byte5, byte6
end

--- 获取玩家当前能量Byte串
---@return number, number, number, number, number, number 玩家当前能量Byte串
function aura_env:getPlayerPowerBytes()
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(aura_env.playerPower)
    return byte1, byte2, byte3, byte4, byte5, byte6
end

--- 获取玩家最大能量Byte串
---@return number, number, number, number, number, number 玩家最大能量Byte串
function aura_env:getPlayerMaxPowerBytes()
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(aura_env.playerPowerMax)
    return byte1, byte2, byte3, byte4, byte5, byte6
end

--- 更新玩生命值到材质
---@return void
function aura_env:updatePlayerHealthToTexture()
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:getPlayerHealthBytes()
    aura_env:setTextureColor("玩家当前生命值高位", byte1, byte2, byte3)
    aura_env:setTextureColor("玩家当前生命值低位", byte4, byte5, byte6)
    byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:getPlayerMaxHealthBytes()
    aura_env:setTextureColor("玩家最大生命值高位", byte1, byte2, byte3)
    aura_env:setTextureColor("玩家最大生命值低位", byte4, byte5, byte6)
end

--- 更新玩家能量到材质
---@return void
function aura_env:updatePlayerPowerToTexture()
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:getPlayerPowerBytes()
    aura_env:setTextureColor("玩家当前能量值高位", byte1, byte2, byte3)
    aura_env:setTextureColor("玩家当前能量值低位", byte4, byte5, byte6)
    byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:getPlayerMaxPowerBytes()
    aura_env:setTextureColor("玩家最大能量值高位", byte1, byte2, byte3)
    aura_env:setTextureColor("玩家最大能量值低位", byte4, byte5, byte6)
end

--- 更新玩家公共冷却剩余时间到材质
---@return void
function aura_env:updatePlayerGCDToTexture()
    local byte1, byte2, byte3 = aura_env:intToShortBytes(aura_env.playerGCD)
    aura_env:setTextureColor("玩家公共冷却剩余时间", byte1, byte2, byte3)
end

--- 更新玩家施法结束时间到材质
---@return void
function aura_env:updatePlayerCastEndTimeToTexture()
    if aura_env.playerIsCasting == false then
        return
    end
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(aura_env.playerCastingEndTime)
    aura_env:setTextureColor("玩家施法结束时间高位", byte1, byte2, byte3)
    aura_env:setTextureColor("玩家施法结束时间低位", byte4, byte5, byte6)
end

--- 更新玩家引导结束时间到材质
---@return void
function aura_env:updatePlayerChannelEndTimeToTexture()
    if aura_env.playerIsChanneling == false then
        return
    end
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(aura_env.playerChannelingEndTime)
    aura_env:setTextureColor("玩家引导结束时间高位", byte1, byte2, byte3)
    aura_env:setTextureColor("玩家引导结束时间低位", byte4, byte5, byte6)
end

--- 更新玩家职业专精到材质
---@return void
function aura_env:updatePlayerClassAndSpecToTexture()
    aura_env:setTextureColor("玩家职业专精", aura_env.playerClassId, aura_env.playerSpecId, 0)
end

--- 更新所有玩家数据到材质
---@return void
function aura_env:updateAllPlayerDataToTexture()
    aura_env:updateTimeToTexture()
    aura_env:updatePlayerStatusToTexture()
    aura_env:updatePlayerHealthToTexture()
    aura_env:updatePlayerPowerToTexture()
    aura_env:updatePlayerGCDToTexture()
    aura_env:updatePlayerCastEndTimeToTexture()
    aura_env:updatePlayerChannelEndTimeToTexture()
    aura_env:updatePlayerClassAndSpecToTexture()
end

--- 获取单位所有的玩家造成的debuff
---@param unit string 单位
---@return table 所有的玩家造成的debuff的Table，以SpellID为Key
function aura_env:readUnitDebuffsByPlayer(unit)
    local debuffs = {}

    for i = 1, 40 do
        local aura = C_UnitAuras.GetDebuffDataByIndex(unit, i, "player")
        if aura then
            debuffs[aura.spellId] = aura
        else
            break
        end
    end
    return debuffs
end

--- 读取单个姓名板数据
---@param index number 索引
---@return table 单个姓名板数据
function aura_env:readNameplateData(index)
    local unit = "nameplate" .. index
    local unitInfo = {}
    unitInfo.exists = UnitExists(unit)
    if (unitInfo.exists == false) then
        return unitInfo
    end
    unitInfo.unitString = unit
    unitInfo.isDead = UnitIsDead(unit)
    unitInfo.canAttack = UnitCanAttack("player", unit)
    unitInfo.isInCombat = UnitAffectingCombat(unit)
    unitInfo.isThreat = UnitThreatSituation("player", unit)
    local name, text, texture, startTime, endTime, isTradeSkill, castID, notInterruptible, spellID = UnitCastingInfo(unit)
    unitInfo.isCasting = name ~= nil
    unitInfo.canInterruptCast = isCasting and not notInterruptible
    name, text, texture, startTime, endTime, isTradeSkill, notInterruptible, spellID = UnitChannelInfo(unit)
    unitInfo.isChanneling = name ~= nil
    unitInfo.canInterruptChannel = isChanneling and not notInterruptible
    unitInfo.isInterruptible = unitInfo.canInterruptCast or unitInfo.canInterruptChannel
    unitInfo.inMeleeRange = IsItemInRange(37727, unit)
    unitInfo.in6YardRange = IsItemInRange(63427, unit)
    unitInfo.in8YardRange = IsItemInRange(34368, unit)
    unitInfo.in10YardRange = IsItemInRange(32321, unit)
    unitInfo.in15YardRange = IsItemInRange(33069, unit)
    unitInfo.in20YardRange = IsItemInRange(10645, unit)
    unitInfo.in25YardRange = IsItemInRange(24268, unit)
    unitInfo.in30YardRange = IsItemInRange(835, unit)
    unitInfo.in35YardRange = IsItemInRange(24269, unit)
    unitInfo.in40YardRange = IsItemInRange(28767, unit)
    unitInfo.in70YardRange = IsItemInRange(41265, unit)
    unitInfo.in80YardRange = IsItemInRange(35278, unit)
    unitInfo.in100YardRange = IsItemInRange(33119, unit)

    unitInfo.currentHealth = UnitHealth(unit)
    unitInfo.maxHealth = UnitHealthMax(unit)
    unitInfo.currentPower = UnitPower(unit)
    unitInfo.maxPower = UnitPowerMax(unit)
    unitInfo.playerDebuffs = aura_env:readUnitDebuffsByPlayer(unit)

    aura_env.nameplateList[index] = unitInfo

    return unitInfo
end

--- 读取所有姓名板数据
function aura_env:readAllNamePlateData()
    for k, v in pairs(aura_env.nameplateList) do
        aura_env.nameplateList[k] = nil
    end
    local info
    for i = 1, 40 do
        info = aura_env:readNameplateData(i)
        if info.exists == false then
            break
        end
    end
end

--- 获取单位在姓名板中的索引
---@param unit string 单位
---@return number 索引
function aura_env:getUnitNameplateIndex(unit)
    if not UnitExists(unit) then
        return 0
    end
    for k, v in pairs(aura_env.nameplateList) do
        if UnitIsUnit(unit, v.unitString) then
            return k
        end
    end
    return 0
end

--- 读取每个特殊单位的姓名板索引
---@return void
function aura_env:readSpecialUnitData()
    aura_env.targetIndex = aura_env:getUnitNameplateIndex("target")
    aura_env.focusIndex = aura_env:getUnitNameplateIndex("focus")
    aura_env.mouseoverIndex = aura_env:getUnitNameplateIndex("mouseover")
    aura_env.boss1Index = aura_env:getUnitNameplateIndex("boss1")
    aura_env.boss2Index = aura_env:getUnitNameplateIndex("boss2")
    aura_env.boss3Index = aura_env:getUnitNameplateIndex("boss3")
    aura_env.boss4Index = aura_env:getUnitNameplateIndex("boss4")
    aura_env.boss5Index = aura_env:getUnitNameplateIndex("boss5")
    aura_env.boos6Index = aura_env:getUnitNameplateIndex("boss6")
    aura_env.boss7Index = aura_env:getUnitNameplateIndex("boss7")
    aura_env.boss8Index = aura_env:getUnitNameplateIndex("boss8")
end

function aura_env:readPlayerBuffData()
    for k, v in pairs(aura_env.playerBuffDataList) do
        aura_env.playerBuffDataList[k] = nil
    end
    for i = 1, 40 do
        local aura = C_UnitAuras.GetBuffDataByIndex("player", i, "player")
        if aura then
            aura_env.playerBuffDataList[aura.spellId] = aura
        else
            break
        end
    end
end

--- 获取姓名板材质名称
---@param index number 索引
---@return table 姓名板材质名称
function aura_env:getNameplateTextureNames(index)
    local nameTable = {}
    nameTable.statusName = "姓名板状态" .. index
    nameTable.currentHealthHighName = "姓名板生命值高位" .. index
    nameTable.currentHealthLowName = "姓名板生命值低位" .. index
    nameTable.maxHealthHighName = "姓名板最大生命值高位" .. index
    nameTable.maxHealthLowName = "姓名板最大生命值低位" .. index
    nameTable.debuff1Name = "姓名板1号Debuff" .. index
    nameTable.debuff2Name = "姓名板2号Debuff" .. index
    nameTable.debuff3Name = "姓名板3号Debuff" .. index
    nameTable.debuff4Name = "姓名板4号Debuff" .. index
    nameTable.debuff5Name = "姓名板5号Debuff" .. index
    nameTable.debuff6Name = "姓名板6号Debuff" .. index
    nameTable.debuff7Name = "姓名板7号Debuff" .. index
    nameTable.debuff8Name = "姓名板8号Debuff" .. index
    nameTable.debuff9Name = "姓名板9号Debuff" .. index
    nameTable.debuff10Name = "姓名板10号Debuff" .. index
    return nameTable
end

--- 将姓名板材质设置为不存在
function aura_env:setNameplateTextureNotExists(index)
    local nameTable = aura_env:getNameplateTextureNames(index)
    for k, v in pairs(nameTable) do
        aura_env:setTextureColor(v, 0, 0, 0)
    end
end

--- 将Debuff信息转化为颜色信息
---@param aura table Debuff信息
---@return number, number, number 红色分量, 绿色分量, 蓝色分量，如果debuff可叠加，则红色分量为叠加层数，绿蓝分量为剩余时间，否则三个分量全为剩余时间，另外，红色分量的最高位用于表示debuff是否存在
function aura_env:convertDebuffInfoToRGB(aura)

    local red, green, blue
    if aura.applications > 0 then
        if aura.applications > 255 then
            red = 255
        else
            red = aura.applications
        end

        local expirationRemains = aura.expirationTime * 1000 - aura_env.currentMilliSeconds

        if expirationRemains > 0x0000FFFF then
            green = 255
            blue = 255
        else
            _, green, blue = aura_env:intToShortBytes(expirationRemains)
        end
    else
        local expirationRemains = aura.expirationTime * 1000 - aura_env.currentMilliSeconds

        if expirationRemains > 0x00FFFFFF then
            red = 255
            green = 255
            blue = 255
        else
            red, green, blue = aura_env:intToShortBytes(expirationRemains)
        end
    end

    if red < 128 then
        red = 128 + red
    end

    return red, green, blue
end

--- 更新姓名板数据到材质
---@param index number 索引
---@return void
function aura_env:updateNameplateDataToTexture(index)
    local unitInfo = aura_env.nameplateList[index]
    if unitInfo == nil or unitInfo.exists == false then
        aura_env:setNameplateTextureNotExists(index)
        return
    end
    local status1 = aura_env:boolToByte(true, unitInfo.isDead, unitInfo.canAttack, unitInfo.isInCombat, unitInfo.isThreat, unitInfo.isCasting, unitInfo.canInterruptCast, unitInfo.isChanneling)
    local status2 = aura_env:boolToByte(unitInfo.canInterruptChannel, unitInfo.isInterruptible, unitInfo.inMeleeRange, unitInfo.in6YardRange, unitInfo.in8YardRange, unitInfo.in10YardRange, unitInfo.in15YardRange, unitInfo.in20YardRange)
    local status3 = aura_env:boolToByte(unitInfo.in25YardRange, unitInfo.in30YardRange, unitInfo.in35YardRange, unitInfo.in40YardRange, unitInfo.in70YardRange, unitInfo.in80YardRange, unitInfo.in100YardRange, false)

    local textureNames = aura_env:getNameplateTextureNames(index)
    aura_env:setTextureColor(textureNames.statusName, status1, status2, status3)
    local byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(unitInfo.currentHealth)
    aura_env:setTextureColor(textureNames.currentHealthHighName, byte1, byte2, byte3)
    aura_env:setTextureColor(textureNames.currentHealthLowName, byte4, byte5, byte6)
    byte1, byte2, byte3, byte4, byte5, byte6 = aura_env:intToBytes(unitInfo.maxHealth)
    aura_env:setTextureColor(textureNames.maxHealthHighName, byte1, byte2, byte3)
    aura_env:setTextureColor(textureNames.maxHealthLowName, byte4, byte5, byte6)

    for k, v in pairs(aura_env.enemyDebuffList.watchKeys) do
        local debuff = unitInfo.playerDebuffs[v]
        if debuff then
            local r, g, b = aura_env:convertDebuffInfoToRGB(debuff)
            aura_env:setTextureColor(textureNames["debuff" .. k .. "Name"], r, g, b)
        else
            aura_env:setTextureColor(textureNames["debuff" .. k .. "Name"], 0, 0, 0)
        end
    end
end

function aura_env:updatePlayerBuffDataToTexture()
    for k, v in pairs(aura_env.playerBuffList["watchKeys"]) do
        local buff = aura_env.playerBuffDataList[v]
        if buff then
            local r, g, b = aura_env:convertDebuffInfoToRGB(buff)
            aura_env:setTextureColor("玩家自身Buff" .. k, r, g, b)
        else
            aura_env:setTextureColor("玩家自身Buff" .. k, 0, 0, 0)
        end
    end
end

--- 更新所有姓名板数据到材质
---@return void
function aura_env:updateAllNameplateDataToTexture()
    for i = 1, 40 do
        aura_env:updateNameplateDataToTexture(i)
    end
end
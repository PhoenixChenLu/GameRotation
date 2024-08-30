-- Desc: This script is used to get player status on start

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
end


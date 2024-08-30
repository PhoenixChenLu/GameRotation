-- Desc: This script is used to get targets status on start

--- 初始化姓名板数据
function aura_env:initializeNameplateData()
    aura_env.nameplateList = {}
end

aura_env:initializeNameplateData()

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

--- 读取单个姓名板数据
---@param index number 索引
---@return table 单个姓名板数据
function aura_env:readNameplateData(index)
    local unit = "nameplate" .. index
    local unitInfo = {}
    unitInfo.exists = UnitExists(unit)
    unitInfo.isDead = UnitIsDead(unit)
    unitInfo.canAttack = UnitCanAttack("player", unit)
    unitInfo.isInCombat = UnitAffectingCombat(unit)
    unitInfo.isThreat = UnitThreatSituation("player", unit)
    local name, text, texture, startTime, endTime, isTradeSkill, castID, notInterruptible, spellID = UnitCastingInfo("player")
    unitInfo.isCasting = name ~= nil
    unitInfo.canInterruptCast = isCasting and not notInterruptible
    name, text, texture, startTime, endTime, isTradeSkill, notInterruptible, spellID = UnitChannelInfo("player")
    unitInfo.isChanneling = name ~= nil
    unitInfo.canInterruptChannel = isChanneling and not notInterruptible
    unitInfo.isInterruptible = unitInfo.canInterruptCast or unitInfo.canInterruptChannel
    unitInfo.isTarget = UnitIsUnit("target", unit)
    unitInfo.isFocus = UnitIsUnit("focus", unit)
    unitInfo.isMouseover = UnitIsUnit("mouseover", unit)
    unitInfo.isBoss1 = UnitIsUnit("boss1", unit)
    unitInfo.isBoss2 = UnitIsUnit("boss2", unit)
    unitInfo.isBoss3 = UnitIsUnit("boss3", unit)
    unitInfo.isBoss4 = UnitIsUnit("boss4", unit)
    unitInfo.isBoss5 = UnitIsUnit("boss5", unit)
    unitInfo.isBoss6 = UnitIsUnit("boss6", unit)
    unitInfo.isBoss7 = UnitIsUnit("boss7", unit)
    unitInfo.isBoss8 = UnitIsUnit("boss8", unit)
    unitInfo.currentHealth = UnitHealth(unit)
    unitInfo.maxHealth = UnitHealthMax(unit)
    unitInfo.currentPower = UnitPower(unit)
    unitInfo.maxPower = UnitPowerMax(unit)
    unitInfo.inMeleeRange = IsItemInRange(37727, unit)
    unitInfo.in25YardRange = IsItemInRange(24268, unit)
    unitInfo.in40YardRange = IsItemInRange(28767, unit)
    aura_env.nameplateList[index] = unitInfo
    return unitInfo
end


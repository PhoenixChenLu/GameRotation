function aura_env:testFunction()
    print("testFunction")
end

function aura_env:test2()
    print("test2")
end

-- 如果不存在用于储存法术ID和法术状态、法术名称的表，则新建
function aura_env:checkAndCreateSpellTable()
    if not aura_env.spellTable then
        aura_env.spellTable = {}
    end
    if not aura_env.spellStatusTable then
        aura_env.spellStatusTable = {}
    end
    if not aura_env.spellNameTable then
        aura_env.spellNameTable = {}
    end
end

aura_env:checkAndCreateSpellTable()

-- 向法术ID表中添加法术ID和法术名称，并同时向法术状态表中添加成员
function aura_env:addSpellToTable(spellID, spellName)
    aura_env.spellTable[spellID] = spellID
    aura_env.spellNameTable[spellID] = spellName
    aura_env.spellStatusTable[spellID] = { currentCharges = 0, maxCharges = 0, cooldownStartTime = 0, cooldownDuration = 0, chargeModRate = 0 }
end

-- 从法术ID表中删除法术ID和法术名称，并同时从法术状态表中删除成员
function aura_env:removeSpellFromTable(spellID)
    aura_env.spellTable[spellID] = nil
    aura_env.spellNameTable[spellID] = nil
    aura_env.spellStatusTable[spellID] = nil
end

-- 检查法术ID表中是否存在某法术ID
function aura_env:checkSpellInTable(spellID)
    return aura_env.spellTable[spellID] ~= nil
end

-- 更新单个法术的状态
function aura_env:updateSpellStatus(spellID)
    local status = C_Spell.GetSpellCharges(spellID)
    if status then
        aura_env.spellStatusTable[spellID] = status
    end
end

-- 更新所有法术的状态
function aura_env:updateAllSpellStatus()
    for spellID, _ in pairs(aura_env.spellTable) do
        aura_env:updateSpellStatus(spellID)
    end
end

-- 打印单个法术的信息
function aura_env:printSpellInfo(spellID)
    if aura_env:checkSpellInTable(spellID) == false then
        print("法术ID: " .. spellID .. " 不存在")
        return
    end

    local spellName = aura_env.spellNameTable[spellID]
    local status = aura_env.spellStatusTable[spellID]
    print("法术ID: " .. spellID)
    print("法术名称: " .. spellName)
    print("当前充能: " .. status.currentCharges)
    print("最大充能: " .. status.maxCharges)
    print("冷却开始时间: " .. status.cooldownStartTime)
    print("冷却持续时间: " .. status.cooldownDuration)
    print("充能速率: " .. status.chargeModRate)
end
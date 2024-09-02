for i = 1, 40 do
    local aura = C_UnitAuras.GetDebuffDataByIndex("target", i, "player")
    if aura then
        print("法术！！！！！")
        for k, v in pairs(aura) do
            print(k, v)
        end
        if aura.spellId == 210824 then
            print("大法师之触")
            for k2, v2 in pairs(aura.points) do
                print(k2, v2)
            end
        end
    end
end

for i = 1, 40 do
    local aura = C_UnitAuras.GetBuffDataByIndex("player", i, "player")
    if aura then
        print("法术！！！！！")
        for k, v in pairs(aura) do
            print(k, v)
        end
    end
end


local auras = {}

for i = 1, 40 do
    local aura = C_UnitAuras.GetDebuffDataByIndex("target", i, "player")
    if aura then
        auras[aura.spellId] = aura
    else
        break
    end
end

return auras

for i = 1, 40 do
    local aura = C_UnitAuras.GetBuffDataByIndex("player", i, "player")
    if aura then
        if aura.spellId == 451049 then
            print("力量的重担")
            print(GetTime(), aura.expirationTime, aura.applications)
        end
    end
end

local coolDown = C_Spell.GetSpellCooldown(212653)
print(coolDown.startTime, coolDown.duration, coolDown.isEnabled)

local charges = C_Spell.GetSpellCharges(212653)
print(charges.currentCharges, charges.maxCharges, charges.cooldownStartTime, charges.cooldownDuration)

local inRange = C_Spell.IsSpellInRange(212653, "target")
print(inRange)
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
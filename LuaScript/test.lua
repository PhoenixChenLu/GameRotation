local attacking = C_Spell.IsCurrentSpell(6603)
print(attacking)

for i = 1, 40 do
    local unit = "nameplate" .. i
    if not UnitIsDead(unit) and UnitCanAttack("player", unit)
    then
        print(unit)
        for k, v in pairs
        print(k, v)
    end
end
end

EditMacro("毁伤特定目标", nil, nil, "#showtooltip 毁伤\n/target \"团队副本训练假人\"")

print(GetMacroBody("毁伤特定目标"))

local debuff = C_UnitAuras.GetAuraDataBySpellName("target", "Amplifying Poison", "PLAYER")
print(debuff)
for k, v in pairs(debuff) do
print(k, v)
end

local aura = C_UnitAuras.GetAuraDataByIndex("target",1)
print(aura)
for k, v in pairs(aura) do
print(k, v)
end

for i = 1, 40 do
local aura = C_UnitAuras.GetAuraDataByIndex("target", i)
if aura then
print(aura.name)
end
end

local enemyDebuffList = {
["keys"] = {118, 122, 212792, 449700, 210824, 453912, 453599},
[118] = "变形术",
[122] = "冰霜新星",
[212792] = "冰锥术",
[449700] = "引力失效",
[210824] = "大法师之触",
[453912] = "大法师的火花",
[453599] = "奥术衰竭",
}

for k, v in pairs(enemyDebuffList.keys) do
print(k, v)
end

for key in ipairs(enemyDebuffList.keys) do
    print(key, enemyDebuffList[key])
end
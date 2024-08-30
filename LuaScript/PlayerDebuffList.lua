function aura_env:initializePlayerDebuffListClasses()
    aura_env.playerDebuffList.DeathKnight = {}
    aura_env.playerDebuffList.DemonHunter = {}
    aura_env.playerDebuffList.Druid = {}
    aura_env.playerDebuffList.Evoker = {}
    aura_env.playerDebuffList.Hunter = {}
    aura_env.playerDebuffList.Mage = {}
    aura_env.playerDebuffList.Monk = {}
    aura_env.playerDebuffList.Paladin = {}
    aura_env.playerDebuffList.Priest = {}
    aura_env.playerDebuffList.Rogue = {}
    aura_env.playerDebuffList.Shaman = {}
    aura_env.playerDebuffList.Warlock = {}
    aura_env.playerDebuffList.Warrior = {}
end

function aura_env:initializeRogueDebuffs()
    aura_env.playerDebuffList.Rogue.Assassination = { [408] = "肾击",
                                                      [703] = "锁喉",
                                                      [1943] = "割裂",
                                                      [2094] = "致盲",
                                                      [2818] = "夺命药膏",
                                                      [3409] = "减速药膏",
                                                      [5760] = "迟钝药膏",
                                                      [8680] = "致伤药膏",
                                                      [121411] = "猩红风暴",
                                                      [1833] = "偷袭",
                                                      [319504] = "毒刃",
                                                      [360194] = "死亡印记",
                                                      [383414] = "增效药膏",
                                                      [385627] = "君王之灾",
                                                      [394021] = "毁伤血肉",
                                                      [394036] = "锯齿骨刺",
    }
end

function aura_env:initializeMageDebuffs()
    aura_env.playerDebuffList.Mage.Arcane = {
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

function aura_env:initializeClassDebuffs()
    aura_env:initializeRogueDebuffs()
    aura_env:initializeMageDebuffs()
end

function aura_env:initializePlayerDebuffList()
    aura_env.playerDebuffList = {}
    aura_env:initializePlayerDebuffListClasses()
    aura_env:initializeClassDebuffs()
end
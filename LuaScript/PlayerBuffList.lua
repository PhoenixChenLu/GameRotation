function aura_env:initialzePlayerBuffListClasses()
    aura_env.playerBuffList.DeathKnight = {}
    aura_env.playerBuffList.DemonHunter = {}
    aura_env.playerBuffList.Druid = {}
    aura_env.playerBuffList.Evoker = {}
    aura_env.playerBuffList.Hunter = {}
    aura_env.playerBuffList.Mage = {}
    aura_env.playerBuffList.Monk = {}
    aura_env.playerBuffList.Paladin = {}
    aura_env.playerBuffList.Priest = {}
    aura_env.playerBuffList.Rogue = {}
    aura_env.playerBuffList.Shaman = {}
    aura_env.playerBuffList.Warlock = {}
    aura_env.playerBuffList.Warrior = {}
end

function aura_env:initializeMageBuffs()
    aura_env.playerBuffList.Mage.Arcane = { [1459] = "奥术智慧",
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
    }
end
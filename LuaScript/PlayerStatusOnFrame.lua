function()
    if not aura_env.currentTime or GetTime() - aura_env.currentTime > aura_env.config.updateRate
    then
        aura_env.readAllPlayerData()
        aura_env.readAllNamePlateData()
        aura_env.readPlayerBuffData()
        aura_env.readPlayerSpellData()
        aura_env.updateAllPlayerDataToTexture()
        aura_env.updateAllNameplateDataToTexture()
        aura_env.updatePlayerBuffDataToTexture()
        aura_env.updatePlayerSpellDataToTexture()
    end
end
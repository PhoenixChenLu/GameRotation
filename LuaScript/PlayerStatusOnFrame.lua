function()
    if not aura_env.currentTime or GetTime() - aura_env.currentTime > aura_env.config.updateRate
    then
        aura_env.readAllPlayerData()
        aura_env.updateAllPlayerDataToTexture()
    end
end
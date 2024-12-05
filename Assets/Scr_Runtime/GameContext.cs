using System;


namespace DJ {

    public class GameContext {
        public AssetsCore assetsCore;

        // repos
        public PlayerRepository playerRepository;
        public PlatformRepository platformRepository;

        public GameContext() {
            assetsCore = new AssetsCore();

            // repos 
            playerRepository = new PlayerRepository();
            platformRepository = new PlatformRepository();
        }
    }
}
using System;


namespace DJ {

    public class GameContext {
        public AssetsCore assetsCore;
        public InputCore inputCore;
        // repos
        public PlayerRepository playerRepository;
        public PlatformRepository platformRepository;

        public GameContext() {
            assetsCore = new AssetsCore();
            inputCore = new InputCore();

            // repos 
            playerRepository = new PlayerRepository();
            platformRepository = new PlatformRepository();
        }
    }
}
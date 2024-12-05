using System;


namespace DJ {

    public class GameContext {
        public AssetsCore assetsCore;

        // repos
        public PlayerRepository playerRepository;

        public GameContext() {
            assetsCore = new AssetsCore();

            // repos 
            playerRepository = new PlayerRepository();
        }
    }
}
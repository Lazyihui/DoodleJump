using System;
using UnityEngine;
using UnityEngine.UI;


namespace DJ {

    public class GameContext {
        public AssetsCore assetsCore;
        public InputCore inputCore;
        public UIApp uiApp;
        // repos
        public PlayerRepository playerRepository;
        public PlatformRepository platformRepository;
        public AudioEntity audioEntity;

        public GameContext() {
            assetsCore = new AssetsCore();
            inputCore = new InputCore();
            uiApp = new UIApp();

            // repos 
            playerRepository = new PlayerRepository();
            platformRepository = new PlatformRepository();
        }

        public void Inject(Canvas canvas) {
            uiApp.Inject(assetsCore, canvas);
        }
    }
}
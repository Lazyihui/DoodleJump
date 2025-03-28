using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace DJ {

    public class GameContext {
        public AssetsCore assetsCore;
        public InputCore inputCore;
        public UIApp uiApp;
        // repos

        // temp
        public InputRebindingSystem inputRebindingSystem;
        public GameContext() {
            assetsCore = new AssetsCore();
            inputCore = new InputCore();
            uiApp = new UIApp();

            // temp
            inputRebindingSystem = new InputRebindingSystem();

        }

        public void Inject(Canvas canvas, InputActionAsset inputActionAsset) {
            uiApp.Inject(assetsCore, canvas);
            inputRebindingSystem.Inject(uiApp, inputActionAsset);
        }
    }
}
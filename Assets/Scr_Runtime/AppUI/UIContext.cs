using System;
using System.Collections.Generic;
using UnityEngine;


namespace DJ {

    public class UIContext {

        public UIEvent uIEvent;
        // Core
        public AssetsCore assetsCore;
        public Canvas canvas;

        // panel
        public Panel_Login panel_Login;

        public UIContext() {
            uIEvent = new UIEvent();
        }

        public void Inject(AssetsCore assetsCore, Canvas canvas) {
            this.assetsCore = assetsCore;
            this.canvas = canvas;
        }
    }
}
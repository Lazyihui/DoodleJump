using System;
using UnityEngine;

namespace DJ {

    public class UIApp {

        UIContext ctx;

        // public UIEvent events {
        //     get {
        //         return ctx.uIEvent;
        //     }
        //     set {
        //         ctx.uIEvent = value;
        //     }
        // }
        public UIEvent events => ctx.uIEvent;

        public UIEvent GetEvents() {
            return ctx.uIEvent;
        }

        public void SetEvents(UIEvent value) {
            ctx.uIEvent = value;
        }

        public UIApp() {
            ctx = new UIContext();
        }

        public void Inject(AssetsCore assetsCore, Canvas canvas) {
            ctx.Inject(assetsCore, canvas);
        }

        public void Panel_Login_Open() {
            Panel_Login panel = ctx.panel_Login;

            if (panel == null) {
                Debug.Assert(ctx != null, "UIContext is null");
                Debug.Assert(ctx.canvas != null, "Canvas is null");
                GameObject go = ctx.assetsCore.Panel_GetLogin();
                // bool has = ctx.assetsCore.PanelS.TryGetValue("Panel_Login", out GameObject go);
                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_Login>();
                panel.Ctor();

                panel.OnBtnLoginHandle += () => {
                    ctx.uIEvent.OnBtnLogin();
                };
                panel.OnBtnPointerUpHandle += () => {
                    ctx.uIEvent.OnBtnPointerUp();
                };

            }

            ctx.panel_Login = panel;
        }

        public void Panel_Login_Close() {
            Panel_Login panel = ctx.panel_Login;
            if (panel == null) {
                return;
            }
            panel.TearDown();
        }

        public void OnBtn() {

        }

    }
}
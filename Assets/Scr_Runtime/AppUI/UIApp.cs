using System;
using UnityEngine;

namespace DJ {

    public class UIApp {

        public UIContext ctx;

        public UIApp() {
            ctx = new UIContext();
        }

        public void Panel_Login_Open() {
            Panel_Login panel = ctx.panel_Login;

            if (panel == null) {
                Debug.Assert(ctx != null, "UIContext is null");
                Debug.Assert(ctx.canvas != null, "Canvas is null");

                GameObject go = ctx.assetsCore.Panel_GetLogin();
                Debug.Assert(go != null, "Panel_Login is null");

                // bool has = ctx.assetsCore.PanelS.TryGetValue("Panel_Login", out GameObject go);
                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_Login>();
                panel.Ctor();

                panel.OnBtnLoginHandle += () => {
                    ctx.uIEvent.OnBtnLogin();
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
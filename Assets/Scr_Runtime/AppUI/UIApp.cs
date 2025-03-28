using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            LazyUtil.audioSource = new GameObject("Audio").AddComponent<AudioSource>();
        }

        public void Panel_Login_Open() {
            Panel_Login panel = ctx.panel_Login;

            if (panel == null) {
                GameObject go = ctx.assetsCore.Panel_GetLogin();
                // bool has = ctx.assetsCore.PanelS.TryGetValue("Panel_Login", out GameObject go);
                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_Login>();
                panel.Ctor();

                panel.OnBtnLoginHandle += () => {
                    ctx.uIEvent.OnBtnLogin();
                };
                panel.OnBtnPointerEnterHandle += () => {
                    ctx.uIEvent.OnBtnPointerEnter();
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
        public void Panel_Setting_Open() {
            Panel_Setting panel = ctx.panel_Setting;

            if (panel == null) {
                Debug.Assert(ctx != null, "UIContext is null");
                Debug.Assert(ctx.canvas != null, "Canvas is null");
                GameObject go = ctx.assetsCore.Panel_GetSetting();
                // bool has = ctx.assetsCore.PanelS.TryGetValue("Panel_Setting", out GameObject go);
                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_Setting>();
                panel.Ctor();

                panel.OnBtnLoginHandle += () => {
                    ctx.uIEvent.OnButtonSetting();
                };

                panel.OnBtnLogin2Handle += () => {
                    ctx.uIEvent.OnButtonSetting2();
                };

                panel.OnBtnLogin3Handle += () => {
                    ctx.uIEvent.OnButtonSetting3();
                };

                panel.OnBtnLogin4Handle += () => {
                    ctx.uIEvent.OnButtonSetting3();
                };

            }

            ctx.panel_Setting = panel;
        }

        public Button GetBtnLogin() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            Debug.Assert(panel != null, "Panel_Setting is null");
            Debug.Assert(panel.GetBtnLogin() != null, "GetBtnLogin is null");
            return panel.GetBtnLogin();
        }
        public Button GetBtnLogin2() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            return panel.GetBtnLogin2();
        }
        public Button GetBtnLogin3() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            return panel.GetBtnLogin3();
        }
        public Button GetBtnLogin4() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            return panel.GetBtnLogin4();
        }
        public TextMeshProUGUI GetText() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            return panel.GetText();
        }
        public TextMeshProUGUI GetText2() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            return panel.GetText2();
        }
        public TextMeshProUGUI GetText3() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            return panel.GetText3();
        }
        public TextMeshProUGUI GetText4() {
            Panel_Setting panel = ctx.panel_Setting;
            if (panel == null) {
                return null;
            }
            return panel.GetText4();
        }

        public void Panel_CountDown_Open() {
            Panel_CountDown panel = ctx.panel_CountDown;

            if (panel == null) {
                GameObject go = ctx.assetsCore.Panel_GetCountDown();
                // bool has = ctx.assetsCore.PanelS.TryGetValue("Panel_CountDown", out GameObject go);
                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_CountDown>();
                panel.Ctor();
            }

            ctx.panel_CountDown = panel;
        }

        public void Panel_CountDown_SetText(float time) {
            Panel_CountDown panel = ctx.panel_CountDown;
            if (panel == null) {
                return;
            }
            panel.SetText(time);
        }



        public void Panel_CountDown_Close() {
            Panel_CountDown panel = ctx.panel_CountDown;
            if (panel == null) {
                return;
            }
            panel.TearDown();
        }
    }
}
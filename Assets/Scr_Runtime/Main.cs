using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DJ {
    public class main : MonoBehaviour {

        GameContext ctx;
        bool isTearDown = false;

        [SerializeField] InputActionAsset inputActionAsset;

        void Awake() {
            // ==== Instantiate ====
            ctx = new GameContext();

            Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            Debug.Assert(ctx != null, "ctx is null");


            ctx.Inject(canvas, inputActionAsset);

            ctx.inputRebindingSystem.Init();
            // // ==== Binding ====

            // // ==== Init ====
            ctx.assetsCore.LoadAll();

            // // ==== Enter ====
            // Debug.Log("Hello World");

            // Login_Business.Enter(ctx);


            Binding();
            ctx.uiApp.Panel_Setting_Open();
        }

        void Binding() {

            var uIEvent = ctx.uiApp.events;

            uIEvent.OnButtonSettingHandle += () => {
                ctx.uiApp.Panel_CountDown_Open();
                ctx.inputRebindingSystem.StartRebinding(ctx.inputRebindingSystem.ctx.rebindings[0]);
            };

            uIEvent.OnButtonSetting2Handle += () => {
                ctx.uiApp.Panel_CountDown_Open();

            };

            uIEvent.OnButtonSetting3Handle += () => {
                ctx.uiApp.Panel_CountDown_Open();

            };

            uIEvent.OnButtonSetting4Handle += () => {
                ctx.uiApp.Panel_CountDown_Open();

            };
        }

        float time = 0f;

        bool isStart = false;

        void Update() {
            float dt = Time.deltaTime;
            var uiApp = ctx.uiApp;

            time += dt;
            uiApp.Panel_CountDown_SetText(time);
            if (time > 3f) {
                uiApp.Panel_CountDown_Close();
            }

            ctx.inputCore.ProcessMove();

            if (ctx.inputCore.IsHpress) {
                isStart = true;

                isStart = false;
            }

            if (ctx.inputCore.IsQPress) {
                isStart = true;

                isStart = false;
            }

            if (ctx.inputCore.IsRPress) {
                isStart = true;

                isStart = false;
            }

            if (ctx.inputCore.IsEpress) {
                isStart = true;

                isStart = false;
            }

        }

        void OnDstroy() {
            TearDown();
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;
            ctx.assetsCore.UnLoadAll();
        }
    }
}

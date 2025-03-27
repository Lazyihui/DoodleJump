using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ {
    public class main : MonoBehaviour {

        GameContext ctx;
        bool isTearDown = false;

        void Awake() {
            // ==== Instantiate ====
            ctx = new GameContext();

            Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            ctx.Inject(canvas);

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

            // uIEvent.OnBtnLoginHandle += () => {
            //     ctx.uiApp.Panel_Login_Close();
            //     Game_Business.Enter(ctx);
            // };

            // uIEvent.OnBtnPointerEnterHandle += () => {
            //     if (ctx.audioEntity == null) {  
            //         ctx.audioEntity = AudioDomain.Spawn(ctx, 0);
            //         AudioDomain.Play(ctx);
            //     } else {
            //         AudioDomain.Play(ctx);
            //     }
            // };

            uIEvent.OnButtonSettingHandle += () => {
                
                Debug.Log("OnButtonSettingHandle");
            };

            uIEvent.OnButtonSetting2Handle += () => {
                Debug.Log("OnButtonSetting2Handle");
            };

            uIEvent.OnButtonSetting3Handle += () => {
                Debug.Log("OnButtonSetting3Handle");
            };

            uIEvent.OnButtonSetting4Handle += () => {
                Debug.Log("OnButtonSetting4Handle");
            };
        }

        void Update() {
            // float dt = Time.deltaTime;

            // ctx.inputCore.ProcessMove();

            // int playerlen = ctx.playerRepository.TakeAll(out PlayerEntity[] players);
            // for (int i = 0; i < playerlen; i++) {
            //     PlayerEntity player = players[i];
            //     PlayerDomain.Move(ctx, player);
            // }
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

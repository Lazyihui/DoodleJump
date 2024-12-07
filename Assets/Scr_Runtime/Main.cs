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

            // ==== Binding ====

            // ==== Init ====
            ctx.assetsCore.LoadAll();

            // ==== Enter ====
            Debug.Log("Hello World");

            Login_Business.Enter(ctx);

            Binding();
        }

        void Binding() {

            var uIEvent = ctx.uiApp.events;

            uIEvent.OnBtnLoginHandle += () => {
                ctx.uiApp.Panel_Login_Close();
                Game_Business.Enter(ctx);
            };

            uIEvent.OnBtnPointerUpHandle += () => {
                Debug.Log("OnBtnPointerUpHandle");
            };
        }

        void Update() {
            float dt = Time.deltaTime;

            ctx.inputCore.ProcessMove();

            int playerlen = ctx.playerRepository.TakeAll(out PlayerEntity[] players);
            for (int i = 0; i < playerlen; i++) {
                PlayerEntity player = players[i];
                PlayerDomain.Move(ctx, player);
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

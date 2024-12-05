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

            // ==== Binding ====

            // ==== Init ====
            ctx.assetsCore.LoadAll();

            // ==== Enter ====
            Debug.Log("Hello World");
            PlayerDomain.Spawn(ctx, 1);
            PlatformDomain.Spawn(ctx, 1);
        }

        void Binding() {

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

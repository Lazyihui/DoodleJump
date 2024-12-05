using System;
using UnityEngine;

namespace DJ {
    public static class Login_Business {

        public static void Enter(GameContext ctx) {
            ctx.uiApp.Panel_Login_Open();
        }


        public static void Tick(GameContext ctx, float dt) {

        }

        public static void Exit(GameContext ctx) {

        }

    }
}
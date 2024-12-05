using System;
using UnityEngine;

namespace DJ {
    public static class Game_Business {

        public static void Enter(GameContext ctx) {

            PlayerDomain.Spawn(ctx, 1);
            PlatformDomain.Spawn(ctx, 1);

        }


        public static void Tick(GameContext ctx, float dt) {

        }

        public static void Exit(GameContext ctx) {

        }

    }
}
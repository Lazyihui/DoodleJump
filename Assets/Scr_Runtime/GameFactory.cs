using System;
using UnityEngine;


namespace DJ {

    public static class GameFactory {
        public static PlayerEntity Player_Create(GameContext ctx, int typeID) {
            GameObject go = ctx.assetsCore.Entity_GetPlayer();
            go = GameObject.Instantiate(go);

            PlayerEntity entity = go.GetComponent<PlayerEntity>();
            entity.Ctor();
            return entity;
        }

        public static PlatformEntity Platform_Create(GameContext ctx, int typeID) {
            GameObject go = ctx.assetsCore.Entity_GetPlatform();
            go = GameObject.Instantiate(go);

            PlatformEntity entity = go.GetComponent<PlatformEntity>();
            entity.Ctor();
            return entity;
        }

        public static AudioEntity Audio_Create(GameContext ctx, int typeID) {
            GameObject go = ctx.assetsCore.Entity_GetAudio();
            go = GameObject.Instantiate(go);

            AudioEntity entity = go.GetComponent<AudioEntity>();
            entity.Ctor();
            return entity;
        }

    }
}
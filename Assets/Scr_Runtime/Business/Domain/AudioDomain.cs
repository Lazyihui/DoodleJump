using System;
using UnityEngine;

namespace DJ {

    public static class AudioDomain {
        public static AudioEntity Spawn(GameContext ctx, int typeID) {
            AudioEntity entity = GameFactory.Audio_Create(ctx, typeID);
            ctx.audioEntity = entity;
            return entity;
        }

        public static void Play(GameContext ctx) {
            ctx.audioEntity.Play();
        }
    }
}
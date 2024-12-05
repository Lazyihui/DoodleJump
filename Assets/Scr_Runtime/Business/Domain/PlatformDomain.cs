using System;
using System.Collections;
using UnityEngine;


namespace DJ {

    public static class PlatformDomain {
        public static PlatformEntity Spawn(GameContext ctx, int typeID) {
            PlatformEntity entity = GameFactory.Platform_Create(ctx, typeID);
            ctx.platformRepository.Add(entity);
            return entity;
        }

    }

}
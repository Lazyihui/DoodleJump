using System;
using UnityEngine;


namespace DJ {

    public static class GameFactory {
        public static PlayerEntity Player_Creat(GameContext ctx, int typeID) {
            GameObject go = ctx.assetsCore.Entity_GetPlayer();
            go = GameObject.Instantiate(go);
            
            PlayerEntity entity = go.GetComponent<PlayerEntity>();
            entity.Ctor();
            return entity;
        }

    }
}
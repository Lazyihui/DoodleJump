using System;
using System.Collections;
using UnityEngine;


namespace DJ {

    public static class PlayerDomain {
        public static PlayerEntity Spawn(GameContext ctx, int typeID) {
            PlayerEntity entity = GameFactory.Player_Create(ctx, typeID);
            ctx.playerRepository.Add(entity);
            Debug.Log(entity.name);
            Debug.Log("PlayerDomain.Spawn");
            return entity;
        }

        public static void Move(GameContext ctx, PlayerEntity Player) {
            InputCore input = ctx.inputCore;
            Player.Move(input.moveAxis,input.faceAxis);
        }
    }
}
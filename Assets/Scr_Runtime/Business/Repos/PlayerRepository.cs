using System;

using System.Collections.Generic;


namespace DJ {

    public class PlayerRepository {

        Dictionary<int, PlayerEntity> all;

        PlayerEntity[] temArray;

        public PlayerRepository() {
            all = new Dictionary<int, PlayerEntity>();
            temArray = new PlayerEntity[1000];
        }

        public void Add(PlayerEntity entity) {
            all.Add(entity.id, entity);
        }
        public void Remove(PlayerEntity entity) {
            all.Remove(entity.id);
        }
        public int TakeAll(out PlayerEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new PlayerEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;

        }
        //委托 Predicate<PlayerEntity> Action<>
        public PlayerEntity Find(Predicate<PlayerEntity> predicate) {
            foreach (PlayerEntity Player in all.Values) {
                bool isMatch = predicate(Player);

                if (isMatch) {
                    return Player;
                }
            }
            return null;
        }

    }
}

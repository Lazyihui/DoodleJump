using System;

using System.Collections.Generic;


namespace DJ {

    public class PlatformRepository {

        Dictionary<int, PlatformEntity> all;

        PlatformEntity[] temArray;

        public PlatformRepository() {
            all = new Dictionary<int, PlatformEntity>();
            temArray = new PlatformEntity[1000];
        }

        public void Add(PlatformEntity entity) {
            all.Add(entity.id, entity);
        }
        public void Remove(PlatformEntity entity) {
            all.Remove(entity.id);
        }
        public int TakeAll(out PlatformEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new PlatformEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;

        }

    }
}

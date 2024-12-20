using System;

using System.Collections.Generic;


namespace DJ {

    public class AudioRepository {

        Dictionary<int, AudioEntity> all;

        AudioEntity[] temArray;

        public AudioRepository() {
            all = new Dictionary<int, AudioEntity>();
            temArray = new AudioEntity[1000];
        }

        public void Add(AudioEntity entity) {
            all.Add(entity.id, entity);
        }
        public void Remove(AudioEntity entity) {
            all.Remove(entity.id);
        }
        public int TakeAll(out AudioEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new AudioEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;

        }

    }
}

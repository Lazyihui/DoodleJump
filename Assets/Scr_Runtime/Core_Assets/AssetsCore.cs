using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

namespace DJ {


    public class AssetsCore {
        public Dictionary<string, GameObject> entities;
        public AsyncOperationHandle entitiesHandle;

        public AssetsCore() {
            entities = new Dictionary<string, GameObject>();
        }

        public void LoadAll() {
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "Entity";
                var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = ptr.WaitForCompletion();
                foreach (var go in list) {
                    entities.Add(go.name, go);
                }
                entitiesHandle = ptr;
            }
        }


        public void UnLoadAll() {
            if (entitiesHandle.IsValid()) {
                Addressables.Release(entitiesHandle);
            }

        }
        // Entity
        public GameObject Entity_GetPlayer() {
            entities.TryGetValue("Entity_Player", out GameObject entity);
            if (entity == null) {
                Debug.LogError("Entity_Player is null");
            }
            return entity;
        }

        public GameObject Entity_GetPlatform() {
            entities.TryGetValue("Entity_Platform", out GameObject entity);
            return entity;
        }

    }
}
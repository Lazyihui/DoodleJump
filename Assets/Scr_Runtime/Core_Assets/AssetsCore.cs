using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

namespace DJ {


    public class AssetsCore {
        // public Dictionary<string, GameObject> entities;
        // public AsyncOperationHandle entitiesHandle;

        public Dictionary<string, GameObject> panels;
        public AsyncOperationHandle panelSHandle;



        public AssetsCore() {
            // entities = new Dictionary<string, GameObject>();
            panels = new Dictionary<string, GameObject>();
        }

        public void LoadAll() {
            // {
            //     AssetLabelReference labelReference = new AssetLabelReference();
            //     labelReference.labelString = "Entity";
            //     var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
            //     var list = ptr.WaitForCompletion();
            //     foreach (var go in list) {
            //         entities.Add(go.name, go);
            //     }
            //     entitiesHandle = ptr;
            // }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "Panel";
                var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = ptr.WaitForCompletion();
                foreach (var go in list) {
                    panels.Add(go.name, go);
                }
                panelSHandle = ptr;
            }
        }


        public void UnLoadAll() {
            // if (entitiesHandle.IsValid()) {
            //     Addressables.Release(entitiesHandle);
            // }
            if (panelSHandle.IsValid()) {
                Addressables.Release(panelSHandle);
            }
        }

        // Panel
        public GameObject Panel_GetLogin() {
            panels.TryGetValue("Panel_Login", out GameObject panel);
            if (panel == null) {
                Debug.LogError("Panel_Login is null");
            }
            return panel;
        }

        public GameObject Panel_GetSetting() {
            panels.TryGetValue("Panel_Setting", out GameObject panel);
            if (panel == null) {
                Debug.LogError("Panel_Setting is null");
            }
            return panel;
        }

        public GameObject Panel_GetCountDown() {
            panels.TryGetValue("Panel_CountDown", out GameObject panel);
            if (panel == null) {
                Debug.LogError("Panel_CountDown is null");
            }
            return panel;
        }

    }
}
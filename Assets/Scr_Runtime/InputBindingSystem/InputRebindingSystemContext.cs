using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace DJ {

    public class InputRebindingSystemContext {
        //  
        public UIApp uiApp;
        public InputActionAsset inputActions;
        public List<RebindingData> rebindings = new List<RebindingData>();

        public InputAction currentAction;
        public int currentBindingIndex;
        public InputActionRebindingExtensions.RebindingOperation rebindOperation;

        public InputRebindingSystemContext() {
            rebindings = new List<RebindingData>();
        }

        public void Inject(UIApp uIApp, InputActionAsset inputActions) {
            this.uiApp = uIApp;
            this.inputActions = inputActions;
        }

        public void CreateData(string actionMapName, string actionName, int bindingIndex, string displayName) {
            RebindingData data = new RebindingData {
                actionMapName = actionMapName,
                actionName = actionName,
                bindingIndex = bindingIndex,
                displayName = displayName,
            };
            rebindings.Add(data);
        }
    }
}
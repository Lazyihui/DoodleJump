using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace DJ {

    public class InputRebindingSystem {

        // InputBindingSystem;

        public InputRebindingSystemContext ctx;


        public InputRebindingSystem() {
            ctx = new InputRebindingSystemContext();
        }

        public void Init() {

            ctx.CreateData("Player1Controls", "HPress", 0, "H Press");
            ctx.CreateData("Player1Controls", "QPress", 0, "Q Press");

            InitializeUI();
            LoadBindings();

        }
        public void Inject(UIApp uiApp, InputActionAsset inputActionAsset) {

            ctx.Inject(uiApp, inputActionAsset);
        }


        private void InitializeUI() {
            var rebindings = ctx.rebindings;
            Debug.Log(rebindings.Count);
            foreach (var data in rebindings) {
                // 设置按钮事件
                // 初始化显示
                UpdateBindingDisplay(data);
                Debug.Log(data.actionMapName + " " + data.actionName + " " + data.bindingIndex + " " + data.displayName);
            }
        }

        public void StartRebinding(RebindingData data) {
            var inputActions = ctx.inputActions;
            var currentAction = ctx.currentAction;
            var rebindOperation = ctx.rebindOperation;
            var currentBindingIndex = ctx.currentBindingIndex;

            currentAction = inputActions.FindActionMap(data.actionMapName).FindAction(data.actionName);
            currentBindingIndex = data.bindingIndex;

            // 禁用Action和按钮
            currentAction.Disable();


            Debug.Log($"Rebinding {data.actionMapName} {data.actionName} {data.bindingIndex} {data.displayName}");

            // 开始重绑定
            rebindOperation = currentAction.PerformInteractiveRebinding(data.bindingIndex)
                .WithControlsExcluding("<Mouse>/position")
                .WithControlsExcluding("<Mouse>/delta")
                .WithControlsExcluding("<Pointer>/position")
                .WithCancelingThrough("<Keyboard>/escape")
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation => RebindComplete(data))
                .OnCancel(operation => RebindCanceled(data))
                .Start();

            Debug.Log($"Rebinding {data.actionMapName} {data.actionName} {data.bindingIndex} {data.displayName}");

        }

        private void RebindComplete(RebindingData data) {
            var inputActions = ctx.inputActions;
            var currentAction = ctx.currentAction;
            var rebindOperation = ctx.rebindOperation;

            rebindOperation.Dispose();

            currentAction.Enable();

            UpdateBindingDisplay(data);
            SaveBindings();
        }

        private void RebindCanceled(RebindingData data) {
            var inputActions = ctx.inputActions;
            var currentAction = ctx.currentAction;
            var rebindOperation = ctx.rebindOperation;

            rebindOperation.Dispose();

            currentAction.Enable();

            UpdateBindingDisplay(data);
        }

        public void ResetBinding(RebindingData data) {
            var inputActions = ctx.inputActions;

            var action = inputActions.FindActionMap(data.actionMapName).FindAction(data.actionName);
            action.RemoveBindingOverride(data.bindingIndex);

            UpdateBindingDisplay(data);
            SaveBindings();
        }

        private void UpdateBindingDisplay(RebindingData data) {
            var inputActions = ctx.inputActions;

            var action = inputActions.FindActionMap(data.actionMapName).FindAction(data.actionName);
        }

        private void SaveBindings() {
            var inputActions = ctx.inputActions;

            string rebinds = inputActions.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("InputRebinds", rebinds);
        }

        public void LoadBindings() {
            var inputActions = ctx.inputActions;
            var rebindings = ctx.rebindings;

            string rebinds = PlayerPrefs.GetString("InputRebinds");
            if (!string.IsNullOrEmpty(rebinds)) {
                inputActions.LoadBindingOverridesFromJson(rebinds);
            }

            // 更新所有UI显示
            foreach (var data in rebindings) {
                UpdateBindingDisplay(data);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RebindingManager : MonoBehaviour {

    public InputActionAsset inputActions;    // 引用Input Action Asset
    public string actionName;    // 要重绑定的Action名称
    public int bindingIndex; // 可选的绑定索引（如果有多个绑定）
    public Text bindingDisplayNameText;// 显示当前按键的Text组件

    public GameObject rebindPrompt;// 重绑定时的提示文本

    // 排除的鼠标按钮（如果需要）
    // public InputBinding.Mask excludedMouseButtons = InputBinding.MaskByGroup("Mouse");

    InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    InputAction targetedAction; // 当前绑定的InputAction

    Controls playerInput;

    void Start() {
        // 获取目标Action
        targetedAction = inputActions.FindAction(actionName);
        if (targetedAction == null) {
            Debug.LogError("Action not found: " + actionName);
            return;
        }

        // 更新显示
        UpdateBindingDisplay();

        playerInput = new Controls();
        playerInput.Enable();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            rebindPrompt.SetActive(false);
            RebindCanceled();
        }

        if (Input.GetKeyDown(KeyCode.F1)) {
            StartRebinding();
        }

        var player = playerInput.PlayerControls;

        bool move = player.Move.WasPerformedThisFrame();
        if (move) {
            Debug.Log("Move");
        }


    }

    // 开始重绑定过程
    public void StartRebinding() {
        rebindPrompt.SetActive(true);
        bindingDisplayNameText.text = "Press any key...";

        // 先禁用目标Action
        targetedAction.Disable();

        // 开始重绑定操作
        rebindingOperation = targetedAction.PerformInteractiveRebinding(bindingIndex)
            .WithControlsExcluding("Mouse") // 可选：排除鼠标
            .WithCancelingThrough("<Keyboard>/escape") // 设置取消键
            .OnMatchWaitForAnother(0.1f)// 设置按键间隔
            .OnComplete(operation => RebindComplete())
            .OnCancel(operation => RebindCanceled())
            .Start();
    }

    private void RebindComplete() {
        // 更新显示
        UpdateBindingDisplay();

        // 清理操作
        rebindingOperation.Dispose();

        // 重新启用Action
        targetedAction.Enable();

        rebindPrompt.SetActive(false);

        // 保存绑定
        SaveBindingOverride();
    }

    private void RebindCanceled() {
        rebindingOperation.Dispose();
        targetedAction.Enable();
        rebindPrompt.SetActive(false);
        UpdateBindingDisplay();
    }

    // 更新UI显示
    private void UpdateBindingDisplay() {
        if (targetedAction != null) {
            bindingDisplayNameText.text = targetedAction.GetBindingDisplayString(bindingIndex);//只是用于显示
        }
    }

    // 保存绑定覆盖
    private void SaveBindingOverride() {
        string rebinds = inputActions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
        PlayerPrefs.Save();
        Debug.Log("Saved rebinds: " + rebinds);
    }

    // 加载保存的绑定
    public void LoadBindingOverride() {
        string rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds)) {
            inputActions.LoadBindingOverridesFromJson(rebinds);
        }
        UpdateBindingDisplay();
    }

    // 重置为默认绑定 //
    public void ResetBinding() {
        targetedAction.RemoveBindingOverride(bindingIndex);
        UpdateBindingDisplay();
        SaveBindingOverride();
    }

    private void OnEnable() {
        LoadBindingOverride();
    }
}
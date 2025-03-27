using System;
using UnityEngine;

namespace DJ {

    public class UIEvent {
        public Action OnBtnLoginHandle;

        public void OnBtnLogin() {
            if (OnBtnLoginHandle != null) {
                OnBtnLoginHandle?.Invoke();
            }
        }

        public Action OnBtnPointerEnterHandle;
        public void OnBtnPointerEnter() {
            if (OnBtnPointerEnterHandle != null) {
                OnBtnPointerEnterHandle?.Invoke();
            }
        }

        public Action OnButtonSettingHandle;
        public void OnButtonSetting() {
            if (OnButtonSettingHandle != null) {
                OnButtonSettingHandle?.Invoke();
            }

        }

        public Action OnButtonSetting2Handle;

        public void OnButtonSetting2() {
            if (OnButtonSetting2Handle != null) {
                OnButtonSetting2Handle?.Invoke();
            }
        }

        public Action OnButtonSetting3Handle;

        public void OnButtonSetting3() {
            if (OnButtonSetting3Handle != null) {
                OnButtonSetting3Handle?.Invoke();
            }
        }

        public Action OnButtonSetting4Handle;

        public void OnButtonSetting4() {
            if (OnButtonSetting4Handle != null) {
                OnButtonSetting4Handle?.Invoke();
            }
        }

    }
}
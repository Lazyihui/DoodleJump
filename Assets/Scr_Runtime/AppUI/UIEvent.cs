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
    }
}
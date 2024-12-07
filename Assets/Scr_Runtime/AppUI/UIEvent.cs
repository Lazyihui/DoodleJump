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

        public Action OnBtnPointerUpHandle;
        public void OnBtnPointerUp() {
            if (OnBtnPointerUpHandle != null) {
                OnBtnPointerUpHandle?.Invoke();
            }
        }
    }
}
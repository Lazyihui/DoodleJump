using System;
using UnityEngine;

namespace DJ {

    public class UIEvent {
        public Action OnBtnLoginHandle;

        public void OnBtnLogin() {
            if (OnBtnLoginHandle != null) {
                Debug.Log("OnBtnLoginHandle555555555");
                OnBtnLoginHandle?.Invoke();
            }
        }
    }
}
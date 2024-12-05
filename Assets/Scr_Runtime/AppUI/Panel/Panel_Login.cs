using System;
using UnityEngine;
using UnityEngine.UI;

namespace DJ {
    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button btnLogin;
        public Action OnBtnLoginHandle;

        public void Ctor() {
            btnLogin.onClick.AddListener(() => {
                if (OnBtnLoginHandle != null) {
                    OnBtnLoginHandle?.Invoke();
                }
            });
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }
}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace DJ {
    public class Panel_Setting : MonoBehaviour {

        public Button btnLogin;
        public Action OnBtnLoginHandle;
        public Button btnLogin2;
        public Action OnBtnLogin2Handle;

        public Button btnLogin3;
        public Action OnBtnLogin3Handle;
        public Button btnLogin4;
        public Action OnBtnLogin4Handle;

        // button的文字
        public TextMeshProUGUI txtLogin;
        public TextMeshProUGUI txtLogin2;
        public TextMeshProUGUI txtLogin3;
        public TextMeshProUGUI txtLogin4;

        public void Ctor() {
            btnLogin.onClick.AddListener(() => {
                if (OnBtnLoginHandle != null) {
                    OnBtnLoginHandle?.Invoke();
                }
            });

            btnLogin2.onClick.AddListener(() => {
                if (OnBtnLogin2Handle != null) {
                    OnBtnLogin2Handle?.Invoke();
                }
            });

            btnLogin3.onClick.AddListener(() => {
                if (OnBtnLogin3Handle != null) {
                    OnBtnLogin3Handle?.Invoke();
                }
            });

            btnLogin4.onClick.AddListener(() => {
                if (OnBtnLogin4Handle != null) {
                    OnBtnLogin4Handle?.Invoke();
                }
            });

        }

        public void SetText(string txt) {
            txtLogin.text = txt;
        }

        public void SetText2(string txt) {
            txtLogin2.text = txt;
        }

        public void SetText3(string txt) {
            txtLogin3.text = txt;
        }

        public void SetText4(string txt) {
            txtLogin4.text = txt;
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DJ {
    public class Panel_Login : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler {

        public LazyButton btnLogin;
        public LazyButton btnLogin2;
        public LazyButton btnLogin3;
        public LazyButton btnLogin4;
        public Action OnBtnLoginHandle;
        public Action OnBtnPointerEnterHandle;

        public void Ctor() {
            btnLogin.btn.onClick.AddListener(() => {
                if (OnBtnLoginHandle != null) {
                    OnBtnLoginHandle?.Invoke();
                }
            });

            btnLogin.OnBtnPointerEnterHandle = () => {
                if (OnBtnPointerEnterHandle != null) {
                    OnBtnPointerEnterHandle?.Invoke();
                }
            };
            btnLogin2.OnBtnPointerEnterHandle = () => {
                if (OnBtnPointerEnterHandle != null) {
                    OnBtnPointerEnterHandle?.Invoke();
                }
            };
            btnLogin3.OnBtnPointerEnterHandle = () => {
                if (OnBtnPointerEnterHandle != null) {
                    OnBtnPointerEnterHandle?.Invoke();
                }
            };
            btnLogin4.OnBtnPointerEnterHandle = () => {
                if (OnBtnPointerEnterHandle != null) {
                    OnBtnPointerEnterHandle?.Invoke();
                }
            };

        }

        public void TearDown() {
            Destroy(gameObject);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) {
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
        }
    }
}
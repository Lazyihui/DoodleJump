using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace DJ {

    public class LazyButton : MonoBehaviour, ISelectHandler/*点击时使用*/, IPointerMoveHandler/*鼠标移动时使用*/,
    IPointerUpHandler {

        [SerializeField] public Button btn;
        public Action OnBtnPointerUpHandle;

        public void OnPointerMove(PointerEventData eventData) {
            if (OnBtnPointerUpHandle != null) {
                OnBtnPointerUpHandle?.Invoke();
            }
        }

        public void OnPointerUp(PointerEventData eventData) {
            Debug.Log("鼠标在Button里面抬起");
        }

        public void OnSelect(BaseEventData eventData) {
            Debug.Log("选中Button(点击)");
        }
    }

}

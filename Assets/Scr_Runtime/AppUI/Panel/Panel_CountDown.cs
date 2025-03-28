using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace DJ {
    public class Panel_CountDown : MonoBehaviour {

        public TextMeshProUGUI txt_CountDownTime;

        public void Ctor() {

        }

        public void SetText(float time) {
            txt_CountDownTime.text = time.ToString("0.0") + "s";
            if (time <= 0) {
                txt_CountDownTime.text = "0.0s";
            }
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}
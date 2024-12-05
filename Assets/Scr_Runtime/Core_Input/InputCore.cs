using System;
using UnityEngine;


namespace DJ {

    public class InputCore {
        public Vector2 moveAxis;

        public Vector2 faceAxis;

        public InputCore() {
            moveAxis = Vector2.zero;
            faceAxis = Vector2.zero;
        }

        public void ProcessMove() {
            // 移动
            Vector2 moveAxis = Vector2.zero;
            Vector2 faceAxis = Vector2.zero;
            // if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) {
            //     moveAxis.y = 1;
            // } else if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) {
            //     moveAxis.y = -1;
            // }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                moveAxis.x = -1;
                faceAxis.x = 1;
            } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                moveAxis.x = 1;
                faceAxis.x = -1;
            }

            moveAxis.Normalize();
            this.moveAxis = moveAxis;
            this.faceAxis = faceAxis;
            // 面向

        }

    }
}
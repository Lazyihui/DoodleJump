using System;
using UnityEngine;


namespace DJ {

    public class InputCore {

        public Controls player;

        // player1  
        bool isHpress;
        public bool IsHpress => isHpress;

        bool isQPress;
        public bool IsQPress => isQPress;

        // player2
        bool isRPress;
        public bool IsRPress => isRPress;

        bool isEpress;
        public bool IsEpress => isEpress;

        public InputCore() {
            player = new Controls();
            player.Enable();
        }

        public void ProcessMove() {
            var player1 = player.Player1Controls;
            {
                bool isHDown = player1.HPress.WasPressedThisFrame();
                isHpress = player1.HPress.IsPressed();
            }

            {
                bool isQDown = player1.QPress.WasPressedThisFrame();
                isQPress = player1.QPress.IsPressed();
                if(isQDown) {
                    Debug.Log("Q Pressed");
                }
            }

            // player2
            var player2 = player.Player2Controls;
            {
                bool isRDown = player2.RPress.WasPressedThisFrame();
                isRPress = player2.RPress.IsPressed();
            }

            {
                bool isEDown = player2.EPress.WasPressedThisFrame();
                isEpress = player2.EPress.IsPressed();
            }


        }

    }
}
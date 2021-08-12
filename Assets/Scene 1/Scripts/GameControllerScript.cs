using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpace
{
    public static class GameInstance
    {
        public static bool Paused = true;
    }

    public class GameControllerScript : MonoBehaviour
    {
        [Header("Player Paddles")]
        public Transform Paddle1;
        public Transform Paddle2;
        private Vector3 Player1StartPostiion;
        private Vector3 Player2StartPostiion;

        [Header("Ball Transform")]
        public Transform Ball;

        [Header("Scores")]
        public int Player1Score = 0;
        public int Player2Score = 0;

        [Header("Menu Buttons")]
        public List<GameObject> MenuButtons;
        public KeyCode MenuKey = KeyCode.Escape;


        // Enums
        public enum Player
        {
            Player1,
            Player2
        }



        // Start is called before the first frame update
        void Start()
        {
            if (Ball == null) { throw new System.Exception("No 'Ball' transform has been added to the game script!"); }
            if (Paddle1 == null) { throw new System.Exception("No 'Paddle1' transform has been added to the game script!"); }
            if (Paddle2 == null) { throw new System.Exception("No 'Paddle2' transform has been added to the game script!"); }

            Player1StartPostiion = Paddle1.position;
            Player2StartPostiion = Paddle2.position;
        }


        // Game Functions
        public void StartTwoPlayerGame()
        {
            // Single Player - Enable AI
            Paddle2.GetComponent<Paddle>().AIEnabled = false;

            StartGame();
        }
        public void StartSinglePlayerGame()
        {
            // Single Player - Enable AI
            Paddle2.GetComponent<Paddle>().AIEnabled = true;

            StartGame();
        }
        private void StartGame()
        {
            GameInstance.Paused = false;
            HideMenu();

            // Reset the Players
            Paddle1.position = Player1StartPostiion;
            Paddle2.position = Player2StartPostiion;

            // Launch the Ball
            Ball.GetComponent<Ball>().ReLaunch();
        }
        public void PauseGame()
        {
            GameInstance.Paused = true;
        }
        public void ResumeGame()
        {
            GameInstance.Paused = false;
        }
        public void ShowMenu()
        {
            foreach (GameObject Button in MenuButtons)
            {
                Button.SetActive(true);
            }
        }
        public void HideMenu()
        {
            foreach (GameObject Button in MenuButtons)
            {
                Button.SetActive(false);
            }
        }
        public void Win(Player P)
        {
            // Increment Score
            switch (P)
            {
                case Player.Player1:
                    Player1Score += 1;
                    break;
                case Player.Player2:
                    Player2Score += 1;
                    break;
                default:
                    break;
            }

            // Reset Game
            StartGame();
        }



        // Update is called once per frame
        void Update()
        {
            // Menu Key
            if (Input.GetKeyDown(MenuKey))
            {
                if (GameInstance.Paused)
                {
                    HideMenu();
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                    ShowMenu();
                }
                ;
            }
        }
    }
}
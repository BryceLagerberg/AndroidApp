using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpace
{
    public static class GameInstance
    {
        
        

        public static bool Paused = true;

        public static void PauseGame()
        {
            GameInstance.Paused = true;
        }
        public static void ResumeGame()
        {
            GameInstance.Paused = false;
        }

    }

    public class GameControllerScript : MonoBehaviour
    {

        [Header("Menu Buttons")]
        public List<GameObject> MenuButtons;
        public KeyCode MenuKey = KeyCode.Escape;


        [Header("Player Paddles")]
        public Transform Paddle1;
        public Transform Paddle2;
        private Vector3 Player1StartPostiion;
        private Vector3 Player2StartPostiion;

        [Header("Player Stats")]
        public TMPro.TextMeshProUGUI Player1Stats;
        public TMPro.TextMeshProUGUI Player2Stats;

        [Header("Ball Transform")]
        public Transform Ball;

        [Header("Scores")]
        public  TMPro.TextMeshProUGUI ScoreScreen;
        public  int Player1Score = 0;
        public  int Player2Score = 0;

        [Header("Other Stuff")]
        public GameObject GameStartCountdownObject;


        // Enums
        public enum Player
        {
            Player1,
            Player2
        }



        // Start is called before the first frame update
        void Start()
        {
            if (Ball == null) { throw new System.Exception("No 'Ball' GameObject has been added to the game script!"); }
            if (Paddle1 == null) { throw new System.Exception("No 'Paddle1' GameObject has been added to the game script!"); }
            if (Paddle2 == null) { throw new System.Exception("No 'Paddle2' GameObject has been added to the game script!"); }
            if (ScoreScreen == null) { throw new System.Exception("No 'ScoreScreen' GameObject has been added to the game script!"); }

            Player1StartPostiion = Paddle1.position;
            Player2StartPostiion = Paddle2.position;
        }


        // Game Functions
        public void StartTwoPlayerGame()
        {
            HideMenu();

            // Single Player - Enable AI
            Paddle2.GetComponent<Paddle>().AIEnabled = true;

        }
        public void StartSinglePlayerGame()
        {
            HideMenu();

            // Single Player - Enable AI
            Paddle2.GetComponent<Paddle>().AIEnabled = true;

            StartWithCountdown();
        }
        private void StartWithCountdown()
        {
            // Reset the Players
            //Paddle1.position = Player1StartPostiion;
            //Paddle2.position = Player2StartPostiion;

            // Launch the Ball
            Ball.GetComponent<Ball>().ReLaunch();

            // Start the countdown effect
            GameStartCountdownObject.GetComponent<CountDownScript>().StartCountdownEffect();
        }
        private void StartGame()
        {
            GameInstance.Paused = false;

            // Reset the Players
            //Paddle1.position = Player1StartPostiion;
            //Paddle2.position = Player2StartPostiion;

            // Launch the Ball
            Ball.GetComponent<Ball>().ReLaunch();
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


        private void UpdateScores()
        {
            ScoreScreen.text = $"[Scores]\nP1: {Player1Score}\nP2: {Player2Score}";
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
            UpdateScores();
            StartGame();
        }



        // Update is called once per frame
        void Update()
        {
            // Menu Open / Close
            if (Input.GetKeyDown(MenuKey))
            {
                if (GameInstance.Paused)
                {
                    HideMenu();
                    GameInstance.ResumeGame();
                }
                else
                {
                    GameInstance.PauseGame();
                    ShowMenu();
                }
                ;
            }


        }

    }
}
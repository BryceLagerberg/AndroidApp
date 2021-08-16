using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameSpace
{


    // Required Components
    [RequireComponent(typeof(TMPro.TextMeshProUGUI))]


    public class CountDownScript : MonoBehaviour
    {

        public int CountDownStartAmount = 3;
        public int ScaleFactor = 1600;

        private float CurrentCountdown;
        private TMPro.TextMeshProUGUI TM;
        private bool RunningCountdown = false;

        private void Start()
        {
            TM = transform.GetComponent<TMPro.TextMeshProUGUI>();
        }


        public void StartCountdownEffect()
        {
            CurrentCountdown = CountDownStartAmount;
            RunningCountdown = true;
        }


        // Update is called once per frame
        void Update()
        {
            if (RunningCountdown)
            {
                if (CurrentCountdown > 0)
                {
                    TM.fontSize += ScaleFactor * Time.deltaTime;
                    CurrentCountdown -= Time.deltaTime;
                    
                    string intCountDown = Mathf.CeilToInt(CurrentCountdown).ToString();
                    if (TM.text != intCountDown)
                    {
                        TM.fontSize = 60;
                        TM.text = intCountDown;
                    }
                    
                }
                else
                {
                    RunningCountdown = false;
                    GameInstance.Paused = false;
                    TM.fontSize = 60;
                    TM.text = "";
                }
            }

        }

    }

}
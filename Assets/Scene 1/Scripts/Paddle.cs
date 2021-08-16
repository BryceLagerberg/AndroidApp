using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameSpace
{

    // Required Components
    [RequireComponent(typeof(Rigidbody2D))]

    public class Paddle : MonoBehaviour
    {
        [Header("Controls")]
        public KeyCode UpKey = KeyCode.None;
        public KeyCode DownKey = KeyCode.None;
        public FixedJoystick JoystickScript;
        public ControlType CT;

        [Header("Movement")]
        public float ScrollSpeed = 3.0f;

        public bool AIEnabled = false;

        private GameObject GameBall;


        public enum ControlType
        {
            Keyboard,
            Joystick
        }

        // Start is called before the first frame update
        void Start()
        {
            // Key Selection Check
            if (UpKey == KeyCode.None) { Debug.Log("Invalid 'Up' Key Code!"); throw new System.Exception("Invalid 'Up' Key Code!"); }
            if (DownKey == KeyCode.None) { Debug.Log("Invalid 'Down' Key Code!"); throw new System.Exception("Invalid 'Down' Key Code!"); }

            // Game Ball Detection
            if(GameObject.Find("Ball") == null) { throw new System.Exception("Could Not Find GameObject 'Ball' !"); } else { GameBall = GameObject.Find("Ball"); }

            // Determine Control Type
            if(Application.platform == RuntimePlatform.Android) { CT = ControlType.Joystick; } else { CT = ControlType.Keyboard; }

        }

        // Update is called once per frame
        void Update()
        {
            if (!GameInstance.Paused)
            {
                float incrementValue = ScrollSpeed * Time.deltaTime;

                if (AIEnabled)
                {
                    // Ai Logic
                    if (GameBall.transform.position.y > this.transform.position.y && GameBall.GetComponent<Rigidbody2D>().velocity.x > 0)
                    {
                        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + incrementValue, 0);
                    }
                    else if (GameBall.transform.position.y < this.transform.position.y && GameBall.GetComponent<Rigidbody2D>().velocity.x > 0)
                    {
                        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - incrementValue, 0);
                    }
                }
                else
                {
                    // Human Controls
                    if(CT == ControlType.Keyboard)
                    {
                        if (Input.GetKey(UpKey)) { this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + incrementValue, 0);}
                        if (Input.GetKey(DownKey)) { this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - incrementValue, 0);}
                    }
                    else if(CT == ControlType.Joystick)
                    {
                        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (JoystickScript.Vertical*incrementValue), 0);
                    }
                    
                }

            }

        }
    }
}
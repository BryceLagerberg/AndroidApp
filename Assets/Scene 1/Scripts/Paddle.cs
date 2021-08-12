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

        [Header("Movement")]
        public float ScrollSpeed = 3.0f;

        public bool AIEnabled = false;


        // Start is called before the first frame update
        void Start()
        {
            // Key Selection Check
            if (UpKey == KeyCode.None) { Debug.Log("Invalid 'Up' Key Code!"); throw new System.Exception("Invalid 'Up' Key Code!"); }
            if (DownKey == KeyCode.None) { Debug.Log("Invalid 'Down' Key Code!"); throw new System.Exception("Invalid 'Down' Key Code!"); }

        }

        // Update is called once per frame
        void Update()
        {
            if (!GameInstance.Paused)
            {
                float incrementValue = ScrollSpeed * Time.deltaTime;

                if (Input.GetKey(UpKey))
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + incrementValue, 0);
                }
                if (Input.GetKey(DownKey))
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - incrementValue, 0);
                }
            }

        }
    }
}
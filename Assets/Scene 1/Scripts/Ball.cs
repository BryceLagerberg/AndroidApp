using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpace
{

    public class Ball : MonoBehaviour
    {

        public float MovementSpeed = 5;
        public Rigidbody2D rb;
        public Vector2 ScreenDimensions;

        // Privates
        private Vector2 PausedVelocity = new Vector2(0f, 0f);


        // Start is called before the first frame update
        void Start()
        {
            Vector3 TopRightPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
            ScreenDimensions = new Vector2(TopRightPoint.x, TopRightPoint.y);
        }

        // Update is called once per frame
        void Update()
        {

            // Pause Logic
            if (GameInstance.Paused)
            {
                if(PausedVelocity == new Vector2(0f, 0f)) { PausedVelocity = rb.velocity; }
                rb.velocity = new Vector2(0f, 0f);
            }
            else
            {
                if (PausedVelocity != new Vector2(0f, 0f)) { rb.velocity = PausedVelocity;  }
                PausedVelocity = new Vector2(0f, 0f);
            }


            // Ceiling Bounce
            if (this.transform.position.y >= ScreenDimensions.y) { rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y) * -1); }
            if (this.transform.position.y <= ScreenDimensions.y * -1) { rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y)); }


            // Goal Touch
            if (this.transform.position.x >= ScreenDimensions.x)
            {
                // Player 1 Goal!
                GameObject.Find("_GameManager").GetComponent<GameControllerScript>().Win(GameControllerScript.Player.Player1);
            }
            else
            if (this.transform.position.x <= ScreenDimensions.x * -1)
            {
                // Player 2 Goal!
                GameObject.Find("_GameManager").GetComponent<GameControllerScript>().Win(GameControllerScript.Player.Player2);
            }

        }

        public void ReLaunch()
        {
            this.transform.position = new Vector3(0, 0, 0);
            float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(MovementSpeed * xDirection, MovementSpeed * yDirection);
        }
    }
}
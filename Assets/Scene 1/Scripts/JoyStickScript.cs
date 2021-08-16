using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickScript : MonoBehaviour
{

    public Transform Paddle;
    private FixedJoystick JoystickScript;

    // Start is called before the first frame update
    void Start()
    {
        JoystickScript = this.GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

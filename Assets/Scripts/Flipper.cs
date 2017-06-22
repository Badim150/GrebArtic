using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    public float restPosition = 0;
    public float pressedPosition = 45;
    public float hitStrenght = 10000;
    public float flipperDamper = 150;

    HingeJoint hinge;

    public string inputName;

	void Start ()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
	}
	

	void Update ()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = flipperDamper;

        if (Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
        }

        hinge.spring = spring;
        hinge.useLimits = true;

	}
}

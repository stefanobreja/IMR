using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for animation
public class PlayerBehaviour : DetectionZone
{
    private Animator mAnimator;
    public float howClose;
    public string AttackParamName = "attack";

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectedObjs.Count > 0)
        {
            mAnimator.SetBool(AttackParamName, true);
            Debug.Log("animator true");
        }
        else
        {
            mAnimator.SetBool(AttackParamName, false);
            Debug.Log("animator false");
        }
    }
}

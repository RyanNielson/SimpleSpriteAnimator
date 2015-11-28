using UnityEngine;
using System.Collections;
using SimpleSpriteAnimator;

public class AnimatorTester : MonoBehaviour
{
    private SpriteAnimator spriteAnimator;

	void Start ()
    {
        spriteAnimator = GetComponent<SpriteAnimator>();
	}

	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spriteAnimator.Play("No");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteAnimator.Play("Yes");
        }
	}
}

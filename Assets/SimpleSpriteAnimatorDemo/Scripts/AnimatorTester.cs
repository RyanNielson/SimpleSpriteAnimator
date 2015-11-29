using UnityEngine;
using SimpleSpriteAnimator;

public class AnimatorTester : MonoBehaviour
{
    private SpriteAnimator spriteAnimator;

	void Start ()
    {
        spriteAnimator = GetComponent<SpriteAnimator>();
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 30), "Play Walk Animation"))
        {
            spriteAnimator.Play("Walk");
        }

        if (GUI.Button(new Rect(10, 50, 150, 30), "Play Climb Animation"))
        {
            spriteAnimator.Play("Climb");
        }
    }
}

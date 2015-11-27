using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SimpleSpriteAnimator
{
    [Serializable]
    [CreateAssetMenu]
    public class SpriteAnimation : ScriptableObject
    {
        [SerializeField]
        private string animationName = "animation";

        public string Name
        {
            get { return animationName; }
            set { animationName = value; }
        }

        [SerializeField]
        private int fps = 30;

        public int FPS
        {
            get { return fps; }
            set { fps = value; }
        }

        [SerializeField]
        private List<SpriteAnimationFrame> frames = new List<SpriteAnimationFrame>();

        public List<SpriteAnimationFrame> Frames
        {
            get { return frames; }
        }

        [SerializeField]
        private SpriteAnimationType spriteAnimationType = SpriteAnimationType.Looping;
        public SpriteAnimationType SpriteAnimationType
        {
            get { return spriteAnimationType; }
            set { spriteAnimationType = value; }
        }
    }
}

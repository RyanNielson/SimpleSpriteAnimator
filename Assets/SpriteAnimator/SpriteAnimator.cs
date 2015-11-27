using UnityEngine;
using System.Collections.Generic;

namespace SimpleSpriteAnimator
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField]
        private List<SpriteAnimation> spriteAnimations;

        [SerializeField]
        private bool playAutomatically = true;

        private SpriteRenderer spriteRenderer;

        //private SpriteAnimationHelper spriteAnimationHelper;

        private SpriteAnimationState state = SpriteAnimationState.Playing;

        private SpriteAnimation DefaultAnimation
        {
            get { return spriteAnimations[0]; }
        }

        private SpriteAnimation CurrentAnimation { get; set; }

        /// <summary>
        /// Time into the current clip. This is in clip local time (i.e. (int)clipTime = currentFrame)
        /// </summary>
        float clipTime = 0.0f;

        /// <summary>
        /// This is the frame rate of the current clip. Can be changed dynamicaly, as clipTime is accumulated time in real time.
        /// </summary>
        float clipFps = -1.0f;

        /// <summary>
        /// Previous frame identifier
        /// </summary>
        int previousFrame = -1;

        public bool Playing
        {
            get { return state == SpriteAnimationState.Playing; }
        }

        public bool Paused
        {
            get { return state == SpriteAnimationState.Paused; }
        }

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            //spriteAnimationHelper = new SpriteAnimationHelper(spriteAnimations[0]);
        }

        private void Start()
        {
            if (playAutomatically)
            {
                Play(DefaultAnimation);
            }
        }

        public void Play()
        {
            if (CurrentAnimation == null)
            {
                CurrentAnimation = DefaultAnimation;
            }

            Play(CurrentAnimation);
        }

        public void Play(SpriteAnimation animation)
        {
            Play(animation, 0);
        }

        public void Play(SpriteAnimation animation, float startFrame)
        {
            state = SpriteAnimationState.Playing;
            CurrentAnimation = animation;
            clipTime = 0;
        }

        private void LateUpdate()
        {
            UpdateAnimation(Time.deltaTime);
        }

        private void UpdateAnimation(float deltaTime)
        {
            if (state != SpriteAnimationState.Playing)
                return;

            clipTime += deltaTime * CurrentAnimation.FPS;
            int currentFrame = (int)clipTime % CurrentAnimation.Frames.Count;

            SpriteAnimationFrame frame = CurrentAnimation.Frames[currentFrame];

            spriteRenderer.sprite = frame != null ? frame.Sprite : null;
        }


        //private SpriteAnimation GetAnimationByName(string name)
        //{
        //    for (int i = 0; i < spriteAnimations.Count; i++)
        //    {
        //        if (spriteAnimations[i].Name == name)
        //        {
        //            return spriteAnimations[i];
        //        }
        //    }

        //    return null;
        //}

        //public SpriteAnimationFrame UpdateAnimation(float deltaTime)
        //{
        //    if (playing)
        //    {
        //        frameDuration = 1f / spriteAnimation.FPS;
        //        totalAnimationTime = frameDuration * spriteAnimation.Frames.Count;

        //        frameTimeAccumulator += deltaTime;

        //        if (frameTimeAccumulator >= totalAnimationTime)
        //        {
        //            frameTimeAccumulator = 0;
        //        }

        //        if (spriteAnimation.SpriteAnimationType == SpriteAnimationType.PlayOnce && currentFrame < spriteAnimation.Frames.Count - 1)
        //        {
        //            currentFrame = Mathf.FloorToInt(frameTimeAccumulator / frameDuration);
        //        }
        //        else if (spriteAnimation.SpriteAnimationType == SpriteAnimationType.Looping)
        //        {
        //            currentFrame = Mathf.FloorToInt(frameTimeAccumulator / frameDuration);
        //        }
        //    }

        //    return spriteAnimation.Frames[currentFrame];
        //}

        //public void ChangeAnimation(SpriteAnimation spriteAnimation)
        //{
        //    frameDuration = 0f;
        //    frameTimeAccumulator = 0f;
        //    totalAnimationTime = 0f;
        //    done = false;
        //    currentFrame = 0;
        //    this.spriteAnimation = spriteAnimation;
        //}

        //private void Update()
        //{
        //    UpdateAnimation(Time.deltaTime);

        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        Play("Nah");
        //    }

        //    if (Input.GetButtonDown("Horizontal"))
        //    {
        //        Play("Woo");
        //    }
        //}

        //public void Play(string name)
        //{
        //    spriteAnimationHelper.ChangeAnimation(GetAnimationByName(name));
        //}

        //private void UpdateAnimation(float deltaTime)
        //{
        //    SpriteAnimationFrame frame = spriteAnimationHelper.UpdateAnimation(Time.deltaTime);

        //    spriteRenderer.sprite = frame != null ? frame.Sprite : null;
        //}
    }
}

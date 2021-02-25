using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SweetRush
{
    public class AnimationManager : SingletonInitiatorBase<AnimationManager>
    {
        [SerializeField]
        private GameObject _iceCreamTruck = null;
        private float _jumpAnimationSpeedLowGravity = 1.1f;
        private float _jumpAnimationSpeedHighGravity = 1.8f;
        private float _runAnimationSpeedRushing = 1.8f;
        private float _runAnimationSpeedDraging = 0.8f;
        private Animator _playerAnimator;
        private Animator _iceCreamTruckAnimator;
        private static readonly int JumpB = Animator.StringToHash("Jump_b");
        private static readonly int JumpSpeedMultiplierF = Animator.StringToHash("JumpSpeedMultiplier_f");
        private static readonly int RunSpeedMultiplierF = Animator.StringToHash("RunSpeedMultiplier_f");
        private static readonly int GetHitB = Animator.StringToHash("GetHit_b");
        private static readonly int BumpT = Animator.StringToHash("BumpT");
       private static readonly int isPlayerDeadB = Animator.StringToHash("isPlayerDead_b");
        private static readonly int isPlayerDancinB = Animator.StringToHash("isPlayerDancin_b");
        //for the cart
        private static readonly int IsGameStartB = Animator.StringToHash("IsGameStartB");
        //for the player
        private static readonly int isGameStartB = Animator.StringToHash("isGameStart_b");
        private static readonly int SpeedOfBumpJumpF = Animator.StringToHash("SpeedOfBumpJumpF");
        private static readonly int DeadOrDancinEndedB = Animator.StringToHash("DeadOrDancinAnimationEnded_b");
        private static readonly int GoAwayT = Animator.StringToHash("GoAwayT");

        void Start()
        {
            //Getting Animator component from child object of Player parent object that after used in controlling animation 
            _playerAnimator = PlayerController.Instance.GetComponentInChildren<Animator>();
            
            
        }

     

        public void GetIceCreamTruckAnimatorComponent()
        {
            _iceCreamTruckAnimator = _iceCreamTruck.GetComponentInChildren<Animator>();
        }

        //Play jump animation
        public void PlayJumpAnimation()
        {
            if (!_playerAnimator.GetBool(JumpB))
            {
                _playerAnimator.SetBool(JumpB, true);
            }
        }
//Method for changing of jump animation speed depending of jump button state
        public void CheckForJumpButtonPressed(bool isJumpButtonPressed)
        {
            if (isJumpButtonPressed)
            {
                _playerAnimator.SetFloat(JumpSpeedMultiplierF, _jumpAnimationSpeedLowGravity);
            }
            else
            {
                _playerAnimator.SetFloat(JumpSpeedMultiplierF, _jumpAnimationSpeedHighGravity);
            }
        }

        //Method for changing of run animation speed depending of jump button state
        public void SwitchSpeedOfRunAnimation(float input)
        {
            if (input > 0)
            {
                _playerAnimator.SetFloat(RunSpeedMultiplierF, _runAnimationSpeedRushing);
            }
            else if (input < 0)
            {
                _playerAnimator.SetFloat(RunSpeedMultiplierF, _runAnimationSpeedDraging);
            }
            else
            {
                _playerAnimator.SetFloat(RunSpeedMultiplierF, 1.0f);
            }
        }

        //Method for playing animation of getting hit
        public void PlayGetHitAnimation()
        {
            _playerAnimator.SetBool(GetHitB, !_playerAnimator.GetBool(GetHitB));
        }

        //Method for playing run animation after end of jump
        public void PlayRunAnimation()
        {
            _playerAnimator.SetBool(JumpB, false);
            if (GameManager.Instance._isGameStart)
            {
                _playerAnimator.SetBool(isGameStartB,true);
            }
        }

        public void PlayDeathAnimation()
        {
            _playerAnimator.SetBool(isPlayerDeadB, true);
        }
        
        public void PlayDancinAnimation()
        {
            _playerAnimator.SetBool(isPlayerDancinB, true);
        }
        

        public void StopAndRestartPlayingPlayerAnimation()
        {
            _playerAnimator.SetBool(isGameStartB,false);
            _playerAnimator.SetBool(isPlayerDancinB, false);
            _playerAnimator.SetBool(isPlayerDeadB, false);
        }
        
        public void PlayIceCreamTruckMoveForwardAnimation(bool isGameStart)
        {
            _iceCreamTruckAnimator.SetBool(IsGameStartB,isGameStart);
        }

        public void PlayIceCreamTruckBumpingOnBumpAnimation(float speedOfThrownEatable)
        {
            _iceCreamTruckAnimator.SetFloat(SpeedOfBumpJumpF,speedOfThrownEatable);
            _iceCreamTruckAnimator.SetTrigger(BumpT);
        }

        public void PlayCartGoinAwayAnimation()
        {
            _iceCreamTruckAnimator.SetTrigger(GoAwayT);
        }
        
    }
}

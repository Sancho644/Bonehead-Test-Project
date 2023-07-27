using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SwordManController : MonoBehaviour
{
      [SerializeField] private Animator _animator;

      private Animations _animations;
      
      public void StartAnimation()
      {
            var animationsCount = Enum.GetNames(typeof(Animations)).Length;
            var random = Random.Range(0, animationsCount);
            var randomAnimation = Enum.GetName(typeof(Animations), random);
            
            _animator.Play(randomAnimation);
      }
}

public enum Animations
{
      Attack,
      Die,
      Jump,
      Run,
      Sit
}
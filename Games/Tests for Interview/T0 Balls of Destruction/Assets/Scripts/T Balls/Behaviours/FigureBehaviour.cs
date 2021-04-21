using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBalls
{
   public class FigureBehaviour : MonoBehaviour
   {
      private void Awake()
      {
         GameManager.Instance.SetWinCondition(transform.childCount);
      }
   }
}

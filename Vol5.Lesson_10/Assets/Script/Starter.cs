using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVVM.View;
using MVVM.ViewModel;
using MVVM.Model;
namespace MVVM
{
    internal sealed class Starter : MonoBehaviour
    {
        [SerializeField] Snake _snake;
        void Start()
        {
            var score = new Score(0.0f);
            var scoreChange = new ChangeScore(score);
            _snake.Initialize(scoreChange);
        }
        void Update()
        {
            _snake.Move();
        }
    }
}

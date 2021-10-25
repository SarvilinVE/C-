using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVVM.ViewModel;
using MVVM.Model;

namespace MVVM.View
{
    internal sealed class Snake : MonoBehaviour
    {
        [SerializeField] private Transform _snakeTransform;
        [SerializeField] private float _speed;

        private IChangeScore _changeScore;
        public void Initialize(IChangeScore changeScore)
        {
            _changeScore = changeScore;
            _changeScore.onChangeScore += _onChangeScore;
            _onChangeScore(false);
        }

        private void _onChangeScore(bool _isAddScore)
        {
            if (_isAddScore)
            {
                _onChangeScore(false);
            }
        }
        public void Move()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.Translate(Vector2.right * _speed * Time.deltaTime);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
            }
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                transform.Translate(Vector2.up * _speed * Time.deltaTime);
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.Translate(Vector2.down * _speed * Time.deltaTime);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Food"))
            {
                _changeScore.AddScore(10.0f);
                Debug.Log(_changeScore.GetScore.CurrentScore);
            }
        }
        ~Snake()
        {
            _changeScore.onChangeScore -= _onChangeScore;
        }
    }
}

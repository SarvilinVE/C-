using System;
using System.Collections;
using UnityEngine;
using Asteroids.Buider;
using Asteroids.Visitor;

namespace Asteroids
{
    internal class Weapon : CreateObjectLog, IWeapon
    {
        private readonly ViewServices _viewServices = new ViewServices();
        private readonly GameObjectBuilder _gameObjectBuilder = new GameObjectBuilder();
        private float _force;
        private float _lifeDistance = 100.0f;
        private int _damage;
        public GameObject Bullet { get; set; }
        public Sprite Sprite {get;}
        public Rigidbody2D Rigidbody2DBullet {get;}
        public Transform TransformBarrel { get; }
        public Weapon(Rigidbody2D rigidbody, Transform transform, float force, int damage)
        {
            Rigidbody2DBullet = rigidbody;
            TransformBarrel = transform;
            _force = force;
            _damage = damage;
        }
        public Weapon(Sprite sprite,Transform transform, float force, int damage)
        {
            Bullet = _gameObjectBuilder.Visual.Sprite(sprite).Name($"{sprite.name}").Physic.Rigidbody2D(1.0f).CircleCollider2D();
            Bullet.SetActive(false);
            Sprite = sprite;
            TransformBarrel = transform;
            _force = force;
            _damage = damage;
        }
        public void Shooting()
        {
            //var weapon = Object.Instantiate(Rigidbody2DBullet, TransformBarrel.position, TransformBarrel.rotation);
            //var weapon =_viewServices.Instantiate(Rigidbody2DBullet.gameObject);
            var weapon =_viewServices.Instantiate(Bullet);
            weapon.transform.position = TransformBarrel.position;
            weapon.transform.rotation = TransformBarrel.rotation;
            weapon.GetComponent<Rigidbody2D>().AddForce(TransformBarrel.up * _force);
            //DestroyBullet(weapon);
        }
        public int GetDamage()
        {
            return _damage;
        }
        public void DestroyBullet(GameObject go)
        {
            var originPosition = go.transform.position;
            var distance = 0.0f;
            if(go.transform.position.sqrMagnitude > _lifeDistance * _lifeDistance)
            {
                
                _viewServices.Destroy(go);
            }
            Debug.Log(go.transform.position.sqrMagnitude);
        }
        public override void Activate(ICreateObject createObject)
        {
            createObject.Visitor(this);
        }
    }
}

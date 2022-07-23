using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Vector2 _Direction;
    [SerializeField] private float _spreading;

    private Coroutine _lifeTimeTimer;

    private void Start()
    {
        _Direction = Quaternion.Euler(0, 0, Random.Range(-_spreading, _spreading)) * Vector3.left;
        _lifeTimeTimer = StartCoroutine(DisappearAfterLifeTime());
    }

    private void Update()
    {
        transform.Translate(_Direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            Delete();
        }
    }

    private IEnumerator DisappearAfterLifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);

        Delete();
    }

    private void Delete()
    {
        if (_lifeTimeTimer != null)
        {
            StopCoroutine(_lifeTimeTimer);
        }

        Destroy(gameObject);
    }
}
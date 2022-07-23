using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    const int MaxPossibleShots = 30;

    [SerializeField] private int _shotsInShell;

    private void Start()
    {
        if (_shotsInShell < 0 || MaxPossibleShots < _shotsInShell)
        {
            _shotsInShell = 1;
        }
    }

    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < _shotsInShell; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        }
    }
}
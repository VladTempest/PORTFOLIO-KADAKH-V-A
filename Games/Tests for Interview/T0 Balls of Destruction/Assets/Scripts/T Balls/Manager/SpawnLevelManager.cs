using System;
using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;

public class SpawnLevelManager : SingletonBase<SpawnLevelManager>
{
    // Start is called before the first frame update
    [SerializeField]
    private PoolFiguresSettings _poolFigures = null;
    [SerializeField]
    private Vector3 _spawnLocation = new Vector3(1384.82f, 459.81f, -106.88f);

    private void Start()
    {
        SpawnFigure(GameManager.Instance.LevelLoaded);
    }
    public void SpawnFigure(int loadedlevel)
    {
        Instantiate(_poolFigures.pool[loadedlevel-1], _spawnLocation, transform.rotation);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Random = UnityEngine.Random;

namespace ProjectSurvivor{
    [Serializable]
    public class EnemyWave{
        public float generateDuration = 1; //每隔多少时间生成一个敌人
        public GameObject enemyPrefab;
        public int seconds = 10; //当前波次持续时间
    }

    public partial class EnemyGenerator : ViewController{
        private float _currentGenerateSeconds = 0; // 刷怪间隔
        private float _currentWaveSeconds = 0; // 当前波次持续时间

        public List<EnemyWave> enemyWaves = new List<EnemyWave>();

        private Queue<EnemyWave> _enemyWavesQueue = new Queue<EnemyWave>();

        public EnemyWave currentWave; // 当前波次
        
        public int waveCount = 0;
        public bool LastWave => waveCount == enemyWaves.Count;
        
        private void Start(){
            foreach (var enemyWave in enemyWaves){
                _enemyWavesQueue.Enqueue(enemyWave);
            }

            currentWave = null;
        }


        private void Update(){
            // 波次为空，从队列中取出下一波
            if (currentWave == null){
                waveCount++;
                Debug.Log($"开始波次{waveCount}");
                if (_enemyWavesQueue.Count > 0){
                    currentWave = _enemyWavesQueue.Dequeue();
                    _currentGenerateSeconds = 0;
                    _currentWaveSeconds = 0;
                }
            }

            if (currentWave != null){
                _currentGenerateSeconds += Time.deltaTime;
                _currentWaveSeconds += Time.deltaTime;
                
                //刷怪间隔超过了生成间隔则生成一个敌人
                if (_currentGenerateSeconds >= currentWave.generateDuration){
                    _currentGenerateSeconds = 0;

                    var player = Player.Instance;

                    if (player){
                        var randomAngle = Random.Range(0, 360f);
                        var randomRadius = randomAngle * Mathf.Deg2Rad;
                        var dir = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius));
                        var targetPos = player.transform.position + dir * 15;

                        if (currentWave.enemyPrefab != null){
                            currentWave.enemyPrefab.Instantiate()
                                .Position(targetPos)
                                .Show();
                        }
                    }
                    
                    // 波次持续时间耗尽,则切换到下一波
                    if (_currentWaveSeconds >= currentWave.seconds){
                        currentWave = null;
                    }
                }
            }

        }
    }
}
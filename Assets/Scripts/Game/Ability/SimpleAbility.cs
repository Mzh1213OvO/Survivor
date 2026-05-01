using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class SimpleAbility : ViewController{

        private float _mCurrentSeconds = 0;
        void Start(){
        }

        void Update(){
            
            _mCurrentSeconds += Time.deltaTime;

            if (_mCurrentSeconds >= 1.5f){
                _mCurrentSeconds = 0;
                
                // 未激活 不排序
                var enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);


                foreach (var enemy in enemies){
                    var distance = (Player.Instance.transform.position - enemy.transform.position).magnitude;

                    if (distance <= 5){
                        
                        
                        enemy.Sprite.color = Color.red;
                        "变红".LogInfo();

                        var enemyRefCache = enemy;

                        ActionKit.Delay(0.5f,() => {
                            enemyRefCache.Sprite.color = Color.white;
                        }).StartGlobal();
                    }
                }
            }
        }
        
    }
}
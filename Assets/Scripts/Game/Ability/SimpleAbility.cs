using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class SimpleAbility : ViewController{

        private float _mCurrentSeconds = 0;
        void Start(){
        }

        void Update(){
            if (Player.Instance == null) return;
            
            _mCurrentSeconds += Time.deltaTime;

            if (_mCurrentSeconds >= Global.DamageFrequency.Value){
                _mCurrentSeconds = 0;
                
                // 未激活 不排序
                var enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);


                foreach (var enemy in enemies){
                    var distance = (Player.Instance.transform.position - enemy.transform.position).magnitude;

                    if (distance <= 5){

                        enemy.Hurt(Global.Damage.Value);

                    }
                }
            }
        }
    }
}
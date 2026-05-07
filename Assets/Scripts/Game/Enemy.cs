using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class Enemy : ViewController{
        public float health = 3;
        public float moveSpeed = 2.0f;
        void Start(){
            EnemyGenerator.EnemyCount.Value++;
        }
        
        void OnDestroy(){
            EnemyGenerator.EnemyCount.Value--;
            if(EnemyGenerator.EnemyCount.Value <= 0)EnemyGenerator.EnemyCount.Value = 0;
        }

        void Update(){

            if (Player.Instance != null){
                var dir = (Player.Instance.transform.position - transform.position).normalized;

                transform.Translate(dir*Time.deltaTime*moveSpeed);
            }


            if (health <= 0){
                this.DestroyGameObjGracefully();
                
                //TODO: 经验值的掉落
            }
        }

        private bool _isHurting = false;//防止第一次受伤还没生效就第二次受伤
        public void Hurt(float damageValue){
            if (_isHurting) return;
            
            Sprite.color = Color.red;
                        
            "敌人受伤".LogInfo();
                        
            ActionKit.Delay(0.2f,() => {
                this.Sprite.color = Color.white;
                this.health -= Global.Damage.Value;
                _isHurting = false;
            }).Start(this);
        }
    }
}
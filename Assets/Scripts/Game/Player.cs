using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class Player : ViewController{

        public static Player Instance;
        
        public float moveSpeed = 5.0f;

        void Awake(){
            if (Instance == null){
                Instance = this;
                ("Player Awake").LogInfo();
            }
            else{
                Destroy(gameObject);
                "Player Destroy".LogInfo();
            }
        }
        
        void Start(){
            HurtBox.OnTriggerEnter2DEvent(collider2D => {
                

                var hitBox= collider2D.GetComponent<HitBox>();

                if (hitBox){
                    "Player Hurt".LogInfo();
                    if (hitBox.owner.CompareTag("Enemy")){

                        Global.Hp.Value--;
                        AudioKit.PlaySound("Hurt");
                        if (Global.Hp.Value <= 0){
                            Time.timeScale = 0;
                            AudioKit.PlaySound("Die");
                            this.DestroyGameObjGracefully();
                            UIKit.OpenPanel<UIGameOverPanel>();    
                        }
                    }
                }
                
            } ).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update(){
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            
            var targetVelocity = new Vector2(horizontal,vertical).normalized * moveSpeed;

            // 平滑移动
            SelfRigidbody2D.velocity =
                Vector2.Lerp(SelfRigidbody2D.velocity, targetVelocity, 1 - Mathf.Exp(-Time.deltaTime * 5));
        }

        private void OnDestroy(){
            "Player Destroy".LogInfo();
            Destroy(this.gameObject);
        }
    }
}
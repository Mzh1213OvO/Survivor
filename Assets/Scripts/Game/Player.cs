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
                "Player Hurt".LogInfo();

                ResKit.Init();
                
                this.DestroyGameObjGracefully();

                UIKit.OpenPanel<UIGameOverPanel>();
                
            } ).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update(){
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            
            var dir=new Vector2(horizontal,vertical).normalized;
            
            SelfRigidbody2D.velocity = dir*moveSpeed;
        }

        private void OnDestroy(){
            "Player Destroy".LogInfo();
            Destroy(this.gameObject);
        }
    }
}
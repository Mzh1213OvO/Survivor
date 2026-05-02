using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class Enemy : ViewController{
        public float health = 3;
        public float moveSpeed = 2.0f;
        void Start(){
        }

        void Update(){

            if (Player.Instance != null){
                var dir = (Player.Instance.transform.position - transform.position).normalized;

                transform.Translate(dir*Time.deltaTime*moveSpeed);
            }


            if (health <= 0){
                this.DestroyGameObjGracefully();
                UIKit.OpenPanel<UIGamePassPanel>();
            }
        }
    }
}
using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class Bomb : ViewController{
        private void OnTriggerEnter2D(Collider2D other){
            "炸弹发生碰撞".LogInfo();
            AudioKit.PlaySound("Bomb");
            foreach (var enemyObj in GameObject.FindGameObjectsWithTag("Enemy")){
                var enemy = enemyObj.GetComponent<Enemy>();

                if (enemy && enemy.gameObject.activeSelf){
                    enemy.Hurt(enemy.health);
                    CameraController.Shake();
                }
                
            }
            
            this.DestroyGameObjGracefully();
        }
    }
}
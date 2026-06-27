using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class Coin : ViewController{
        private void OnTriggerEnter2D(Collider2D other){
            "金币发生碰撞".LogInfo();
            AudioKit.PlaySound("Coin");
            if (other.GetComponent<PickArea>()){
                Global.Coin.Value++;
                this.DestroyGameObjGracefully();
            }
            
        }
    }
}
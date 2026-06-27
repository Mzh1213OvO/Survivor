using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class BloodBottle : ViewController{

        private void OnTriggerEnter2D(Collider2D other){
            "血瓶发生碰撞".LogInfo();
            if (Global.Hp.Value == Global.MaxHp.Value) return;
            
            AudioKit.PlaySound("Hp");
            if (other.GetComponent<PickArea>()){
                Global.Hp.Value++;
                this.DestroyGameObjGracefully();
            }
        }
        
    }
}
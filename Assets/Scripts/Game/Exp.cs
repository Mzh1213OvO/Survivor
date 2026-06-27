using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class Exp : ViewController{
        private void OnTriggerEnter2D(Collider2D other){
            "经验值发生碰撞".LogInfo();
            AudioKit.PlaySound("Exp");
            if (other.GetComponent<PickArea>()){
                Global.Exp.Value++;
                this.DestroyGameObjGracefully();
                
            }
            
        }
        
        
    }
}
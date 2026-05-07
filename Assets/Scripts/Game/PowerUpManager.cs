using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class PowerUpManager : ViewController{
        public static PowerUpManager Instance;

        private void Awake(){
            if (PowerUpManager.Instance == null){
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else{
                this.DestroyGameObjGracefully();
            }
        }

    }
}
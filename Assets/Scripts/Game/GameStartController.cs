using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class GameStartController : ViewController{

        private void Awake(){
            ResKit.Init();
        }
        
        void Start(){
            UIKit.OpenPanel<UIGameStartPanel>();
        }
    }
}
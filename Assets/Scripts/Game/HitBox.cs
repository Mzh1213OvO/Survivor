using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class HitBox : ViewController{

        public GameObject owner;
        
        void Start(){
            if (!owner){
                owner=transform.parent.gameObject;
            }
        }
    }
}
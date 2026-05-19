using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class GetAllExp : ViewController{
        private void OnTriggerEnter2D(Collider2D other){
            "吸收所有经验值".LogInfo();
            if (other.GetComponent<PickArea>()){
                foreach (var exp in FindObjectsByType<Exp>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)){
                    ActionKit.OnUpdate.Register(() => {
                        "测试输出".LogInfo();
                        var player = Player.Instance;
                        if (player){
                            var dir = player.Position() - exp.Position();
                            exp.transform.Translate(dir.normalized * Time.deltaTime * 8.0f);
                        }
                    }).UnRegisterWhenGameObjectDestroyed(exp);
                }
            }
            this.DestroyGameObjGracefully();
        }
        
    }
}
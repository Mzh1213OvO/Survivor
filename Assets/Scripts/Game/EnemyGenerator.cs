using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class EnemyGenerator : ViewController{
        private float _mCurrentSeconds = 0;

        private void Update(){
            _mCurrentSeconds += Time.deltaTime;

            if (_mCurrentSeconds >= 1){
                _mCurrentSeconds = 0;

                var player = Player.Instance;
                var randomAngle = Random.Range(0, 360f);
                var randomRadius= randomAngle*Mathf.Deg2Rad;
                var dir = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius));
                var targetPos=player.transform.position + dir*5;
                
                Enemy.Instantiate()
                    .Position(targetPos)
                    .Show();
                
            }
        }
    }
}
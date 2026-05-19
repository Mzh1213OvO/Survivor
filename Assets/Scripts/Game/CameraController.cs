using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class CameraController : ViewController{
        
        private Vector2 _targetPosition = Vector2.zero;

        private void Start(){
            Application.targetFrameRate = 60;
        }
        
        /// <summary>
        /// QF 相机跟随
        /// </summary>
        private void Update(){
            if (Player.Instance){
                _targetPosition = Player.Instance.transform.position;
                transform.PositionX(
                    (1.0f - Mathf.Exp(-Time.deltaTime * 20))
                        .Lerp(transform.position.x, _targetPosition.x));
                
                transform.PositionY(
                    (1.0f -Mathf.Exp( -Time.deltaTime * 20))
                        .Lerp(transform.position.y, _targetPosition.y));
            }
        }
    }
}
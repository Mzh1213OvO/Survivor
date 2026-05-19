using UnityEngine;
using QFramework;

namespace ProjectSurvivor{
    public partial class CameraController : ViewController{
        
        private Vector2 _targetPosition = Vector2.zero;// 用于相机跟随
        private Vector3 _currentCameraPos;// 用于屏幕震动
        private bool _shake = false;
        private int _shakeFrame = 0;
        private float _shakeA = 4.0f;
        
        public static CameraController Instance;


        void Awake(){
            Instance = this;
        }
        
        void OnDestroy(){
            Instance = null;
        }

        private void Start(){
            Application.targetFrameRate = 60;
        }
        
        /// <summary>
        /// QF 相机跟随
        /// </summary>
        private void Update(){
            if (Player.Instance){
                // 相机跟随
                _targetPosition = Player.Instance.transform.position;
                
                _currentCameraPos.x = 1.0f - Mathf.Exp(-Time.deltaTime * 20).Lerp(transform.position.x, _targetPosition.x);
                _currentCameraPos.y = 1.0f - Mathf.Exp(-Time.deltaTime * 20).Lerp(transform.position.y, _targetPosition.y);

                _currentCameraPos.z = transform.position.z;
                
                if (_shake){
                    _shakeFrame--;

                    // 每5帧一次
                    if (_shakeFrame % 5 == 0){
                        // 屏幕震动
                        var shakeA = Mathf.Lerp(_shakeA, 0.0f, (_shakeFrame / 30.0f));
                        transform.position = new Vector3(_currentCameraPos.x + Random.Range(-shakeA, shakeA),
                            _currentCameraPos.y + Random.Range(-shakeA, shakeA), _currentCameraPos.z);
                    }



                    if (_shakeFrame <= 0){
                        _shake = false;
                    }
                }
                else{
                    transform.PositionX(
                        (1.0f-Mathf.Exp(-Time.deltaTime*20))
                        .Lerp(transform.position.x,_targetPosition.x));
                    
                    transform.PositionY(
                        (1.0f-Mathf.Exp(-Time.deltaTime*20))
                        .Lerp(transform.position.y,_targetPosition.y));
                }
                

            }
        }

        public static void Shake(){
            Instance._shake = true;
            Instance._shakeFrame = 30;
            Instance._shakeA = 0.5f;
        }
        
    }
}
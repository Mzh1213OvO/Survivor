using UnityEngine;
using QFramework;
using UnityEngine.UI;

namespace ProjectSurvivor{
    public partial class FloatTextController : ViewController{
        private static FloatTextController mDefault;
        
        void Start(){
            FloatText.Hide();
        }

        public static void Play(Vector2 position,string text){
            mDefault.FloatText.InstantiateWithParent(mDefault.transform)
                .Position(position.x,position.y)
                .Self(f => {
                    var positionY = position.y;
                    var textTrans = f.transform.Find("Text");
                    var textComp = textTrans.GetComponent<Text>();
                    textComp.text = text;

                    ActionKit.Sequence()
                        .Lerp(0, 0.5f, 0.5f, (p) => {
                            f.PositionY(positionY + p * 0.25f);
                            textComp.LocalScaleX(Mathf.Clamp01(p * 8));
                            textComp.LocalScaleX(Mathf.Clamp01(p * 8));
                        })
                        .Delay(0.5f)
                        .Lerp(1.0f, 0, 0.3f, p => { textComp.ColorAlpha(p); },
                                () => { textTrans.DestroyGameObjGracefully(); })
                            .Start(textComp);
                }).Show();
        }
        
        private void Awake(){
            mDefault = this;
        }

        private void OnDestroy(){
            mDefault = null;
        }
    }
}
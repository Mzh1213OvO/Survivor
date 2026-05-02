using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor{
    public class UIGamePanelData : UIPanelData{ }

    public partial class UIGamePanel : UIPanel{
        protected override void OnInit(IUIData uiData = null){
            mData = uiData as UIGamePanelData ?? new UIGamePanelData();

            Global.Exp.RegisterWithInitValue(exp => {
                ExpText.text="经验值："+exp;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        protected override void OnOpen(IUIData uiData = null){ }

        protected override void OnShow(){ }

        protected override void OnHide(){ }

        protected override void OnClose(){ }
    }
}
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace ProjectSurvivor{
    public class UIGamePassPanelData : UIPanelData{ }

    public partial class UIGamePassPanel : UIPanel{
        protected override void OnInit(IUIData uiData = null){
            mData = uiData as UIGamePassPanelData ?? new UIGamePassPanelData();
            // please add init code here
            
            
            ActionKit.OnUpdate.Register(() => {
                if (Input.GetKeyDown(KeyCode.Space)){
                    SceneManager.LoadScene("SampleScene");
                    this.CloseSelf();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        protected override void OnOpen(IUIData uiData = null){ }

        protected override void OnShow(){ }

        protected override void OnHide(){ }

        protected override void OnClose(){ }
    }
}
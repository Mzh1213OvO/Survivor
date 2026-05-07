using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor{
    public class UIGameStartPanelData : UIPanelData{ }

    public partial class UIGameStartPanel : UIPanel{
        protected override void OnInit(IUIData uiData = null){
            mData = uiData as UIGameStartPanelData ?? new UIGameStartPanelData();
            // please add init code here
            
            CoinUpgradeBtn.onClick.AddListener(() => {
                CoinUpgradePanel.Show();
            });
            
            ExpPercentUpgradeBtn.onClick.AddListener(() => {
                Global.CoinPercent.Value += 0.1f;
            });
            
            ExpPercentUpgradeBtn.onClick.AddListener(() => {
                Global.ExpPercent.Value += 0.1f;
            });
            
            CloseButton.onClick.AddListener(() => {
                CoinUpgradePanel.Hide();
            });
        }

        protected override void OnOpen(IUIData uiData = null){ }

        protected override void OnShow(){ }

        protected override void OnHide(){ }

        protected override void OnClose(){ }
    }
}
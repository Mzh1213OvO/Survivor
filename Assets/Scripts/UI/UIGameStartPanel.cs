using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace ProjectSurvivor{
    public class UIGameStartPanelData : UIPanelData{ }

    public partial class UIGameStartPanel : UIPanel{
        protected override void OnInit(IUIData uiData = null){
            mData = uiData as UIGameStartPanelData ?? new UIGameStartPanelData();

            Global.Coin.RegisterWithInitValue(coin => {
                CoinText.text = "金币：" + coin;
                if (coin >= 5){
                    CoinPercentUpgradeBtn.Show();
                    ExpPercentUpgradeBtn.Show();
                }
                else{
                    CoinPercentUpgradeBtn.Hide();
                    ExpPercentUpgradeBtn.Hide();
                }

                if (coin >= 30){
                    BtnPlayerMaxHpUpgrade.Show();
                }
                else{
                    BtnPlayerMaxHpUpgrade.Hide();
                }
                
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            
            ExpPercentUpgradeBtn.onClick.AddListener(() => {
                Global.ExpPercent.Value += 0.1f;
                Global.Coin.Value -= 5;
            });
            
            CoinPercentUpgradeBtn.onClick.AddListener(() => {
                Global.CoinPercent.Value += 0.1f;
                Global.Coin.Value -= 5;
            });
            
            CoinUpgradeBtn.onClick.AddListener(() => {
                CoinUpgradePanel.Show();
            });
            
            StartGameBtn.onClick.AddListener(() => {
                this.CloseSelf();
                
                SceneManager.LoadScene("Game");
            });
            
            BtnPlayerMaxHpUpgrade.onClick.AddListener((() => {
                Global.Coin.Value -= 30;
                Global.MaxHp.Value += 1;
            }));
            
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
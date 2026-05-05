using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Unity.VisualScripting;

namespace ProjectSurvivor{
    public class UIGamePanelData : UIPanelData{ }

    public partial class UIGamePanel : UIPanel{
        protected override void OnInit(IUIData uiData = null){
            mData = uiData as UIGamePanelData ?? new UIGamePanelData();

            Global.Exp.RegisterWithInitValue(exp => {
                ExpText.text="经验值："+exp;

                if (exp >= 5){
                    Global.Exp.Value -= 5;
                    Global.Level.Value += 1;
                }
                
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            Global.Level.RegisterWithInitValue(level => {
                LevelText.text="等级："+level;

                if (level > 1){
                    Time.timeScale = 0;
                    UpgradeButton.Show();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            Global.CurrentSeconds.RegisterWithInitValue(currentSeconds => {
                if (Time.frameCount % 30 != 0) return;
                
                var currentSecondsInt = Mathf.FloorToInt(currentSeconds);
                var seconds = currentSecondsInt % 60;
                var minutes = currentSeconds / 60;

                TimeText.text = $"时间:{minutes:00}:{seconds:00}";

            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            ActionKit.OnUpdate.Register(() => {
                Global.CurrentSeconds.Value += Time.deltaTime;

                if (Global.CurrentSeconds.Value >= 5){
                    UIKit.OpenPanel<UIGamePassPanel>();
                }
                
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            UpgradeButton.onClick.AddListener(() => {
                Time.timeScale = 1;
                Global.Damage.Value += 1;
                UpgradeButton.Hide();
            });
        }

        protected override void OnOpen(IUIData uiData = null){ }

        protected override void OnShow(){ }

        protected override void OnHide(){ }

        protected override void OnClose(){ }
    }
}
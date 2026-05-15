using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Unity.VisualScripting;

namespace ProjectSurvivor{
    public class UIGamePanelData : UIPanelData{ }

    public partial class UIGamePanel : UIPanel{
        protected override void OnInit(IUIData uiData = null){
            mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            
            // 生命值UI
            Global.Hp.RegisterWithInitValue(hp => {
                HpText.text = "生命值：" + hp + "/"+Global.MaxHp;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            Global.MaxHp.RegisterWithInitValue(maxHP => {
                HpText.text = "生命值：" + Global.Hp + "/"+maxHP;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            // 经验值UI
            Global.Exp.RegisterWithInitValue(exp => {
                ExpText.text = "经验值：(" + exp + "/" + Global.ExpToNextLevel()+")";

                if (exp >= Global.ExpToNextLevel()){
                    Global.Exp.Value -= Global.ExpToNextLevel();
                    Global.Level.Value += 1;
                }
                
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            // 等级UI
            Global.Level.RegisterWithInitValue(level => {
                LevelText.text="等级："+level;

                if (level > 1){
                    Time.timeScale = 0;
                    UpgradeButtons.Show();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            // 敌人数量UI
            EnemyGenerator.EnemyCount.RegisterWithInitValue(enemyCount => {
                EnemyCountText.text="敌人："+enemyCount;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            // 时间UI
            Global.CurrentSeconds.RegisterWithInitValue(currentSeconds => {
                if (Time.frameCount % 30 != 0) return;
                
                var currentSecondsInt = Mathf.FloorToInt(currentSeconds);
                var seconds = currentSecondsInt % 60;
                var minutes = currentSecondsInt / 60;

                TimeText.text = $"时间:{minutes:00}:{seconds:00}";

            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            // 胜利条件UI
            var enemyGenerator = GameObject.FindObjectOfType<EnemyGenerator>();
            ActionKit.OnUpdate.Register(() => {
                Global.CurrentSeconds.Value += Time.deltaTime;
                
                //胜利条件
                if (enemyGenerator.LastWave && EnemyGenerator.EnemyCount.Value==0 && enemyGenerator.CurrentWave==null){
                    UIKit.OpenPanel<UIGamePassPanel>();
                }
                
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            // 攻击力UP按钮
            DamageUpButton.onClick.AddListener(() => {
                Time.timeScale = 1;
                Global.Damage.Value *= 1.5f;
                UpgradeButtons.Hide();
            });
            
            // 攻击频率UP按钮
            DamageFrequencyButton.onClick.AddListener(() => {
                Time.timeScale = 1;
                Global.DamageFrequency.Value *= 0.8f;
                UpgradeButtons.Hide();
            });

            
            // 金币UI
            Global.Coin.RegisterWithInitValue(coin => {
                CoinText.text = "金币:" + coin;

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
        }
        
        protected override void OnOpen(IUIData uiData = null){ }

        protected override void OnShow(){ }

        protected override void OnHide(){ }

        protected override void OnClose(){ }
    }
}
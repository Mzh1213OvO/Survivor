using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace ProjectSurvivor{
    public class Global : Architecture<Global>{
       
        # region Model
        public static BindableProperty<int> Hp = new BindableProperty<int>(3);
        
        public static BindableProperty<int> MaxHp = new BindableProperty<int>(3);
        
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);
        
        public static BindableProperty<int> Coin = new BindableProperty<int>(0);
        
        public static BindableProperty<int> Level = new BindableProperty<int>(1);
        
        public static BindableProperty<float> CurrentSeconds = new BindableProperty<float>(0);

        public static BindableProperty<float> Damage = new BindableProperty<float>(1);
        
        public static BindableProperty<float> DamageFrequency = new BindableProperty<float>(1.5f);

        public static BindableProperty<float> ExpPercent = new BindableProperty<float>(0.3f);
        
        public static BindableProperty<float> CoinPercent = new BindableProperty<float>(0.05f);

        #endregion
        
        [RuntimeInitializeOnLoadMethod]
        public static void AutoInit(){
            ResKit.Init();
            
            // UIKit.Root.SetResolution(1920,1080,1);

            Global.MaxHp.Value=PlayerPrefs.GetInt(nameof(MaxHp), 3);
            Hp.Value = MaxHp.Value;
            
            Global.Coin.Value = PlayerPrefs.GetInt("Coin", 0);
            
            Global.ExpPercent.Value = PlayerPrefs.GetFloat(nameof(ExpPercent), 0.4f);
            
            Global.CoinPercent.Value=PlayerPrefs.GetFloat(nameof(CoinPercent), 0.1f);
            
            Global.Coin.Register(coin => {
                PlayerPrefs.SetInt(nameof(Coin),coin);
            });
            
            Global.ExpPercent.Register(expPercent => {
                PlayerPrefs.SetFloat(nameof(ExpPercent),expPercent);
            });
            
            Global.CoinPercent.Register(coinPercent => {
                PlayerPrefs.SetFloat(nameof(CoinPercent),coinPercent);
            });

            Global.MaxHp.Register(maxHP => {
                PlayerPrefs.SetInt(nameof(MaxHp),maxHP);
            });
        }
        
        public static void Reset(){
            Hp.Value = MaxHp.Value;
            Exp.Value = 0;
            Level.Value = 1;
            Damage.Value = 1;
            DamageFrequency.Value = 1;
            CurrentSeconds.Value = 0;
            EnemyGenerator.EnemyCount.Value = 0;
        }

        public static int ExpToNextLevel(){
            return Level.Value * 5;
        }

        public static void GeneratePowerUp(GameObject gameObject){
            var percent = Random.Range(0, 1f);
            

            //todo:血瓶掉落概率
            if (percent < 0.3f){
                PowerUpManager.Instance.BloodBottle.Instantiate()
                    .Position(gameObject.Position())
                    .Show();

                return;
            }
            
            percent = Random.Range(0, 1f);
            if (percent < ExpPercent.Value){
                PowerUpManager.Instance.Exp.Instantiate()
                    .Position(gameObject.Position())
                    .Show();
            }

            percent = Random.Range(0, 1f);
            if (percent < CoinPercent.Value){
                PowerUpManager.Instance.Coin.Instantiate()
                    .Position(gameObject.Position())
                    .Show();
            }

        }

        /// <summary>
        /// 注册模块
        /// </summary>
        protected override void Init(){
        }
    }
}
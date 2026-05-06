using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace ProjectSurvivor{
    public class Global : MonoBehaviour{
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);
        
        public static BindableProperty<int> Level = new BindableProperty<int>(1);
        
        public static BindableProperty<float> Damage = new BindableProperty<float>(1);
        
        public static BindableProperty<float> CurrentSeconds = new BindableProperty<float>(0);

        public static void Reset(){
            Exp.Value = 0;
            Level.Value = 1;
            Damage.Value = 1;
            CurrentSeconds.Value = 0;
            EnemyGenerator.EnemyCount.Value = 0;
        }
    }
}
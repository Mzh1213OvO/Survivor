using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace ProjectSurvivor{
    public class Global : MonoBehaviour{
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);
    }
}
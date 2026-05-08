using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
	// Generate Id:afbf19fa-a950-4001-9e85-9d9a2b4787ed
	public partial class UIGameStartPanel
	{
		public const string Name = "UIGameStartPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button CoinUpgradeBtn;
		[SerializeField]
		public UnityEngine.UI.Button StartGameBtn;
		[SerializeField]
		public RectTransform CoinUpgradePanel;
		[SerializeField]
		public UnityEngine.UI.Button CoinPercentUpgradeBtn;
		[SerializeField]
		public UnityEngine.UI.Button ExpPercentUpgradeBtn;
		[SerializeField]
		public UnityEngine.UI.Button CloseButton;
		[SerializeField]
		public Text CoinText;
		
		private UIGameStartPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			CoinUpgradeBtn = null;
			StartGameBtn = null;
			CoinUpgradePanel = null;
			CoinPercentUpgradeBtn = null;
			ExpPercentUpgradeBtn = null;
			CloseButton = null;
			CoinText = null;
			
			mData = null;
		}
		
		public UIGameStartPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameStartPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameStartPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}

using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
	// Generate Id:105d9227-1c1d-4f9b-b3ff-b0a98a34ab6b
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
		public UnityEngine.UI.Button BtnPlayerMaxHpUpgrade;
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
			BtnPlayerMaxHpUpgrade = null;
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

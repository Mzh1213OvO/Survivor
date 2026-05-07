using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
	// Generate Id:b7897748-3b50-402a-9c96-f3fa9d82d5b0
	public partial class UIGameStartPanel
	{
		public const string Name = "UIGameStartPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button CoinUpgradeBtn;
		[SerializeField]
		public RectTransform CoinUpgradePanel;
		[SerializeField]
		public UnityEngine.UI.Button CoinPercentUpgradeBtn;
		[SerializeField]
		public UnityEngine.UI.Button ExpPercentUpgradeBtn;
		[SerializeField]
		public UnityEngine.UI.Button CloseButton;
		
		private UIGameStartPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			CoinUpgradeBtn = null;
			CoinUpgradePanel = null;
			CoinPercentUpgradeBtn = null;
			ExpPercentUpgradeBtn = null;
			CloseButton = null;
			
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

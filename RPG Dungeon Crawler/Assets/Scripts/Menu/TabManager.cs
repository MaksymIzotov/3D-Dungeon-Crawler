using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
	public static TabManager Instance;

	[SerializeField] Tab[] tabs;

	void Awake() => Instance = this;

    public void OpenTab(string tabName)
	{
		for (int i = 0; i < tabs.Length; i++)
		{
			if (tabs[i].tabName == tabName)
			{
				tabs[i].Open();
			}
			else if (tabs[i].open)
			{
				CloseTab(tabs[i]);
			}
		}
	}

	public void OpenTab(Tab tab)
	{
		for (int i = 0; i < tabs.Length; i++)
		{
			if (tabs[i].open)
			{
				CloseTab(tabs[i]);
			}
		}
		tab.Open();
	}

	public void CloseTab(Tab tab)
	{
		tab.Close();
	}
}

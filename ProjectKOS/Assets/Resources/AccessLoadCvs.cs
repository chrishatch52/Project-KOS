﻿/**
 * Filename: AccessLoadCvs.cs
 * Author: Chris Hatch
 * Created: 5/28/2015
 * Revision: 0
 * Rev. Date: 5/28/2015
 * Rev. Author: Chris Hatch
 * */
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
namespace AssemblyCSharp
{
	public class AccessLoadCvs : MonoBehaviour {
		
		private Canvas _loadCvs;

		private Button _checkFiles;
		private Button _loadFile;
		private Button _mainMenu;

		private Text _fileSelections;

		private InputField _fileName;

		public bool chkState;

		public enum nextLoadState {CHECK_FILES, LOAD_FILE, MAIN_MENU};
		public nextLoadState nxtLState;

		// Use this for initialization
		void Start () {
			this._loadCvs = this.GetComponentInChildren<Canvas> ();

			this._checkFiles = this.GetComponentsInChildren<Button> () [0];
			this._checkFiles.onClick.AddListener (chkFiles);
			this._loadFile = this.GetComponentsInChildren<Button> () [1];
			this._loadFile.onClick.AddListener (loadFile);
			this._mainMenu = this.GetComponentsInChildren<Button> () [2];
			this._mainMenu.onClick.AddListener (mainMenu);

			this._fileSelections = this._loadCvs.GetComponentInChildren<Text> ();
			this._fileName = this._loadCvs.GetComponentInChildren<InputField> ();

		}

		void chkFiles ()
		{
			this.nxtLState = nextLoadState.CHECK_FILES;
			this.chkState = true;
			this._checkFiles.onClick.RemoveListener (chkFiles);
		}

		void loadFile ()
		{
			this.nxtLState = nextLoadState.LOAD_FILE;
			this.chkState = true;
			this.fileName = this._fileName.GetComponentsInChildren<Text> () [1].text;
		}

		void mainMenu ()
		{
			this.nxtLState = nextLoadState.MAIN_MENU;
			this.chkState = true;
		}

		void removeListeners()
		{
			this._checkFiles.onClick.RemoveListener (chkFiles);
			this._loadFile.onClick.RemoveListener (loadFile);
			this._mainMenu.onClick.RemoveListener (mainMenu);
		}

		public string fileName{
			get{
					return this.fileName;
			}
			private set{
				this.fileName = value;
			}
		}
		// Update is called once per frame
		void Update () {
			
		}
	}
	
}

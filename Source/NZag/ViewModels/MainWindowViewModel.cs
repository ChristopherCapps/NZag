﻿using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using NZag.Services;
using SimpleMVVM;

namespace NZag.ViewModels
{
    [Export]
    public class MainWindowViewModel : ViewModelBase<Window>
    {
        private readonly GameService gameService;
        private readonly ScreenViewModel screenViewModel;

        [ImportingConstructor]
        private MainWindowViewModel(GameService gameService, ScreenViewModel screenViewModel)
            : base("Views/MainWindowView")
        {
            this.gameService = gameService;
            this.screenViewModel = screenViewModel;

            this.gameService.GameOpened += OnGameOpened;
            this.gameService.ScriptLoaded += OnScriptLoaded;
        }

        public string Title
        {
            get
            {
                return this.gameService.IsGameOpen
                    ? "NZag - " + Path.GetFileName(this.gameService.GameFileName)
                    : "NZag";
            }
        }

        public string ScriptName
        {
            get
            {
                return this.gameService.IsScriptOpen
                    ? Path.GetFileName(this.gameService.ScriptFileName)
                    : "None";
            }
        }

        protected override void OnViewCreated(Window view)
        {
            var screenContent = view.FindName<Grid>("ScreenContent");
            screenContent.Children.Add(screenViewModel.CreateView());

            this.OpenCommand = RegisterCommand("Open", "Open", OpenExecuted, () => true, new KeyGesture(Key.O, ModifierKeys.Control));
            this.LoadScriptCommand = RegisterCommand("Load Script...", "LoadScript", LoadScriptExecuted, CanLoadScriptExecute);
        }

        private void OnGameOpened(object sender, EventArgs e)
        {
            this.PropertyChanged("Title");
            this.gameService.StartGame(this.screenViewModel);
        }

        private void OnScriptLoaded(object sender, EventArgs e)
        {
            this.PropertyChanged("ScriptName");
        }

        private void OpenExecuted()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Open Z-Machine File",
                Filter = "Story Files (*.z*)|*.z*"
            };

            if (dialog.ShowDialog() == true)
            {
                this.gameService.OpenGame(dialog.FileName);
            }
        }

        private bool CanLoadScriptExecute()
        {
            return !this.gameService.IsGameOpen;
        }

        private void LoadScriptExecuted()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Load Script File",
                Filter = "Script Files (*.script)|*.script"
            };

            if (dialog.ShowDialog() == true)
            {
                this.gameService.LoadScript(dialog.FileName);
            }
        }

        public ICommand OpenCommand { get; private set; }
        public ICommand LoadScriptCommand { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        public ICommand startNewScanCommand
        {
            get
            {
                return new CommandHandler(() => StartNewScanAction());
            }
        }
        private void StartNewScanAction()
        {
            _images.Clear();
            _video.Clear();
            _audio.Clear();
            _documents.Clear();
            _archieves.Clear();
            _folders.Clear();
            _other.Clear();
            _state_select_folder();
            SelectedFolder = null;
        }
    }
}

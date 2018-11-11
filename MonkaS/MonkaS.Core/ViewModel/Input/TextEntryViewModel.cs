﻿using MonkaS.Core.ViewModel.Base;
using System.Windows.Input;

namespace MonkaS.Core.ViewModel.Input
{
    /// <summary>
    /// The view model for a text entry to edit a string value
    /// <summary>
    public class TextEntryViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        private string _Label;

        /// <summary>
        /// The current saved value
        /// </summary>
        private string _OriginalText;

        /// <summary>
        /// The current non-commit edited text
        /// </summary>
        private string _EditedText;

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        private bool _Editing;


        #endregion


        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label
        {
            get => _Label;
            set => this.MutateVerbose(ref _Label, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current saved value
        /// </summary>
        public string OriginalText
        {
            get => _OriginalText;
            set => this.MutateVerbose(ref _OriginalText, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current non-commit edited text
        /// </summary>
        public string EditedText
        {
            get => _EditedText;
            set => this.MutateVerbose(ref _EditedText, value, RaisePropertyChanged());
        }

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        public bool Editing
        {
            get => _Editing;
            set => this.MutateVerbose(ref _Editing, value, RaisePropertyChanged());
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commits the edits and saves the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextEntryViewModel()
        {
            // Create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            // Set the edited text to the current value
            EditedText = OriginalText;

            // Go into edit mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            // TODO: Save content
            OriginalText = EditedText;

            Editing = false;
        }

        #endregion

    }
}
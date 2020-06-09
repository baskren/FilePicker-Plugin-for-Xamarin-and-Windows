using System;

namespace Plugin.FilePicker
{
    public static class Platform
    {
        public static void Init()
        {
            CrossFilePicker.CreateFilePicker = CreateFilePicker;
            CrossFolderPicker.CreateFolderPicker = CreateFolderPicker;
        }

        static Abstractions.IFilePicker CreateFilePicker()
            => new FilePickerImplementation();

        static Abstractions.IFolderPicker CreateFolderPicker()
            => new FolderPickerImplementation();
        
    }
}

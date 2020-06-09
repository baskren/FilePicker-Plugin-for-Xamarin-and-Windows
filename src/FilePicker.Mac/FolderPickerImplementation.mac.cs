using System;
using System.IO;
using System.Threading.Tasks;
using AppKit;

namespace Plugin.FilePicker
{
    public class FolderPickerImplementation : Abstractions.IFolderPicker
    {

        public bool CanPickFolder => true;

        public Task<FolderData> PickFolder()
        {
            // for consistency with other platforms, only allow selecting of a single folder.
            // would be nice if we passed a "file options" to override picking multiple files & directories
            var openPanel = new NSOpenPanel
            {
                CanChooseFiles = false,
                AllowsMultipleSelection = false,
                CanChooseDirectories = true
            };


            FolderData data = null;

            var result = openPanel.RunModal();
            if (result == 1)
            {
                // Nab the first file
                var url = openPanel.Urls[0];

                if (url != null)
                {
                    var path = url.Path;
                    var folderName = Path.GetDirectoryName(path);
                    data = new FolderData(path, folderName);
                }
            }

            return Task.FromResult(data);
        }
    }
}

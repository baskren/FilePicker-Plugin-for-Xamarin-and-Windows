using System;
using System.Threading.Tasks;

namespace Plugin.FilePicker.Abstractions
{
    public interface IFolderPicker
    {
        bool CanPickFolder { get; }

        Task<FolderData> PickFolder();
    }
}

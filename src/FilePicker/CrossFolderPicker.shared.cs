using System;
using Plugin.FilePicker.Abstractions;

namespace Plugin.FilePicker
{
    public class CrossFolderPicker
    {
        internal static Func<IFolderPicker> CreateFolderPicker { get; set; } = NetStandardCreateFolderPicker;


        static IFolderPicker _implementation = null;
        /// <summary>
        /// Current file picker plugin implementation to use
        /// </summary>
        public static IFolderPicker Current
        {
            get
            {
                var ret = _implementation ?? CreateFolderPicker.Invoke();
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }

                return ret;
            }
        }


        /// <summary>
        /// Creates file picker instance for the platform
        /// </summary>
        /// <returns>file picker instance</returns>
        private static IFolderPicker NetStandardCreateFolderPicker()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
            return new FilePickerImplementation();
#endif
        }


        /// <summary>
        /// Returns new exception to throw when implementation is not found. This is the case when
        /// the NuGet package is not added to the platform specific project.
        /// </summary>
        /// <returns>exception to throw</returns>
        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException(
                "This functionality is not implemented in the portable version of this assembly. You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }

}

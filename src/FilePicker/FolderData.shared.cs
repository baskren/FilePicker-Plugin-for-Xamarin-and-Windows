using System;
namespace Plugin.FilePicker
{
    public class FolderData : IDisposable
    {
        string _folderName;

        string _folderPath;

        bool _isDisposed;

        readonly Action<bool> _dispose;


        public FolderData()
        {
        }

        public FolderData(string folderPath, string folderName, Action<bool> dispose = null)
        {
            _folderName = folderName;
            _folderPath = folderPath;
            _dispose = dispose;
        }


        /// <summary>
        /// Filename of the picked file, without path
        /// </summary>
        public string FolderName
        {
            get
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(null);

                return _folderName;
            }

            set
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(null);

                _folderName = value;
            }
        }

        /// <summary>
        /// Full filepath of the picked file.
        /// Note that on specific platforms this can also contain an URI that
        /// can't be opened with file related APIs. Use DataArray property or
        /// GetStream() method in this cases.
        /// </summary>
        public string FolderPath
        {
            get
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(null);

                return _folderPath;
            }

            set
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(null);

                _folderPath = value;
            }
        }

        #region IDispose implementation
        /// <summary>
        /// Disposes of all resources in the object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of managed resources
        /// </summary>
        /// <param name="disposing">
        /// True when called from Dispose(), false when called from the destructor
        /// </param>
        private void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            _dispose?.Invoke(disposing);
        }

        /// <summary>
        /// Finalizer for this object
        /// </summary>
        ~FolderData()
        {
            this.Dispose(false);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProcessTextFileLibrary
{
    public class FileProcessor : IDisposable
    {
        private const int CodePageForEncoding = 1252;

        private const int RequiredCharactersNumber = 1;

        private const int firstCharacterIndex = 0;

        private static EncodingProvider _provider = CodePagesEncodingProvider.Instance;

        private static readonly Encoding _encoding;

        private bool _disposed = false;



        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        private FileStream _fileStream;

        private FileProcessor(string filePath)
        {
            InitializeStreams(filePath);
        }

        private FileProcessor(string filePath, int fileLength)
        {
            InitializeStreams(filePath);

            _fileStream.SetLength(0);

            string whitespace = new string(' ', fileLength);

            _streamWriter.Write(whitespace);
        }

        static FileProcessor()
        {
            Encoding.RegisterProvider(_provider);

            _encoding = Encoding.GetEncoding(CodePageForEncoding);
        }

        public char this[int index]
        {
            get
            {
                return ReadByIndex(index);
            }
            set
            {
                WriteByIndex(value, index);
            }
        }

        public long Length => _fileStream.Length;

        public static FileProcessor Create(string filePath, int fileLength)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            if (fileLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(fileLength));
            }

            return new FileProcessor(filePath, fileLength);
        }

        public static FileProcessor Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            return new FileProcessor(filePath);
        }

        private void InitializeStreams(string filePath)
        {
            _fileStream = new FileStream(path: filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            _streamWriter = new StreamWriter(_fileStream, _encoding)
            {
                AutoFlush = true
            };

            _streamReader = new StreamReader(_fileStream, _encoding);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _streamWriter.Dispose();

                _streamReader.Dispose();

                _fileStream.Dispose();
            }

            _disposed = true;
        }

        private char ReadByIndex(int index)
        {
            _fileStream.Position = index;

            var buffer = new char[1];
            int charactersRead = _streamReader.Read(buffer);

            if (charactersRead != RequiredCharactersNumber)
            {
                throw new IOException($"No character was read at index {index}");
            }

            return buffer[firstCharacterIndex];
        }

        private void WriteByIndex(char value, int index)
        {
            _fileStream.Position = index;

            _streamWriter.Write(value);
        }

        ~FileProcessor()
        {
            Dispose(false);
        }
    }
}

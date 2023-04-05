namespace Fileupload.UploadedFiles
{
    public class HttpPostedFileBase
    {
        private ReadOnlySpan<char> fileName;

        public HttpPostedFileBase(ReadOnlySpan<char> fileName)
        {
            this.fileName = fileName;
        }

        public ReadOnlySpan<char> GetFileName()
        {
            return fileName;
        }

        internal void SetFileName(ReadOnlySpan<char> value)
        {
            fileName = value;
        }

        internal void SaveAs(string path)
        {
            throw new NotImplementedException();
        }
    }
}

namespace MemoryManagement
{
    internal class DataAccess
    {
        private readonly string _filePath;
        public DataAccess(string filePath)
        {
            _filePath = filePath;
        }
        public void Write(string data)
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    StreamWriter writer = null;
                    using (writer = new StreamWriter(_filePath, true))
                    {
                        writer.WriteLine(data);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

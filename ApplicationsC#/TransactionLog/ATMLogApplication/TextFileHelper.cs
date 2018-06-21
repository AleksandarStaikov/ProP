namespace ATMLogApplication
{
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    using ATMLogApplication.Models;
    using System.Globalization;

    public class TextFileHelper
    {
        public TextFileHelper()
        {
            this.FileName = null;
        }

        public TextFileHelper(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; set; }

        public Log ReadFromFile()
        {
            FileStream fs = null;
            StreamReader sr = null;
            var log = new Log();

            try
            {
                fs = new FileStream(this.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                sr = new StreamReader(fs);


                string line = sr.ReadLine();

                if (!string.IsNullOrEmpty(line))
                {
                    log.BankAccountNumber = line;
                    log.StartDate = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd/HH:mm:ss", CultureInfo.InvariantCulture);
                    log.EndDate = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd/HH:mm:ss", CultureInfo.InvariantCulture);
                    int transactions = int.Parse(sr.ReadLine());
                    for (int i = 0; i < transactions; i++)
                    {
                        line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line))
                        {
                            throw new Exception("The number of recods provided in the file was lower than the actual number of records");
                        }
                        var pair = line.Split(' ');
                        log.Transactions.Add(new Transaction(int.Parse(pair[0]), double.Parse(pair[1])));
                    }
                }
            }
            catch (IOException)
            {
                return null;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }

            return log;
        }
    }
}

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


        public bool SaveToFile(List<string> lines)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(this.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);

                foreach (var line in lines)
                {
                    if (line != string.Empty)
                    {
                        sw.WriteLine(line);
                    }
                }
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

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
                        var pair = sr.ReadLine().Split(' ');
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

        public void BinarySave(List<string> lines)
        {
            FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, lines);

            fs.Close();
        }

        public List<string> BinaryRead()
        {
            FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            var lines = (List<string>)bf.Deserialize(fs);

            fs.Close();

            return lines;
        }
    }
}

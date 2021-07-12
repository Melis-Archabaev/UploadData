using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadData.Models;
using System.Data.Entity;
using System.IO;

namespace UploadData
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Получение текст из файла 
            string textContent = "";
            string path = @"C:\Users\Melis\Desktop\text.txt";
            try
            {
                using(FileStream fs=File.OpenRead(path))
                {
                    byte[] array = new byte[fs.Length];
                    fs.Read(array, 0, array.Length);
                    string textFromFile = System.Text.UTF8Encoding.Default.GetString(array);
                    textContent = textFromFile;
                    fs.Close();
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //Не добавить слово которое длина меньше 3 и больше 20
            string[] words = textContent.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int mx = 20;
            int mn = 3;
            int i = 0;

            string textReady = "";
            foreach (string word in words)
            {
                if (true)
                {
                    if (word.Length > mx)
                    {
                        continue;
                    }

                    if (word.Length < mn)
                    {
                        continue;
                    }
                    textReady += word + " "; 
                }

                i++;

            }



            //Совпадание слова(т.е. не добавлаем повторяшие слова)
            string textToPushDb = "";
            string[] sourceWords = textReady.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] repeatingWords = sourceWords.Where(
               sourceWord => sourceWords.Count(word => word == sourceWord) > 0).Distinct().ToArray();

            foreach (var repeatingWord in repeatingWords)
               textToPushDb +=repeatingWord + " ";


            //Сохранение в базу данных
            //Если база не создано еще, то создается 
            using (AppDbContext db=new AppDbContext())
            {
                Text textfile = new Text { Content = textToPushDb };
                db.Texts.Add(textfile);
                db.SaveChanges();
                //Console.WriteLine(textfile.Content);
            }

            Console.WriteLine("Успешно загружено в базу данных.");
            Console.Read();

        }
        }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.Json;

namespace Photo
{
    [Serializable]
    public class Feed
    {
        static Feed instance;

        public int index { get; set; }

        
        public List<FeedImage> feedImages { get; set; } = new List<FeedImage>();


        //створити або отримати екземпляр
        public static Feed GetInstance()
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = new Feed();
                return instance;
            }
        }

        public List<FeedImage> GetFeed()
        {
            return feedImages;
        }

        //зберегти данні до файлу
        public void Save()
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(Feed.instance);
            File.WriteAllText("data.json", jsonString);
        }

        //завантажити дані з файлу
        public void Load()
        {
            string data = File.ReadAllText("data.json");
            instance = JsonConvert.DeserializeObject<Feed>(data);
            MainForm.instance.RefreshContent();
            
        }

        //створити зображення
        public void CreateImage(string url, string title, string author)
        {
            feedImages.Add(new FeedImage(url, title, author));

            if (index == 0)
                MainForm.instance.RefreshContent();

            Save();


        }

    }
}

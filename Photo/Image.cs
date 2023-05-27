using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo
{

    //клас коментаря
    [Serializable]
    public class Comment
    {
        public string author { get; set; }
        public string text { get; set; }

        public Comment(string _author, string _text)
        {
            author = _author;
            text = _text;
        }

    }

    //клас зображення
    [Serializable]
    public class FeedImage
    {
        public string url { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public List<Comment> comments { get; set; } = new List<Comment>();

        public FeedImage(string _url, string _title, string _author)
        {
            url = _url;
            title = _title;
            author = _author;
        }


        //додати коментар до зображення
        public void AddComment(string _author, string _text)
        {
            comments.Insert(0,new Comment(_author,_text));
        }

    }
}
